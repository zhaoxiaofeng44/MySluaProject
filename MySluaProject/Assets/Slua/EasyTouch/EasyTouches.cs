using UnityEngine;
using System.Collections;
using Slua.EasyTouch;
using SLua;

namespace Slua.EasyTouch
{
    interface IEasyTouches
    {
        void onEasyEvent(EasyFinger finger);

        bool isSwallow();

        bool isEasyTouch(EasyFinger finger);
    }


    public class EasyTouches
        : MonoBehaviour
        , IEasyTouches
    {
        virtual public bool isSwallow()
        {
            return true;
        }

        [DoNotToLua]
        public bool isEasyTouch(EasyFinger finger)
        {
            return true;
        }

        [DoNotToLua]
        virtual public void onEasyEvent(EasyFinger finger)
        {
            Logger.Log(string.Format("onEasyEvent touhes {0}",finger.phase.ToString()));
        }

    }
}
