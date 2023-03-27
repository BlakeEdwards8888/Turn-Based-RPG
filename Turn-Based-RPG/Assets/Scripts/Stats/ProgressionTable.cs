using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Stats
{
    [CreateAssetMenu(fileName = "New Progression Table", menuName = "Progression Table")]
    public class ProgressionTable : ScriptableObject
    {
        [SerializeField] StatProgression[] statProgressions;

        Dictionary<Stat, float[]> progressionDict = null;

        public float GetStat(Stat stat, int level)
        {
            if (progressionDict == null) BuildProgressionDict();

            if (!progressionDict.ContainsKey(stat))
            {
                return 1;
            }

            float[] levels = progressionDict[stat];

            if(levels.Length == 0)
            {
                return 1;
            }

            if(levels.Length < level)
            {
                return levels[levels.Length - 1];
            }

            return levels[level - 1];
        }

        private void BuildProgressionDict()
        {
            if (progressionDict != null) return;

            progressionDict = new Dictionary<Stat, float[]>();

            foreach(StatProgression statProgression in statProgressions)
            {
                progressionDict[statProgression.stat] = statProgression.levels;
            }
        }

        public int GetLevelCount(Stat stat)
        {
            if (progressionDict == null) BuildProgressionDict();

            return progressionDict[stat].Length;
        }

        [System.Serializable]
        struct StatProgression
        {
            public Stat stat;
            public float[] levels;
        }
    }
}
