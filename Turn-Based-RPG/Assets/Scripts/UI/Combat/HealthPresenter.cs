using RPG.Combat;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.UI.Combat
{
    public class HealthPresenter : MonoBehaviour
    {
        [SerializeField] Health health;
        [SerializeField] Slider healthBar;
        [SerializeField] TMP_Text healthText;

        private void OnEnable()
        {
            health.onTakeDamage += UpdateDisplay;
        }

        private void Start()
        {
            UpdateDisplay();
        }

        void UpdateDisplay()
        {
            healthBar.maxValue = health.GetMaxHealth();
            healthBar.value = health.GetCurrentHealth();
            healthText.text = $"{health.GetCurrentHealth()}/{health.GetMaxHealth()}";
        }

        private void OnDisable()
        {
            health.onTakeDamage -= UpdateDisplay;
        }
    }
}
