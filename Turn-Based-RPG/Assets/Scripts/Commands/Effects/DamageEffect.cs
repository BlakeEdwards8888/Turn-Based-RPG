using RPG.Combat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Commands.Effects
{
    [CreateAssetMenu(fileName = "New Damage Effect", menuName = "Effect/Damage/Damage Effect")]
    public class DamageEffect : EffectStrategy
    {
        [SerializeField] protected float baseDamage;

        public override IEnumerator Execute(CommandData commandData)
        {
            commandData.target.GetComponent<Health>().TakeDamage(CalculateDamage(commandData));
            yield return null;
        }

        protected virtual float CalculateDamage(CommandData commandData)
        {
            return baseDamage;
        }

        public float GetDamage()
        {
            return baseDamage;
        }
    }
}
