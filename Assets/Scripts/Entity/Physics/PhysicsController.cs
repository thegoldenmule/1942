using System;
using UnityEngine;

namespace Space.Client
{
    /// <summary>
    /// Provides a very simple physics model.
    /// </summary>
    public class PhysicsController
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

        protected GameEntity _entity;
        protected PhysicsControllerDefinition _definition;
        protected Vector3 _velocity = Vector3.zero;
        protected Vector3 _acceleration = Vector3.zero;

        public Vector3 Velocity
        {
            get { return _velocity; }
        }

        public Vector3 Acceleration
        {
            get { return _acceleration; }
        }

        public PhysicsControllerDefinition Definition
        {
            get { return _definition; }
        }

        public virtual void Initialize(GameEntity entity)
        {
            _entity = entity;
            _definition = entity.Definition.Physics;
        }

        public void Step(float dt)
        {
            // add drag
            Forces -= _definition.Drag * _velocity;

            _acceleration = Forces / _definition.Mass;
            _velocity += dt * _acceleration + Impulses / _definition.Mass;

            Position += dt * _velocity;
            Forces = Vector3.zero;
            Impulses = Vector3.zero;
        }
    }
}