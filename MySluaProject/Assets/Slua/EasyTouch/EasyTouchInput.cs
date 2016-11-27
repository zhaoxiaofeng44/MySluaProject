using UnityEngine;
using System.Collections;
using Slua.EasyTouch;
using System;
using SLua;


namespace Slua.EasyTouch
{
    public class EasyGameObject 
        : MonoBehaviour
    {
        public Action onUpdate;
        void Update()
        {
            if (onUpdate != null) onUpdate();
        }
    }

    public class EasyTouchesInput
    {
        public static int maxFingers = 3;

        protected GameObject go;
        protected EasyFinger[] fingers;
        protected GameObject easyObject;

        public EasyTouchesInput()
        {
            fingers = new EasyFinger[maxFingers];
            for (int index = 0; index < maxFingers; index++)
            {
                fingers[index] = new EasyFinger() {
                    fingerId = index,
                    phase = FingerPhase.None
                };
            }
        }

        public void clear()
        {
            if (null != go)
            {
                GameObject.Destroy(go);
                go = null;
            }
        }

        public void start(string name)
        {
            clear();

            //lua object
            go = new GameObject("EasyTouchProxy");
            GameObject.DontDestroyOnLoad(go);
            EasyGameObject lgo = go.AddComponent<EasyGameObject>();
            lgo.onUpdate = onUpdateAllFingers;

            //lua event
            easyObject = GameObject.Find(name);
        }

        public void onUpdateAllFingers()
        {
            if (null == easyObject)
            {
                return;
            }

            Touch[] touches = Input.touches;
            if (touches.Length <= 0)
            {
                EasyFinger finger = fingers[0];
                if (Input.GetMouseButtonUp(0))
                {
                    if (FingerPhase.None != finger.phase)
                    {
                        finger.phase = FingerPhase.Ended;
                        finger.deltaStartTime += Time.deltaTime;
                        // todo end
                        finger.isSwallow = false;
                        onWalk(easyObject.transform, finger);
                        finger.phase = FingerPhase.None;
                    }
                }
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (FingerPhase.None == finger.phase)
                        {
                            finger.phase = FingerPhase.Began;
                            finger.position = Input.mousePosition;

                            finger.deltaStartTime = 0;
                            finger.startPosition = finger.position;

                            // todo end
                            finger.isSwallow = false;
                            onWalk(easyObject.transform, finger);
                        }
                    }
                    else
                    {
                        if (Input.GetMouseButton(0))
                        {
                            finger.deltaStartTime += Time.deltaTime;

                            if (finger.position != (Vector2)Input.mousePosition)
                            {
                                finger.phase = FingerPhase.Moved;
                                finger.position = Input.mousePosition;

                                //todo move
                                finger.isSwallow = false;
                                onWalk(easyObject.transform, finger);
                            }
                        }                    
                    }
                }
            }
            else
            { 
                for (int index = 0; index < maxFingers; index++)
                {
                    EasyFinger finger = fingers[index];

                    int nInput = -1;
                    for (int n = 0; n < touches.Length; n++)
                    {
                        if (index == touches[n].fingerId)
                        {
                            nInput = n;
                            break;
                        }
                    }

                    if (-1 == nInput)
                    {
                        if (FingerPhase.None != finger.phase)
                        {
                            finger.phase = FingerPhase.Ended;
                            finger.deltaStartTime += Time.deltaTime;
                            // todo end
                            finger.isSwallow = false;
                            onWalk(easyObject.transform, finger);
                            finger.phase = FingerPhase.None;
                        }
                    }
                    else
                    {
                        Touch input = touches[nInput];
                        if (FingerPhase.None == finger.phase)
                        {
                            finger.phase = FingerPhase.Began;
                            finger.position = input.position;

                            finger.deltaStartTime = 0;
                            finger.startPosition = finger.position;
                            //todo began
                            finger.isSwallow = false;
                            onWalk(easyObject.transform, finger);
                        }
                        else
                        {
                            finger.deltaStartTime += Time.deltaTime;

                            if (finger.position != input.position)
                            {
                                finger.phase = FingerPhase.Moved;
                                finger.position = input.position;
                                //todo move
                                finger.isSwallow = false;
                                onWalk(easyObject.transform, finger);
                            }
                        }
                    }
                }
            }
        }

        public void onWalk(Transform treeSource, EasyFinger finger)
        {
             // 递归遍历子节点
            if (!finger.isSwallow && treeSource.childCount > 0)
            {
                for (int i = 0; i < treeSource.childCount; i++)
                {
                    onWalk(treeSource.GetChild(i), finger);
                }
            }

            if (!finger.isSwallow)
            {
                IEasyTouch touch = treeSource.GetComponent<IEasyTouch>();
                if (null != touch)
                {
                    if (touch.isEasyTouch(finger))
                    {
                        touch.onEasyEvent(finger);
                        finger.isSwallow = touch.isSwallow();
                    }
                }
            }

            if (!finger.isSwallow)
            {
                IEasyTouches touches = treeSource.GetComponent<IEasyTouches>();
                if (null != touches)
                {
                    if (touches.isEasyTouch(finger))
                    {
                        touches.onEasyEvent(finger);
                        finger.isSwallow = touches.isSwallow();
                    }
                }
            }
        }
    }
}
