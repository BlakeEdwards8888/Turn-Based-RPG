using RPG.Core;
using RPG.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Commands.Effects
{
    [CreateAssetMenu(fileName = "New Text Effect", menuName = "Effect/Text Effect")]
    public class TextEffect : EffectStrategy
    {
        [SerializeField] string message;

        public override IEnumerator Execute(CommandData commandData)
        {
            yield return FindObjectOfType<DialogueBox>().TypeText(ParseMessage(commandData));
            yield return new WaitForSeconds(0.5f);
        }

        string ParseMessage(CommandData commandData)
        {
            string result = message;
            result = result.Replace("$User", commandData.user.GetComponent<Identifier>().GetDisplayName());
            result = result.Replace("$Target", commandData.target.GetComponent<Identifier>().GetDisplayName());
            result = result.Replace("$Command", commandData.command.GetDisplayName());
            return result;
        }
    }
}
