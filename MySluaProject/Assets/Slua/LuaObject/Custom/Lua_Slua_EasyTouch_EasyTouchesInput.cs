using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Slua_EasyTouch_EasyTouchesInput : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			Slua.EasyTouch.EasyTouchesInput o;
			o=new Slua.EasyTouch.EasyTouchesInput();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int clear(IntPtr l) {
		try {
			Slua.EasyTouch.EasyTouchesInput self=(Slua.EasyTouch.EasyTouchesInput)checkSelf(l);
			self.clear();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int start(IntPtr l) {
		try {
			Slua.EasyTouch.EasyTouchesInput self=(Slua.EasyTouch.EasyTouchesInput)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			self.start(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int onUpdateAllFingers(IntPtr l) {
		try {
			Slua.EasyTouch.EasyTouchesInput self=(Slua.EasyTouch.EasyTouchesInput)checkSelf(l);
			self.onUpdateAllFingers();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int onWalk(IntPtr l) {
		try {
			Slua.EasyTouch.EasyTouchesInput self=(Slua.EasyTouch.EasyTouchesInput)checkSelf(l);
			UnityEngine.Transform a1;
			checkType(l,2,out a1);
			Slua.EasyTouch.EasyFinger a2;
			checkType(l,3,out a2);
			self.onWalk(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_maxFingers(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Slua.EasyTouch.EasyTouchesInput.maxFingers);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_maxFingers(IntPtr l) {
		try {
			System.Int32 v;
			checkType(l,2,out v);
			Slua.EasyTouch.EasyTouchesInput.maxFingers=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Slua.EasyTouch.EasyTouchesInput");
		addMember(l,clear);
		addMember(l,start);
		addMember(l,onUpdateAllFingers);
		addMember(l,onWalk);
		addMember(l,"maxFingers",get_maxFingers,set_maxFingers,false);
		createTypeMetatable(l,constructor, typeof(Slua.EasyTouch.EasyTouchesInput));
	}
}
