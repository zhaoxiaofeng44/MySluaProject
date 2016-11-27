using UnityEngine;
using System.Collections;

namespace Slua.EasyTouch
{

    public enum FingerPhase
    {
        None  = 0,
        Began = 1,
        Moved = 2,
        Ended = 3,
    }

    public class EasyFinger
    {
        static public EasyFinger Zero = new EasyFinger { phase = FingerPhase.None };

        public int fingerId;             // Finger index
        public bool isSwallow;
        public Vector2 position;            // current position of the touch.
        public Vector2 startPosition;       // Starting position
        public float deltaStartTime;        // Amount of time passed since start change.
        public FingerPhase phase;
        public TouchPhase touchPhase;            // Describes the phase of the touch.
    }
}
