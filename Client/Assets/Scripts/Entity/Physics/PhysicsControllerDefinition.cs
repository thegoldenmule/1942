using UnityEngine;

namespace Space.Client
{
    [CreateAssetMenu(fileName = "New_Physcs", menuName = "Physics")]
    public class PhysicsControllerDefinition : ScriptableObject
    {
        public int Iterations = 4;
        public float Mass = 1;
        public float Drag = 100;
    }
}