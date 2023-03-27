using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Commands
{
    public class CommandPool : MonoBehaviour
    {
        [SerializeField] protected List<Command> commands = new List<Command>();

        public void AddCommand(Command command)
        {
            commands.Add(command);
        }

        public void RemoveCommand(Command command)
        {
            commands.Remove(command);
        }

        public void GetCommand()
        {

        }

        public List<Command> GetAllCommands()
        {
            return commands;
        }

        public virtual void CommandExecutionCallback(Command command)
        {
            if (command.IsConsumable())
            {
                RemoveCommand(command);
            }
        }
    }
}
