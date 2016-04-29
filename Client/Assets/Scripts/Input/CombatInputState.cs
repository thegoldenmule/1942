using Ninject;
using UnityEngine;

namespace Space.Client
{
    /// <summary>
    /// Input for combat.
    /// </summary>
    public class CombatInputState : InputState
    {
        /// <summary>
        /// Dependencies.
        /// </summary>
        [Inject]
        public EntityManager Entities{ get; private set; }
        [Inject]
        public Camera Camera { get; private set; }

        /// <summary>
        /// Horizontal force to applu.
        /// </summary>
        public float HorizontalForce = 1f;

        /// <summary>
        /// Name of axis to use to control.
        /// </summary>
        private const string AXIS_NAME = "Horizontal";

        /// <summary>
        /// Called every frame.
        /// </summary>
        /// <param name="dt"></param>
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

            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.Weapons.Fire();
            }
        }
    }
}