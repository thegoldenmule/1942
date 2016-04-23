using System;
using System.Collections.Generic;

namespace Space.Client
{
    public enum StatType
    {
        Health,
        Speed,
        Damage
    }

    [Serializable]
    public class Stat
    {
        public StatType Type;

        public float Value;
    }

    [Serializable]
    public class StatController
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
