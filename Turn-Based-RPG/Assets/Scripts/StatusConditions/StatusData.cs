using RPG.Commands;
using RPG.Commands.Effects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.StatusConditions
{
    public abstract class StatusData: ScriptableObject
    {
        [SerializeField] string statusCode;
        [SerializeField] List<EffectStrategy> recoveryEffects = new List<EffectStrategy>();

        public IEnumerator Recover(CommandData commandData)
        {
            foreach (EffectStrategy effect in recoveryEffects)
            {
                yield return effect.Execute(commandData);
            }
        }

        public string GetStatusCode()
        {
            return statusCode;
        }
    }
}
