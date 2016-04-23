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

        public bool Evaluate(float dt, out Vector3 position)
        {
            if (_duration < 0f)
            {
                _duration = Duration();
            }


        }

        private float Duration()
        {
            var keys = X.keys;
        }
    }

    [Serializable]
    public class FlightPlan
    {
        public FlightLeg[] Legs = new FlightLeg[0];
    }

    [Serializable]
    public class AIController
    {
        private readonly StateMachine _fsm = new StateMachine();

        public virtual void Start(FlightPlan planflightPlan)
        {
            
        }

        public virtual void Update(float dt)
        {
            
        }
    }
}