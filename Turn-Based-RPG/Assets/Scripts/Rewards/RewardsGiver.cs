using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Rewards
{
    public class RewardsGiver : MonoBehaviour
    {
        [SerializeField] List<Reward> rewards = new List<Reward>();

        public IEnumerator GiveRewards()
        {
            GameObject player = GameObject.FindWithTag("Player");

            foreach (Reward reward in rewards)
            {
                yield return reward.GiveReward(player);
            }
        }
    }
}
