using Ninject;
using UnityEngine;

namespace Space.Client
{
    public class CombatInputState : InputState
    {
        [Inject]
        public EntityManager Entities{ get; private set; }
        [Inject]
        public Camera Camera { get; private set; }

        public float HorizontalForce = 1f;

        private const string AXIS_NAME = "Horizontal";

        public override void DeltaUpdate(float dt)
        {
            base.DeltaUpdate(dt);

            var player = Entities.Player;
            if (null == player)
            {
                return;
            }

            var horizontal = Input.GetAxis(AXIS_NAME);
            player.Physics.Impulses += horizontal * HorizontalForce * Vector3.right;
        }
    }
}