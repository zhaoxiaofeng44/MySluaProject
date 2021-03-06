﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_StateMachineBehaviour : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnStateEnter(IntPtr l) {
		try {
			UnityEngine.StateMachineBehaviour self=(UnityEngine.StateMachineBehaviour)checkSelf(l);
			UnityEngine.Animator a1;
			checkType(l,2,out a1);
			UnityEngine.AnimatorStateInfo a2;
			checkValueType(l,3,out a2);
			System.Int32 a3;
			checkType(l,4,out a3);
			self.OnStateEnter(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnStateUpdate(IntPtr l) {
		try {
			UnityEngine.StateMachineBehaviour self=(UnityEngine.StateMachineBehaviour)checkSelf(l);
			UnityEngine.Animator a1;
			checkType(l,2,out a1);
			UnityEngine.AnimatorStateInfo a2;
			checkValueType(l,3,out a2);
			System.Int32 a3;
			checkType(l,4,out a3);
			self.OnStateUpdate(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnStateExit(IntPtr l) {
		try {
			UnityEngine.StateMachineBehaviour self=(UnityEngine.StateMachineBehaviour)checkSelf(l);
			UnityEngine.Animator a1;
			checkType(l,2,out a1);
			UnityEngine.AnimatorStateInfo a2;
			checkValueType(l,3,out a2);
			System.Int32 a3;
			checkType(l,4,out a3);
			self.OnStateExit(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnStateMove(IntPtr l) {
		try {
			UnityEngine.StateMachineBehaviour self=(UnityEngine.StateMachineBehaviour)checkSelf(l);
			UnityEngine.Animator a1;
			checkType(l,2,out a1);
			UnityEngine.AnimatorStateInfo a2;
			checkValueType(l,3,out a2);
			System.Int32 a3;
			checkType(l,4,out a3);
			self.OnStateMove(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnStateIK(IntPtr l) {
		try {
			UnityEngine.StateMachineBehaviour self=(UnityEngine.StateMachineBehaviour)checkSelf(l);
			UnityEngine.Animator a1;
			checkType(l,2,out a1);
			UnityEngine.AnimatorStateInfo a2;
			checkValueType(l,3,out a2);
			System.Int32 a3;
			checkType(l,4,out a3);
			self.OnStateIK(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnStateMachineEnter(IntPtr l) {
		try {
			UnityEngine.StateMachineBehaviour self=(UnityEngine.StateMachineBehaviour)checkSelf(l);
			UnityEngine.Animator a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			self.OnStateMachineEnter(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnStateMachineExit(IntPtr l) {
		try {
			UnityEngine.StateMachineBehaviour self=(UnityEngine.StateMachineBehaviour)checkSelf(l);
			UnityEngine.Animator a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			self.OnStateMachineExit(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.StateMachineBehaviour");
		addMember(l,OnStateEnter);
		addMember(l,OnStateUpdate);
		addMember(l,OnStateExit);
		addMember(l,OnStateMove);
		addMember(l,OnStateIK);
		addMember(l,OnStateMachineEnter);
		addMember(l,OnStateMachineExit);
		createTypeMetatable(l,null, typeof(UnityEngine.StateMachineBehaviour),typeof(UnityEngine.ScriptableObject));
	}
}
