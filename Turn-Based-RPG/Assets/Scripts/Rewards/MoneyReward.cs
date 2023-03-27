using RPG.Core;
using RPG.Currency;
using RPG.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Rewards
{
    [CreateAssetMenu(fileName = "New Money Reward", menuName = "Reward/Money Reward")]
    public class MoneyReward : Reward
    {
        [SerializeField] float amount;

        public override IEnumerator GiveReward(GameObject target)
        {
            Wallet targetWallet = target.GetComponent<Wallet>();

            targetWallet.AdjustBalance(amount);

            yield return FindObjectOfType<DialogueBox>().TypeText($"{target.GetComponent<Identifier>().GetDisplayName()} got {amount} money.", 0.5f);
        }
    }
}
