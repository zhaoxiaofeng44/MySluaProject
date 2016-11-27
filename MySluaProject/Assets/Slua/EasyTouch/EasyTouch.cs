using UnityEngine;
using System.Collections;
using System;
using SLua;

namespace Slua.EasyTouch
{

    public enum TouchScriptEvent
    {
        Touch = 1,      //check touch
        Event = 2,      //touch event 
        Swallow = 3,    //is swallow
    }

    public interface IEasyTouch
    {
        bool isSwallow();

        void setEasy(LuaFunction func);

        bool isEasyTouch(EasyFinger finger);

        void onEasyEvent(EasyFinger finger);

        LuaFunction ScriptFunc { get; set; }
    }

    static public class EasyTouchExtend
    {
      
        static public bool isSwallow(IEasyTouch easy)
        {
            if (null != easy.ScriptFunc)
            {
                return (bool)easy.ScriptFunc.call(EasyFinger.Zero, TouchScriptEvent.Swallow);
            }
            return true;
        }

        static public void setEasy(IEasyTouch easy, LuaFunction func)
        {
            easy.ScriptFunc = func;
        }

        static public bool isEasyTouch(IEasyTouch easy,EasyFinger finger)
        {
            if (null != easy.ScriptFunc)
            {
                return (bool)easy.ScriptFunc.call(finger, TouchScriptEvent.Touch);
            }
            return true;
        }

        static public void onEasyEvent(IEasyTouch easy, EasyFinger finger)
        {
            if (null != easy.ScriptFunc)
            {
                easy.ScriptFunc.call(finger, TouchScriptEvent.Event);
            }
            Logger.Log(string.Format("onEasyEvent touhes {0} ({1},{2})", finger.phase.ToString(), finger.position.x, finger.position.y));
        }
    }
}






