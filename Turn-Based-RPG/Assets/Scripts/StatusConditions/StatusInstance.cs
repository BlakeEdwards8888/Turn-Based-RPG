using RPG.Commands;
using RPG.Stats;
using System;
using System.Collections;

namespace RPG.StatusConditions
{
    public class StatusInstance
    {
        StatusData statusData;
        CommandData context;
        int duration;

        int turnsSinceInstantiated = 0;

        public event Action<StatusInstance> onDurationFinished;

        public StatusInstance(StatusData statusData, CommandData context, int duration)
        {
            this.statusData = statusData;
            this.context = context;
            this.duration = duration;
        }

        public IEnumerator OnTurnEnded()
        {
            EndOfTurnStatus endOfTurnStatus = statusData as EndOfTurnStatus;

            if (endOfTurnStatus != null)
            {
                yield return endOfTurnStatus.OnTurnEnded(context);
            }

            turnsSinceInstantiated++;

            if (turnsSinceInstantiated == duration)
            {
                onDurationFinished(this);
            }
        }

        public bool InterruptsTurn()
        {
            CommandInterruptionStatus commandInterruptionStatus = statusData as CommandInterruptionStatus;

            if (commandInterruptionStatus == null) return false;

            return commandInterruptionStatus.InterruptsTurn();
        }

        public IEnumerator Recover()
        {
            yield return statusData.Recover(context);
        }

        public IEnumerator OnCommandExecution()
        {
            CommandInterruptionStatus commandInterruptionStatus = statusData as CommandInterruptionStatus;
            
            if (commandInterruptionStatus == null) yield break;
            
            yield return commandInterruptionStatus.OnCommandExecution(context);
        }

        public StatusData GetStatusData()
        {
            return statusData;
        }

        public float GetPercentageBonus(Stat stat)
        {
            StatModifierStatus statModifierStatus = statusData as StatModifierStatus;

            if (statModifierStatus == null || statModifierStatus.GetStat() != stat) return 0;

            return statModifierStatus.GetPercentageBonus();
        }

        public bool IsStatus(string statusCode)
        {
            return statusData.GetStatusCode() == statusCode;
        }
    }
}
