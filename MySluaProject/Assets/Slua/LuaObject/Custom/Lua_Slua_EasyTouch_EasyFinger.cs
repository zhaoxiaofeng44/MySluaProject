using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Slua_EasyTouch_EasyFinger : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			Slua.EasyTouch.EasyFinger o;
			o=new Slua.EasyTouch.EasyFinger();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Zero(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Slua.EasyTouch.EasyFinger.Zero);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Zero(IntPtr l) {
		try {
			Slua.EasyTouch.EasyFinger v;
			checkType(l,2,out v);
			Slua.EasyTouch.EasyFinger.Zero=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fingerId(IntPtr l) {
		try {
			Slua.EasyTouch.EasyFinger self=(Slua.EasyTouch.EasyFinger)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.fingerId);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fingerId(IntPtr l) {
		try {
			Slua.EasyTouch.EasyFinger self=(Slua.EasyTouch.EasyFinger)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.fingerId=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isSwallow(IntPtr l) {
		try {
			Slua.EasyTouch.EasyFinger self=(Slua.EasyTouch.EasyFinger)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isSwallow);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_isSwallow(IntPtr l) {
		try {
			Slua.EasyTouch.EasyFinger self=(Slua.EasyTouch.EasyFinger)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.isSwallow=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_position(IntPtr l) {
		try {
			Slua.EasyTouch.EasyFinger self=(Slua.EasyTouch.EasyFinger)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.position);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_position(IntPtr l) {
		try {
			Slua.EasyTouch.EasyFinger self=(Slua.EasyTouch.EasyFinger)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.position=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_startPosition(IntPtr l) {
		try {
			Slua.EasyTouch.EasyFinger self=(Slua.EasyTouch.EasyFinger)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.startPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_startPosition(IntPtr l) {
		try {
			Slua.EasyTouch.EasyFinger self=(Slua.EasyTouch.EasyFinger)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.startPosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_deltaStartTime(IntPtr l) {
		try {
			Slua.EasyTouch.EasyFinger self=(Slua.EasyTouch.EasyFinger)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.deltaStartTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_deltaStartTime(IntPtr l) {
		try {
			Slua.EasyTouch.EasyFinger self=(Slua.EasyTouch.EasyFinger)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.deltaStartTime=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_phase(IntPtr l) {
		try {
			Slua.EasyTouch.EasyFinger self=(Slua.EasyTouch.EasyFinger)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.phase);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_phase(IntPtr l) {
		try {
			Slua.EasyTouch.EasyFinger self=(Slua.EasyTouch.EasyFinger)checkSelf(l);
			Slua.EasyTouch.FingerPhase v;
			checkEnum(l,2,out v);
			self.phase=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_touchPhase(IntPtr l) {
		try {
			Slua.EasyTouch.EasyFinger self=(Slua.EasyTouch.EasyFinger)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.touchPhase);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_touchPhase(IntPtr l) {
		try {
			Slua.EasyTouch.EasyFinger self=(Slua.EasyTouch.EasyFinger)checkSelf(l);
			UnityEngine.TouchPhase v;
			checkEnum(l,2,out v);
			self.touchPhase=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Slua.EasyTouch.EasyFinger");
		addMember(l,"Zero",get_Zero,set_Zero,false);
		addMember(l,"fingerId",get_fingerId,set_fingerId,true);
		addMember(l,"isSwallow",get_isSwallow,set_isSwallow,true);
		addMember(l,"position",get_position,set_position,true);
		addMember(l,"startPosition",get_startPosition,set_startPosition,true);
		addMember(l,"deltaStartTime",get_deltaStartTime,set_deltaStartTime,true);
		addMember(l,"phase",get_phase,set_phase,true);
		addMember(l,"touchPhase",get_touchPhase,set_touchPhase,true);
		createTypeMetatable(l,constructor, typeof(Slua.EasyTouch.EasyFinger));
	}
}
