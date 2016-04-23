﻿using Ninject;

namespace Space.Client
{
    public class CombatState : GameState
    {
        [Inject]
        public GameStateController States { get; private set; }
        [Inject]
        public InputController Input { get; private set; }

        public override void Enter()
        {
            base.Enter();

            Input.State = Input.Combat;
        }

        public override void DeltaUpdate(float dt)
        {
            base.DeltaUpdate(dt);

            Input.DeltaUpdate(dt);
        }

        public override IAsyncToken<IState> Exit()
        {
            return base.Exit();
        }
    }
}