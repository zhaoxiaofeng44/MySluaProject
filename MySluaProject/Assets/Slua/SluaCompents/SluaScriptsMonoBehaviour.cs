using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SLua;
using LuaInterface;
using System;

namespace Slua.SluaCompents
{
    public class SluaScriptsMonoBehaviour
       : MonoBehaviour
    {
        public List<string> Scripts = new List<string>();

        LuaFunction creater;
        List<SluaScriptsComponent> mScriptComponents;

        public void Start()
        {

            mScriptComponents = new List<SluaScriptsComponent>();

            creater = LuaState.get(SluaSvr.L).getFunction("Sluc.new");

            foreach (string name in Scripts)
            {
                AddScriptComponent(name);
            }
        }

        public LuaTable AddScriptComponent(string name)
        {
            LuaTable luaScripts = null;
            if (null != creater)
            {
                luaScripts = (LuaTable)creater.call(name);
                if (null != luaScripts)
                {
                    SluaScriptsComponent behaviour;
                    behaviour = this.gameObject.AddComponent<SluaScriptsComponent>();
                    behaviour.setScripts(luaScripts, name);
                    this.mScriptComponents.Add(behaviour);
                }
            }
            return luaScripts;
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static public int AddScriptComponent(IntPtr l)
        {
            SluaScriptsMonoBehaviour self = (SluaScriptsMonoBehaviour)LuaObject.checkSelf(l);

            string name;
            LuaTable luaScripts = null;

            if (LuaObject.checkType(l, 2, out name))
            {
                luaScripts = self.AddScriptComponent(name);
            }

            LuaObject.pushValue(l, true);
            LuaObject.pushObject(l, luaScripts);
            return 2;
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static public int GetScriptComponent(IntPtr l)
        {
            SluaScriptsMonoBehaviour self = (SluaScriptsMonoBehaviour)LuaObject.checkSelf(l);

            string name;
            LuaObject.checkType(l, 2, out name);

            LuaTable target = null;
            foreach (SluaScriptsComponent var in self.mScriptComponents)
            {
                if (name == var.name)
                {
                    target = var.getScripts();
                    break;
                }
            }

            LuaObject.pushValue(l, true);
            LuaObject.pushObject(l, target);
            return 2;
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static public int GetScriptComponents(IntPtr l)
        {
            SluaScriptsMonoBehaviour self = (SluaScriptsMonoBehaviour)LuaObject.checkSelf(l);

            string name;
            LuaObject.checkType(l, 2, out name);

            List<LuaTable> list = new List<LuaTable>();
            foreach (SluaScriptsComponent var in self.mScriptComponents)
            {
                if (name == var.name)
                {
                    list.Add(var.getScripts());
                }
            }

            LuaObject.pushValue(l, true);
            LuaObject.pushObject(l, list.ToArray());
            return 2;
        }
    }
}
