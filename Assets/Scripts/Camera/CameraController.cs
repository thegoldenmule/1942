using Ninject;
using UnityEngine;

namespace Space.Client
{
    public class CameraController : InjectableMonoBehavior
    {
        [Inject]
        public EntityManager Entities { get; private set; }
        [Inject]
        public MapController Map { get; private set; }

        public Vector3 TargetOffset;
        public float SpringStiffness;
        public float Damping;
        public float Mass;

        private bool _firstFrame = true;
        private Vector3 _velocity = Vector3.zero;

        private void LateUpdate()
        {
            if (null == Entities.Player)
            {
                return;
            }

            if (_firstFrame)
            {
                _firstFrame = false;

                transform.position = Entities.Player.transform.position + TargetOffset;
            }
            else
            {
                var dt = Time.deltaTime;
                var desiredPosition = Entities.Player.transform.position + TargetOffset;
                var delta = transform.position - desiredPosition;

                var force = -SpringStiffness * delta - Damping * _velocity;
                var acceleration = force / Mass;
                _velocity += dt * acceleration;
                
                transform.position += dt * _velocity;
                transform.LookAt(Entities.Player.transform.position);
            }
        }
    }
}