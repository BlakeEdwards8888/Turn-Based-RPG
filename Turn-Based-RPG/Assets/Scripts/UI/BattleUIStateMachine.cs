using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.UI
{

    public class BattleDisplayContext : MonoBehaviour
    {
        public GameObject commandSelectionPanel, textPanel, commandsListPanel;
        public virtual void SetState(BattleDisplayState newState) { }
    }

    public interface BattleDisplayState
    {
        public void ToCommandSelection(BattleDisplayContext context) { }
        public void ToTextPanel(BattleDisplayContext context) { }
        public void ToCommandsList(BattleDisplayContext context) { }
    }

    public class BattleUIStateMachine : BattleDisplayContext
    {
        BattleDisplayState currentState = new TextPanel();

        public void ToCommandSelection() => currentState.ToCommandSelection(this);

        public void ToTextPanel() => currentState.ToTextPanel(this);

        public void ToCommandsList() => currentState.ToCommandsList(this);

        public override void SetState(BattleDisplayState newState) 
        {
            currentState = newState;
        }
    }

    class CommandSelection : BattleDisplayState
    {
        public void ToTextPanel(BattleDisplayContext context) 
        {
            context.commandSelectionPanel.SetActive(false);
            context.textPanel.SetActive(true);
            context.SetState(new TextPanel());
        }
        public void ToCommandsList(BattleDisplayContext context) 
        {
            context.commandSelectionPanel.SetActive(false);
            context.commandsListPanel.SetActive(true);
            context.SetState(new CommandsList());
        }
    }

    class TextPanel : BattleDisplayState
    {
        public void ToCommandSelection(BattleDisplayContext context) 
        {
            context.textPanel.SetActive(false);
            context.commandSelectionPanel.SetActive(true);
            context.SetState(new CommandSelection());
        }

        public void ToCommandsList(BattleDisplayContext context) 
        {
            context.textPanel.SetActive(false);
            context.commandsListPanel.SetActive(true);
            context.SetState(new CommandsList());
        }
    }

    class CommandsList : BattleDisplayState
    {
        public void ToCommandSelection(BattleDisplayContext context) 
        {
            context.commandsListPanel.SetActive(false);
            context.commandSelectionPanel.SetActive(true);
            context.SetState(new CommandSelection());
        }
        public void ToTextPanel(BattleDisplayContext context) 
        {
            context.commandsListPanel.SetActive(false);
            context.textPanel.SetActive(true);
            context.SetState(new TextPanel());
        }
    }


}
