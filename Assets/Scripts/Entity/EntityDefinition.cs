using UnityEngine;

namespace Space.Client
{
    [CreateAssetMenu(fileName = "New_Entity", menuName = "Entity")]
    public class EntityDefinition : ScriptableObject
    {
        public GameEntity Prefab;

        public AIControllerDefinition AI;
        public StatControllerDefinition Stats;
        public PhysicsControllerDefinition Physics;
    }
}