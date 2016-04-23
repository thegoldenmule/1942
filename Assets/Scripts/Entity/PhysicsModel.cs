using System;
using UnityEngine;

namespace Space.Client
{
    [Serializable]
    public class PhysicsModel
    {
        [NonSerialized]
        public Vector3 Position = Vector3.zero;
        
        [NonSerialized]
        public Quaternion Rotation = Quaternion.identity;
        
        [NonSerialized]
        public Vector3 Scale = Vector3.one;

        [NonSerialized]
        public Vector3 Forces = Vector3.zero;
        
        [NonSerialized]
        public Vector3 Impulses = Vector3.zero;

        public int Iterations = 4;
        public float Mass = 1;
        public float Drag = 100;

        private Vector3 _velocity = Vector3.zero;
        private Vector3 _acceleration = Vector3.zero;

        public Vector3 Velocity
        {
            get { return _velocity; }
        }

        public Vector3 Acceleration
        {
            get { return _acceleration; }
        }

        public void Step(float dt)
        {
            // add drag
            Forces -= Drag * _velocity;

            _acceleration = Forces / Mass;
            _velocity += dt * _acceleration + Impulses / Mass;

            Position += dt * _velocity;
            Forces = Vector3.zero;
            Impulses = Vector3.zero;
        }
    }
}