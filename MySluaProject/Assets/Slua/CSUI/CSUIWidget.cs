using UnityEngine;
using System.Collections;
using Slua.EasyTouch;
using SLua;
using System;


namespace Slua.CSUI
{
    public class CSUIWidget
       : MonoBehaviour
    {
    }

    public interface CSTouchDelegate
    {
        bool isCSSwallow();

        bool isCSEasyTouch(EasyFinger finger);

        void onCSEasyEvent(EasyFinger finger);
    }

    public class CSTouchWidget
        : CSUIWidget
        , IEasyTouch
    {
        public void setEasy(LuaFunction func)
        {
            EasyTouchExtend.setEasy(this, func);
        }

        public bool isSwallow()
        {
            bool isCsSwallow = false;
            if (null != CSTouchDelegate)
            {
                isCsSwallow = CSTouchDelegate.isCSSwallow();
            }
            return isCsSwallow && EasyTouchExtend.isSwallow(this);
        }

        public bool isEasyTouch(EasyFinger finger)
        {
            bool isCsEasyTouch = false;
            if (null != CSTouchDelegate)
            {
                isCsEasyTouch = CSTouchDelegate.isCSEasyTouch(finger);
            }
            return isCsEasyTouch && EasyTouchExtend.isEasyTouch(this, finger);
        }

        public void onEasyEvent(EasyFinger finger)
        {
            if (null != CSTouchDelegate)
            {
                CSTouchDelegate.onCSEasyEvent(finger);
            }
            EasyTouchExtend.onEasyEvent(this, finger);
        }

        public LuaFunction ScriptFunc { get; set; }

        public CSTouchDelegate CSTouchDelegate { get; set; }
    }
}
