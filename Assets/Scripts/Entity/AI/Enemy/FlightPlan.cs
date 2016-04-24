using System;

namespace Space.Client
{
    [Serializable]
    public class FlightPlan
    {
        public FlightLeg[] Legs = new FlightLeg[0];
    }
}