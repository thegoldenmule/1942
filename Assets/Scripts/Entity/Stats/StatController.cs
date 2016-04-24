using System.Collections.Generic;
using UnityEngine;

namespace Space.Client
{
    public enum StatType
    {
        Health,
        Speed,
        Damage
    }

    [CreateAssetMenu(fileName = "New_Stats", menuName = "StatsController")]
    public class StatController : ScriptableObject
    {
        public List<Stat> Stats = new List<Stat>();

        public Stat Stat(StatType type)
        {
            for (int i = 0, len = Stats.Count; i < len; i++)
            {
                if (Stats[i].Type == type)
                {
                    return Stats[i];
                }
            }

            var stat = new Stat
            {
                Type = type
            };
            Stats.Add(stat);

            return stat;
        }
    }
}
