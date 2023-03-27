using RPG.Stats;
using UnityEngine;

namespace RPG.Commands.Effects
{
    [CreateAssetMenu(fileName = "New Physical Damage Effect", menuName = "Effect/Damage/Physical Damage Effect")]
    public class PhysicalDamageEffect : DamageEffect
    {
        protected override float CalculateDamage(CommandData commandData)
        {
            float attackStat = commandData.user.GetComponent<BaseStats>().GetStat(Stat.Attack);
            float defenseStat = commandData.target.GetComponent<BaseStats>().GetStat(Stat.Defense);

            return Mathf.Floor(baseDamage * (attackStat / defenseStat));
        }
    }
}
