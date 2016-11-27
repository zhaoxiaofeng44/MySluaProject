using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Slua_EasyTouch_TouchScriptEvent : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"Slua.EasyTouch.TouchScriptEvent");
		addMember(l,1,"Touch");
		addMember(l,2,"Event");
		addMember(l,3,"Swallow");
		LuaDLL.lua_pop(l, 1);
	}
}
