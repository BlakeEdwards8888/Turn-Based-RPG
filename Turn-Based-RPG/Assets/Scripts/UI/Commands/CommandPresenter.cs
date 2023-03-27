using RPG.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RPG.UI.Commands
{
    public class CommandPresenter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] Command command;
        [SerializeField] TMP_Text nameText;

        CommandInfoPresenter commandInfoPresenter;
        Action executionCallback;

        public void Setup(Command command, CommandInfoPresenter commandInfoPresenter, Action executionCallback)
        {
            this.command = command;
            this.commandInfoPresenter = commandInfoPresenter;
            this.executionCallback = executionCallback;
            nameText.SetText(command.GetDisplayName());
        }

        public void ExecuteCommand()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            CommandExecutor commandExecutor = player.GetComponent<CommandExecutor>();

            BattleUIStateMachine battleUIStateMachine = FindObjectOfType<BattleUIStateMachine>();
            battleUIStateMachine.ToTextPanel();

            if (!command.CanUse(commandExecutor.GetCommandTarget(command)))
            {
                DialogueBox dialogueBox = FindObjectOfType<DialogueBox>();
                dialogueBox.StartTyping("Can't use that.", 1, battleUIStateMachine.ToCommandSelection);
                return;
            }

            commandExecutor.ExecuteCommand(command, executionCallback);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (commandInfoPresenter == null) return;
            commandInfoPresenter.SetText(command.GetDescription(), command.GetElement(), command.GetDamage());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (commandInfoPresenter == null) return;
            commandInfoPresenter.EmptyText();
        }
    }
}
