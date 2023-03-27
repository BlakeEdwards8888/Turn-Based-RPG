using RPG.Commands.Effects;
using RPG.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Commands
{
    [CreateAssetMenu(fileName = "New Command", menuName = "Command")]
    public class Command : ScriptableObject
    {
        [SerializeField] string displayName;
        [TextArea]
        [SerializeField] string description;
        [SerializeField] bool isConsumable;
        [SerializeField] bool targetsSelf;
        [SerializeField] List<EffectStrategy> effectStrategies = new List<EffectStrategy>();
        [SerializeField] Condition condition;

        public IEnumerator Use(CommandData commandData, Action finished)
        {
            foreach(EffectStrategy effectStrategy in effectStrategies)
            {
                yield return effectStrategy.Execute(commandData);
            }

            finished.Invoke();
        }

        public string GetDisplayName()
        {
            return displayName;
        }

        public string GetDescription()
        {
            return description;
        }

        public bool IsConsumable()
        {
            return isConsumable;
        }

        public bool CanUse(GameObject target)
        {
            IEnumerable<IPredicateEvaluator> evaluators = target.GetComponents<IPredicateEvaluator>();

            return condition.Check(evaluators);
        }

        public float GetDamage()
        {
            foreach(EffectStrategy effectStrategy in effectStrategies)
            {
                DamageEffect damageEffect = effectStrategy as DamageEffect;

                if(damageEffect != null)
                {
                    return damageEffect.GetDamage();
                }
            }

            return 0;
        }

        public string GetElement()
        {
            foreach(EffectStrategy effectStrategy in effectStrategies)
            {
                ElementalDamageEffect elementalStrategy = effectStrategy as ElementalDamageEffect;
                
                if(elementalStrategy != null)
                {
                    return elementalStrategy.GetElement();
                }
            }

            return "";
        }

        public bool TargetsSelf()
        {
            return targetsSelf;
        }
    }
}
