﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Effector2D : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Effector2D o;
			o=new UnityEngine.Effector2D();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_colliderMask(IntPtr l) {
		try {
			UnityEngine.Effector2D self=(UnityEngine.Effector2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.colliderMask);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_colliderMask(IntPtr l) {
		try {
			UnityEngine.Effector2D self=(UnityEngine.Effector2D)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.colliderMask=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Effector2D");
		addMember(l,"colliderMask",get_colliderMask,set_colliderMask,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Effector2D),typeof(UnityEngine.Behaviour));
	}
}
