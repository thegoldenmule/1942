using System;
using UnityEngine;

namespace Space.Client
{
    [Serializable]
    public class FlightLeg
    {
        public AnimationCurve X;
        public AnimationCurve Z;

        private float _duration = -1;

        public bool Evaluate(float time, out Vector3 position)
        {
            if (_duration < 0f)
            {
                _duration = Duration();
            }

            position = new Vector3(
                X.Evaluate(time),
                0f,
                Z.Evaluate(time));

            return time < _duration;
        }

        private float Duration()
        {
            var duration = 0f;

            var keys = X.keys;
            if (0 != keys.Length)
            {
                duration = Mathf.Max(duration, keys[keys.Length - 1].time);
            }

            keys = Z.keys;
            if (0 != keys.Length)
            {
                duration = Mathf.Max(duration, keys[keys.Length - 1].time);
            }

            return duration;
        }
    }
}