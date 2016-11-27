using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Slua_EasyTouch_EasyGameObject : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_onUpdate(IntPtr l) {
		try {
			Slua.EasyTouch.EasyGameObject self=(Slua.EasyTouch.EasyGameObject)checkSelf(l);
			System.Action v;
			int op=LuaDelegation.checkDelegate(l,2,out v);
			if(op==0) self.onUpdate=v;
			else if(op==1) self.onUpdate+=v;
			else if(op==2) self.onUpdate-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Slua.EasyTouch.EasyGameObject");
		addMember(l,"onUpdate",null,set_onUpdate,true);
		createTypeMetatable(l,null, typeof(Slua.EasyTouch.EasyGameObject),typeof(UnityEngine.MonoBehaviour));
	}
}
