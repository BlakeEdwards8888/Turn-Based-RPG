using RPG.Commands;
using RPG.Commands.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.StatusConditions
{
    [CreateAssetMenu(fileName = "New Command Interruption Status", menuName = "Status Conditon/Turn Interruption Status")]
    public class CommandInterruptionStatus : StatusData
    {
        [Range(0, 1)]
        [SerializeField] float turnInterruptionChance;
        [SerializeField] List<EffectStrategy> effects = new List<EffectStrategy>();

        public bool InterruptsTurn()
        {
            return Random.value < turnInterruptionChance;
        }

        public IEnumerator OnCommandExecution(CommandData commandData)
        {
            foreach (EffectStrategy effect in effects)
            {
                yield return effect.Execute(commandData);
            }
        }
    }
}
