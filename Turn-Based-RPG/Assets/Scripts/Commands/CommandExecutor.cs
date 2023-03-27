using RPG.Combat;
using RPG.StatusConditions;
using RPG.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Commands
{
    public class CommandExecutor : MonoBehaviour
    {
        [SerializeField] GameObject target;

        public void ExecuteCommand(Command command, Action executionCallback)
        {
            StatusCondition statusConditon = GetComponent<StatusCondition>();

            if (statusConditon.TurnInterrupted())
            {
                StartCoroutine(statusConditon.OnCommandExecution(FindObjectOfType<TurnShifter>().ShiftTurns));
                return;
            }
           
            CommandData commandData = new CommandData(gameObject, GetCommandTarget(command), command);

            StartCoroutine(command.Use(commandData, () => { 
                FindObjectOfType<TurnShifter>().ShiftTurns();
                executionCallback?.Invoke();
            }));
        }

        public GameObject GetCommandTarget(Command command)
        {
            return command.TargetsSelf() ? gameObject : target;
        }
    }
}
