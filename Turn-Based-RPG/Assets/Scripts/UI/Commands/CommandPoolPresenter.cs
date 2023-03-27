using RPG.Commands;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.UI.Commands
{
    public class CommandPoolPresenter: MonoBehaviour
    {
        [SerializeField] CommandPresenter commandPresenterPrefab;
        [SerializeField] Transform content;
        [SerializeField] GameObject dialogueBox;
        [SerializeField] CommandInfoPresenter commandInfoPresenter;

        private void OnEnable()
        {
            GetComponentInChildren<ScrollRect>().verticalNormalizedPosition = 1;
            commandInfoPresenter.EmptyText();
        }

        public void SetCommandPool(CommandPool commandPool)
        {
            foreach(Transform child in content)
            {
                Destroy(child.gameObject);
            }

            foreach(Command command in commandPool.GetAllCommands())
            {
                CommandPresenter commandPresenter = Instantiate(commandPresenterPrefab, content);
                commandPresenter.Setup(command, commandInfoPresenter, ()=> { commandPool.CommandExecutionCallback(command); });
            }
        }



    }
}
