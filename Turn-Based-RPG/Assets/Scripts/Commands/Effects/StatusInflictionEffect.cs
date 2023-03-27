using RPG.StatusConditions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Commands.Effects
{
    [CreateAssetMenu(fileName = "New Status Infliction Effect", menuName = "Effect/Status Infliction Effect")]
    public class StatusInflictionEffect : EffectStrategy
    {
        [SerializeField] StatusData statusData;
        [SerializeField] int duration;

        public override IEnumerator Execute(CommandData commandData)
        {
            commandData.target.GetComponent<StatusCondition>().AddStatus(statusData, commandData, duration);
            yield return null;
        }
    }
}
