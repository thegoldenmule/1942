using UnityEngine;

namespace Space.Client
{
    [CreateAssetMenu(fileName = "New_Entity", menuName = "Entity")]
    public class EntityDefinition : ScriptableObject
    {
        public Bounds Bounds;
        public GameEntity Prefab;

        public int Score;

        public AIControllerDefinition AI;
        public StatControllerDefinition Stats;
        public PhysicsControllerDefinition Physics;
        public WeaponControllerDefinition Weapons;
    }
}