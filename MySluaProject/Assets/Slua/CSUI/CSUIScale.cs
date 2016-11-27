using UnityEngine;
using System.Collections;
using SLua;
using Slua.EasyTouch;
using System;

namespace Slua.CSUI
{
    public class CSUIScale
        : CSTouchWidget
        , CSTouchDelegate
    {
        private Transform mRectTrans;

        public void Awake()
        {
            CSTouchDelegate = this;
            mRectTrans = GetComponent<Transform>();
        }


        public bool isCSSwallow()
        {
            return true;
        }

        public bool isCSEasyTouch(EasyFinger finger)
        {
            return true;
        }

        public void onCSEasyEvent(EasyFinger finger)
        {
            switch (finger.phase) {
                case FingerPhase.Began:
                    mRectTrans.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                    break;
                case FingerPhase.Ended:
                    mRectTrans.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                    break;
                case FingerPhase.Moved:
                    break;
                default:
                    break;
            }
        }
    }
}
