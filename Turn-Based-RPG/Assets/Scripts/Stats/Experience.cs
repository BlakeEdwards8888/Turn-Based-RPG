using RPG.Core;
using RPG.UI;
using System;
using System.Collections;
using UnityEngine;

namespace RPG.Stats
{
    public class Experience : MonoBehaviour
    {
        [SerializeField] float experiencePoints = 0;

        public event Action onLevelUp;

        public float GetPoints()
        {
            return experiencePoints;
        }

        public IEnumerator GainExperience(float pointsToGain)
        {
            int startingLevel = GetComponent<BaseStats>().GetLevel();

            experiencePoints += pointsToGain;

            if (GetComponent<BaseStats>().GetLevel() > startingLevel)
            {
                onLevelUp?.Invoke();
                yield return FindObjectOfType<DialogueBox>().TypeText($"{GetComponent<Identifier>().GetDisplayName()} leveled up!", 0.5f);
            }
        }
    }
}
