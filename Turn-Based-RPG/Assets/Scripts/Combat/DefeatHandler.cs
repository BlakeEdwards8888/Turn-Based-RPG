
using RPG.Core;
using RPG.Rewards;
using RPG.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class DefeatHandler : MonoBehaviour
    {
        [SerializeField] string defeatMessage;

        public void OnDefeated()
        {
            StartCoroutine(DefeatCoroutine());
        }

        private IEnumerator DefeatCoroutine()
        {
            yield return FindObjectOfType<DialogueBox>().TypeText(ParseMessage(defeatMessage), 0.5f);

            RewardsGiver rewardsGiver = GetComponent<RewardsGiver>();

            if (rewardsGiver == null) yield break;

            yield return rewardsGiver.GiveRewards();

            yield return null;
        }

        private string ParseMessage(string message)
        {
            string result = message;
            result = result.Replace("$This", GetComponent<Identifier>().GetDisplayName());
            return result;
        }
    }
}
