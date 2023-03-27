using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Elements
{
    public class Affinities : MonoBehaviour
    {
        public const float strongAttackMultiplier = 1.5f;
        public const float weakAttackMultiplier = 0.75f;
        public const float weaknessMultiplier = 2;
        public const float resistanceMultiplier = 0.5f;

        [SerializeField] List<Element> weaknesses = new List<Element>();
        [SerializeField] List<Element> resistances = new List<Element>();

        public float GetAttackBonus(Element element)
        {
            if (weaknesses.Contains(element))
            {
                return weakAttackMultiplier;
            }

            if (resistances.Contains(element))
            {
                return strongAttackMultiplier;
            }

            return 1;
        }

        public float GetEffectiveness(Element element)
        {
            if (weaknesses.Contains(element))
            {
                return weaknessMultiplier;
            }

            if (resistances.Contains(element))
            {
                return resistanceMultiplier;
            }

            return 1;
        }
    }
}
