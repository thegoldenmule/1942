using System;
using UnityEngine;

namespace Space.Client
{
    [Serializable]
    public class AIController : ScriptableObject
    {
        protected readonly StateMachine _fsm = new StateMachine();

        public virtual void Initialize()
        {
            
        }

        public virtual void Update()
        {
            
        }
    }
}