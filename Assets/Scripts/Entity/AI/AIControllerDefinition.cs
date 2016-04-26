using UnityEngine;

namespace Space.Client
{
    [CreateAssetMenu(fileName = "New_AI", menuName = "AI")]
    public class AIControllerDefinition : ScriptableObject
    {
        public enum AIType
        {
            Null,
            Enemy
        }

        public AIType Type;

        public float AttackSpeedSeconds = 3f;
    }
}