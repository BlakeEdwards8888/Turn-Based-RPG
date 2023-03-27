using RPG.Core;
using RPG.Stats;
using RPG.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Rewards
{
    [CreateAssetMenu(fileName = "New Experience Reward", menuName = "Reward/Experience Reward")]
    public class ExperienceReward : Reward
    {
        public override IEnumerator GiveReward(GameObject target)
        {
            float reward = GameObject.FindWithTag("Enemy").GetComponent<BaseStats>().GetStat(Stat.ExperienceReward);

            yield return FindObjectOfType<DialogueBox>().TypeText($"{target.GetComponent<Identifier>().GetDisplayName()} earned {reward} experience points.", 0.5f);


            yield return target.GetComponent<Experience>().GainExperience(reward);
        }
    }
}
