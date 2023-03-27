using RPG.Stats;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.StatusConditions
{
    [CreateAssetMenu(fileName = "New Stat Modifier Status", menuName ="Status Conditon/Stat Modifier Status")]
    public class StatModifierStatus : StatusData
    {
        [SerializeField] Stat stat;
        [SerializeField] float percentageBonus;

        public Stat GetStat()
        {
            return stat;
        }

        public float GetPercentageBonus()
        {
            return percentageBonus; 
        }
    }
}
