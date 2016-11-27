using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Slua_EasyTouch_EasyTouchExtend : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int isSwallow_s(IntPtr l) {
		try {
			Slua.EasyTouch.IEasyTouch a1;
			checkType(l,1,out a1);
			var ret=Slua.EasyTouch.EasyTouchExtend.isSwallow(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setEasy_s(IntPtr l) {
		try {
			Slua.EasyTouch.IEasyTouch a1;
			checkType(l,1,out a1);
			SLua.LuaFunction a2;
			checkType(l,2,out a2);
			Slua.EasyTouch.EasyTouchExtend.setEasy(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int isEasyTouch_s(IntPtr l) {
		try {
			Slua.EasyTouch.IEasyTouch a1;
			checkType(l,1,out a1);
			Slua.EasyTouch.EasyFinger a2;
			checkType(l,2,out a2);
			var ret=Slua.EasyTouch.EasyTouchExtend.isEasyTouch(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int onEasyEvent_s(IntPtr l) {
		try {
			Slua.EasyTouch.IEasyTouch a1;
			checkType(l,1,out a1);
			Slua.EasyTouch.EasyFinger a2;
			checkType(l,2,out a2);
			Slua.EasyTouch.EasyTouchExtend.onEasyEvent(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Slua.EasyTouch.EasyTouchExtend");
		addMember(l,isSwallow_s);
		addMember(l,setEasy_s);
		addMember(l,isEasyTouch_s);
		addMember(l,onEasyEvent_s);
		createTypeMetatable(l,null, typeof(Slua.EasyTouch.EasyTouchExtend));
	}
}
