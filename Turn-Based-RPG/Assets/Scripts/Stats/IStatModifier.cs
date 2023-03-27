using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Stats {
    public interface IStatModifier
    {
        public abstract float GetPercentageBonus(Stat stat);
    }
}
