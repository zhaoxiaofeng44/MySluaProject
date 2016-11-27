using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Slua_EasyTouch_FingerPhase : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"Slua.EasyTouch.FingerPhase");
		addMember(l,0,"None");
		addMember(l,1,"Began");
		addMember(l,2,"Moved");
		addMember(l,3,"Ended");
		LuaDLL.lua_pop(l, 1);
	}
}
