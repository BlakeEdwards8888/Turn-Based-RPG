using UnityEngine;
using System.Collections;

namespace RPG.Utils
{
    public interface IPredicateEvaluator
    {
        bool? Evaluate(string predicate, string[] parameters);
    }
}
