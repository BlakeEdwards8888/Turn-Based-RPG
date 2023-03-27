using RPG.Commands;
using RPG.Commands.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.StatusConditions
{
    [CreateAssetMenu(fileName = "New End Of Turn Status", menuName = "Status Conditon/End Of Turn Status")]
    public class EndOfTurnStatus : StatusData
    {
        [SerializeField] List<EffectStrategy> effects = new List<EffectStrategy>();

        public IEnumerator OnTurnEnded(CommandData context)
        {
            foreach (EffectStrategy effect in effects)
            {
                yield return effect.Execute(context);
            }
        }
    }
}
