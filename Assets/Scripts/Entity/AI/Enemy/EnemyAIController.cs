using UnityEngine;

namespace Space.Client
{
    [CreateAssetMenu(fileName = "New_AI", menuName = "EnemyAIController")]
    public class EnemyAIController : AIController
    {
        public FlightPlan FlightPlan;
        public  AttackPlan AttackPlan;

        private float _elapsedSeconds = 0f;
    }
}
