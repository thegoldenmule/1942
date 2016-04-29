using System;
using UnityEngine;

namespace Space.Client
{
    public class Stat
    {
        private readonly StatDefinition _definition;
        private float _value; 

        public StatDefinition Definition
        {
            get { return _definition; }
        }

        public float Initial
        {
            get { return _definition.Value; }
        }

        public float Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (Mathf.Approximately(value, _value))
                {
                    return;
                }

                var oldValue = value;
                _value = value;

                if (null != OnUpdated)
                {
                    OnUpdated(this, oldValue, _value);
                }
            }
        }

        public event Action<Stat, float, float> OnUpdated; 

        public Stat(StatDefinition definition)
        {
            _definition = definition;

            Value = _definition.Value;
        }
    }
}