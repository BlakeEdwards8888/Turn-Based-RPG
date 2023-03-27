using RPG.Elements;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RPG.UI.Commands
{
    public class CommandInfoPresenter : MonoBehaviour
    {
        [SerializeField] TMP_Text descriptionText;
        [SerializeField] TMP_Text elementText;
        [SerializeField] TMP_Text damageText;

        public void EmptyText()
        {
            descriptionText.text = "";
            elementText.text = "";
            damageText.text = "";
        }

        public void SetText(string description, string element, float damage)
        {
            descriptionText.text = description;
            elementText.text = element.ToLower();
            damageText.text = damage > 0 ? damage.ToString() : "";
        }
    }
}
