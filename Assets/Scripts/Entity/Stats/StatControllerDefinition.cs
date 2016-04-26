using System.Collections.Generic;
using UnityEngine;

namespace Space.Client
{
    [CreateAssetMenu(fileName = "New_Stats", menuName = "Stats")]
    public class StatControllerDefinition : ScriptableObject
    {
        public List<StatDefinition> Stats = new List<StatDefinition>();
    }
}