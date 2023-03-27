using RPG.Stats;
using RPG.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RPG.Combat
{
    public class Health : MonoBehaviour, IPredicateEvaluator
    {
        float currentHealth;
        BaseStats baseStats;

        public event Action onTakeDamage;

        Experience experience;

        void OnEnable()
        {
            experience = GetComponent<Experience>();
            if (experience == null) return;
            experience.onLevelUp += HealToFull;
        }

        private void Awake()
        {
            baseStats = GetComponent<BaseStats>();
            currentHealth = GetMaxHealth();
        }

        public void TakeDamage(float damage)
        {
            currentHealth = Mathf.Clamp(currentHealth - damage, 0, GetMaxHealth());
            onTakeDamage?.Invoke();
        }

        private void HealToFull()
        {
            float healAmount = GetMaxHealth() - currentHealth;
            TakeDamage(-healAmount);
        }

        public float GetMaxHealth()
        {
            return baseStats.GetStat(Stat.Health);
        }

        public float GetCurrentHealth()
        {
            return currentHealth;
        }

        public bool? Evaluate(string predicate, string[] parameters)
        {
            if(predicate == "HealthFull")
            {
                return currentHealth == GetMaxHealth();
            }

            return null;
        }

        public bool IsDead()
        {
            return currentHealth == 0;
        }

        void OnDisable()
        {
            if (experience == null) return;
            experience.onLevelUp -= HealToFull;
        }
    }
}
