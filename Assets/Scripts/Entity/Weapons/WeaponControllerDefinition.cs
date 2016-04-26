using UnityEngine;

namespace Space.Client
{
    [CreateAssetMenu(fileName = "New_WeaponController", menuName = "WeaponController")]
    public class WeaponControllerDefinition : ScriptableObject
    {
        public WeaponDefinition[] Weapons;
    }
}