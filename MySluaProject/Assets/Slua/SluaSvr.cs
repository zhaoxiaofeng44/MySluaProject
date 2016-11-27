using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using System.Reflection;
using SLua;
using UnityEngine;

namespace SLua
{  
    public class SluaSvr
    {
        static public IntPtr L = IntPtr.Zero;

        public LuaState luaState;
        public GameObject go;
        public int errorReported = 0;

        public void clear()
        {
            if (null != go)
            {
                GameObject.Destroy(go);
                go = null;
            }

            if (null != luaState)
            {
                luaState.Close();
                luaState = null;
            }

            errorReported = 0;
            SluaSvr.L = IntPtr.Zero;
        }

        public void reset()
        {
            clear();
            
            //LuaState
            LuaState state = new LuaState();
            luaState = state;

            IntPtr l = luaState.L;

            SluaSvr.L = l;  //Golab IntPtr

            //lua object
            go = new GameObject("LuaSvrProxy");
            GameObject.DontDestroyOnLoad(go);
            LuaSvrGameObject lgo = go.AddComponent<LuaSvrGameObject>();

            //lua register
            LuaObject.init(l);

            doBind(l);

            LuaTimer.reg(l);
            LuaCoroutine.reg(l, lgo);

            Helper.reg(l);
            LuaValueType.reg(l);

            SLuaDebug.reg(l);
            LuaDLL.luaS_openextlibs(l);
            Lua3rdDLL.open(l);

            lgo.state = luaState;
            lgo.onUpdate = this.onUpdateTimer;
            lgo.init();
        }

        public object start(string main)
        {
            reset();
            if (main != null)
            {
                luaState.doFile(main);
                LuaFunction func = (LuaFunction)luaState["main"];
                if (func != null)
                    return func.call();
            }
            return null;
        }

        protected void onUpdateTimer()
        {
            if (LuaDLL.lua_gettop(luaState.L) != errorReported)
            {
                errorReported = LuaDLL.lua_gettop(luaState.L);
                Logger.LogError(string.Format("Some function not remove temp value({0}) from lua stack. You should fix it.", LuaDLL.luaL_typename(luaState.L, errorReported)));
            }

            luaState.checkRef();
            LuaTimer.tick(Time.deltaTime);
        }

        protected void doBind(IntPtr lusState)
        {
            List<Action<IntPtr>> list = new List<Action<IntPtr>>();

            var assemblyName = "Assembly-CSharp";
            Assembly assembly = Assembly.Load(assemblyName);
            list.AddRange(getBindList(assembly, "SLua.BindUnity"));
            list.AddRange(getBindList(assembly, "SLua.BindUnityUI"));
            list.AddRange(getBindList(assembly, "SLua.BindDll"));
            list.AddRange(getBindList(assembly, "SLua.BindCustom"));

            if (list.Count > 0)
            {
                foreach (var action in list)
                {
                    action(lusState); //register all functions
                }
            }
        }

        protected Action<IntPtr>[] getBindList(Assembly assembly, string ns)
        {
            Type t = assembly.GetType(ns);
            if (t != null)
                return (Action<IntPtr>[])t.GetMethod("GetBindList").Invoke(null, null);
            return new Action<IntPtr>[0];
        }     

    }
}
