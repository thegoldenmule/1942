using UnityEngine;

namespace Space.Client
{
    [CreateAssetMenu(fileName = "New_Weapon", menuName = "Weapon")]
    public class WeaponDefinition : ScriptableObject
    {
        public Projectile Prefab;
        public float Damage;
    }
}