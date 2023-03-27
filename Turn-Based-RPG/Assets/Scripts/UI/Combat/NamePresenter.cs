using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RPG.UI.Combat
{
    public class NamePresenter : MonoBehaviour
    {
        [SerializeField] Identifier identifier;
        [SerializeField] TMP_Text nameText;

        private void Start()
        {
            UpdateDisplay();
        }

        void UpdateDisplay()
        {
            nameText.text = identifier.GetDisplayName();
        }
     }
}
