using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Commands.Effects
{
    public abstract class EffectStrategy : ScriptableObject
    {
        public abstract IEnumerator Execute(CommandData commandData);
    }
}
