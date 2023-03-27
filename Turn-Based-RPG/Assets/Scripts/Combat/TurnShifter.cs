using RPG.Stats;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RPG.Combat
{
    public class TurnShifter : MonoBehaviour
    {
        bool playerTurn = true;

        Stack<bool> round = new Stack<bool>();

        GameObject player, enemy;

        public UnityEvent startPlayerTurn;
        public UnityEvent startEnemyTurn;

        public UnityEvent onPlayerDefeated;
        public UnityEvent onEnemyDefeated;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.1f);
            ShiftTurns();
        }

        public void ShiftTurns()
        { 
            StartCoroutine(TurnShiftCoroutine());
        }

        private IEnumerator TurnShiftCoroutine()
        {
            yield return EndCurrentTurn(playerTurn ? 
                player.GetComponents<ITurnShiftNotificationReceiver>() : 
                enemy.GetComponents<ITurnShiftNotificationReceiver>());

            if (CheckWinCondition()) yield break;

            if (round.Count == 0) StackRound();

            playerTurn = round.Pop();

            yield return StartNextTurn();
        }

        IEnumerator EndCurrentTurn(IEnumerable<ITurnShiftNotificationReceiver> turnShiftNotifiers)
        {
            foreach (var endOfTurnReceiver in turnShiftNotifiers)
            {
                yield return endOfTurnReceiver.OnTurnEnded();
            }
        }

        IEnumerator StartNextTurn()
        {
            if (playerTurn)
            {
                foreach (var startOfTurnReceiver in player.GetComponents<ITurnShiftNotificationReceiver>())
                {
                    yield return startOfTurnReceiver.OnTurnStarted();
                }

                startPlayerTurn.Invoke();
            }
            else
            {
                foreach (var startOfTurnReceiver in enemy.GetComponents<ITurnShiftNotificationReceiver>())
                {
                    yield return startOfTurnReceiver.OnTurnStarted();
                }

                startEnemyTurn.Invoke();
            }
        }

        private void StackRound()
        {
            float playerSpeed = player.GetComponent<BaseStats>().GetStat(Stat.Speed);
            float enemySpeed = enemy.GetComponent<BaseStats>().GetStat(Stat.Speed);

            round.Push(playerSpeed < enemySpeed);
            round.Push(playerSpeed >= enemySpeed);
        }

        private bool CheckWinCondition()
        {
            if (player.GetComponent<Health>().IsDead())
            {
                onPlayerDefeated?.Invoke();
                return true;
            }

            if (enemy.GetComponent<Health>().IsDead())
            {
                onEnemyDefeated?.Invoke();
                return true;
            }

            return false;
        }

    }
}
