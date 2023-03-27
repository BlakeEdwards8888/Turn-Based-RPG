using RPG.Combat;
using RPG.Commands;
using RPG.Stats;
using RPG.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.StatusConditions
{
    public class StatusCondition : MonoBehaviour, ITurnShiftNotificationReceiver, IStatModifier, IPredicateEvaluator
    {
        List<StatusInstance> activeStatuses = new List<StatusInstance>();
        List<StatusInstance> statusesToRemove = new List<StatusInstance>();

        public event Action<StatusData> onStatusAdded;
        public event Action<StatusData> onStatusRemoved;

        public bool TurnInterrupted()
        {
            foreach(StatusInstance status in activeStatuses)
            {
                if (status.InterruptsTurn()) return true;
            }

            return false;
        }

        public IEnumerator OnCommandExecution(Action finished)
        {
            foreach (StatusInstance statusInstance in activeStatuses)
            {
                yield return statusInstance.OnCommandExecution();
            }

            finished();
        }

        public void AddStatus(StatusData statusData, CommandData context, int duration)
        {
            StatusInstance statusInstance = new StatusInstance(statusData, context, duration);
            activeStatuses.Add(statusInstance);
            statusInstance.onDurationFinished += QueueStatusToRemove;
            onStatusAdded?.Invoke(statusData);
        }

        void QueueStatusToRemove(StatusInstance status)
        {
            statusesToRemove.Add(status);
        }

        public float GetPercentageBonus(Stat stat)
        {
            float percentageBonus = 0;

            foreach(StatusInstance status in activeStatuses)
            {
                percentageBonus += status.GetPercentageBonus(stat);
            }

            return percentageBonus;
        }

        public bool? Evaluate(string predicate, string[] parameters)
        {
            if(predicate == "HasStatus")
            {
                foreach(StatusInstance status in activeStatuses)
                {
                    if (status.IsStatus(parameters[0])) return true;
                }
            }

            return null;
        }

        public IEnumerator OnTurnStarted()
        {
            foreach (StatusInstance status in statusesToRemove)
            {
                yield return status.Recover();
                activeStatuses.Remove(status);
                onStatusRemoved?.Invoke(status.GetStatusData());
            }

            statusesToRemove.Clear();
        }

        public IEnumerator OnTurnEnded()
        {
            foreach (StatusInstance statusInstance in activeStatuses)
            {
                yield return statusInstance.OnTurnEnded();
            }
        }
    }
}
