using RPG.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.AI
{
    public class AIBattleController : MonoBehaviour
    {

        public void SelectCommand()
        {
            CommandPool commandPool = GetComponent<CommandPool>();

            //logic for selecting a command

            List<Command> commands = commandPool.GetAllCommands();

            int index = Random.Range(0, commands.Count);

            GetComponent<CommandExecutor>().ExecuteCommand(commands[index], () => { commandPool.CommandExecutionCallback(commands[index]); });
        }
    }
}
