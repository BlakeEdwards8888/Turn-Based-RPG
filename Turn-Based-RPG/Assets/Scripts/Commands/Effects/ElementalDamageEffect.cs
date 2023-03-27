using RPG.Elements;
using RPG.Stats;
using System;
using UnityEngine;

namespace RPG.Commands.Effects
{
    [CreateAssetMenu(fileName = "New Elemental Damage Effect", menuName = "Effect/Damage/Elemental Damage Effect")]
    public class ElementalDamageEffect : DamageEffect
    {
        [SerializeField] Element element;

        protected override float CalculateDamage(CommandData commandData)
        {
            float magicAttackStat = commandData.user.GetComponent<BaseStats>().GetStat(Stat.MagicAttack);
            float magicDefenseStat = commandData.target.GetComponent<BaseStats>().GetStat(Stat.MagicDefense);

            float attackBonus = commandData.user.GetComponent<Affinities>().GetAttackBonus(element);
            float effectiveness = commandData.target.GetComponent<Affinities>().GetEffectiveness(element);

            return Mathf.Floor(baseDamage * attackBonus * effectiveness * (magicAttackStat / magicDefenseStat));
        }

        public string GetElement()
        {
            return element.ToString();
        }
    }
}
