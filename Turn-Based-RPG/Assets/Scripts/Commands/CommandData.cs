using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Commands
{
    public class CommandData
    {
        public GameObject user;
        public GameObject target;
        public Command command;

        public CommandData(GameObject user, GameObject target, Command command)
        {
            this.user = user;
            this.target = target;
            this.command = command;
        }
    }
}
