using RPG.Stats;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RPG.UI.Combat
{
    public class LevelPresenter : MonoBehaviour
    {
        [SerializeField] BaseStats baseStats;
        [SerializeField] TMP_Text levelText;

        Experience experience;

        void OnEnable()
        {
            experience = baseStats.GetComponent<Experience>();

            if (experience == null) return;

            experience.onLevelUp += UpdateDisplay;
        }

        private void Start()
        {
            UpdateDisplay();
        }

        void UpdateDisplay()
        {
            levelText.text = $"Lv{baseStats.GetLevel()}";
        }

        private void OnDisable()
        {
            if (experience == null) return;
            experience.onLevelUp -= UpdateDisplay;
        }
    }
}
