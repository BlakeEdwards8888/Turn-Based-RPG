using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RPG.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [Range(1,20)]
        [SerializeField] int startingLevel = 1;
        [SerializeField] ProgressionTable progressionTable;

        int currentLevel;

        private void Awake()
        {
            currentLevel = CalculateLevel();
        }

        public int GetLevel()
        {
            return CalculateLevel();
        }

        public float GetStat(Stat stat)
        {
            float percentageBonus = 0;

            foreach(IStatModifier statModifier in GetComponents<IStatModifier>())
            {
                percentageBonus += statModifier.GetPercentageBonus(stat);
            }

            float multiplierBonus = 1 + (percentageBonus / 100);

            float modifiedStat = Mathf.Floor(Mathf.Max(1, progressionTable.GetStat(stat, CalculateLevel()) * multiplierBonus));

            return modifiedStat;
        }

        private int CalculateLevel()
        {
            Experience experience = GetComponent<Experience>();
            if (experience == null) return startingLevel;

            float currentXP = experience.GetPoints();
            int penultimateLevel = progressionTable.GetLevelCount(Stat.ExperienceToLevelUp);
            for (int level = 1; level <= penultimateLevel; level++)
            {
                float XPToLevelUp = progressionTable.GetStat(Stat.ExperienceToLevelUp, level);
                if (XPToLevelUp > currentXP)
                {
                    return level;
                }
            }

            return penultimateLevel + 1;
        }
    }
}
