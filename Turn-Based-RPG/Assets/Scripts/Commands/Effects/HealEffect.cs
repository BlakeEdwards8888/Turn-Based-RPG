using RPG.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Commands.Effects
{
    [CreateAssetMenu(fileName = "New Healing Effect", menuName = "Effect/Heal Effect")]
    public class HealEffect : EffectStrategy
    {
        [SerializeField] float healAmount;

        public override IEnumerator Execute(CommandData commandData)
        {
            commandData.target.GetComponent<Health>().TakeDamage(-healAmount);
            yield return null;
        }
    }
}
