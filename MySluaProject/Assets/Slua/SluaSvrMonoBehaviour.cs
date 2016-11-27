using UnityEngine;
using System.Collections;
using SLua;
using System;
using Slua.EasyTouch;

namespace Slua
{
    public class SluaSvrMonoBehaviour
        : MonoBehaviour
    {
        public string Script;  // 主启动脚本

        public string EasyObjectName;  // 事件脚本挂载名称

        SluaSvr luaSvr;
        EasyTouchesInput easyInput;

        public void Awake()
        {
            if (null == luaSvr)
            {
                luaSvr = new SluaSvr();
                luaSvr.start(Script);
            }

            if (null == easyInput)
            {
                easyInput = new EasyTouchesInput();
                easyInput.start(EasyObjectName);
            }
        }

        public void OnDestroy()
        {
            if (null != luaSvr)
            {
                luaSvr.clear();
                luaSvr = null;
            }

            if (null != easyInput)
            {
                easyInput.clear();
                easyInput = null;
            }
        }
    }
}
