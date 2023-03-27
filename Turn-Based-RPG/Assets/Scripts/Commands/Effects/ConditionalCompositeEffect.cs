using RPG.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Commands.Effects
{
    [CreateAssetMenu(fileName = "New Conditional Composite Effect", menuName = "Effect/Conditional Composite Effect")]
    public class ConditionalCompositeEffect : EffectStrategy
    {
        [SerializeField] Condition condition;
        [SerializeField] List<EffectStrategy> effects = new List<EffectStrategy>();

        public override IEnumerator Execute(CommandData commandData)
        {
            IEnumerable<IPredicateEvaluator> evaluators = commandData.target.GetComponents<IPredicateEvaluator>();

            if (condition.Check(evaluators))
            {
                foreach(EffectStrategy effect in effects)
                {
                    yield return effect.Execute(commandData);
                }
            }
        }
    }
}
