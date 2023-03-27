using RPG.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Commands.Effects
{
    [CreateAssetMenu(fileName = "New Percentage Damage Effect", menuName = "Effect/Damage/Percentage Damage Effect")]
    public class PercentageDamageEffect : DamageEffect
    {
        protected override float CalculateDamage(CommandData commandData)
        {
            float healthMultiplier = baseDamage / 100;
            return Mathf.Floor(commandData.target.GetComponent<Health>().GetMaxHealth() * healthMultiplier);
        }
    }
}
