using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Slua_EasyTouch_EasyTouches : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int isSwallow(IntPtr l) {
		try {
			Slua.EasyTouch.EasyTouches self=(Slua.EasyTouch.EasyTouches)checkSelf(l);
			var ret=self.isSwallow();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Slua.EasyTouch.EasyTouches");
		addMember(l,isSwallow);
		createTypeMetatable(l,null, typeof(Slua.EasyTouch.EasyTouches),typeof(UnityEngine.MonoBehaviour));
	}
}
