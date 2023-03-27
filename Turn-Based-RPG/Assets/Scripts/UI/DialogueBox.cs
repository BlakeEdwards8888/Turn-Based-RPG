using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RPG.UI
{
    public class DialogueBox : MonoBehaviour
    {
        [SerializeField] TMP_Text textBox;
        [SerializeField] float typeRate;

        public IEnumerator TypeText(string text, float displayTime = 0, Action finished = null)
        {
            textBox.SetText("");

            char[] charArray = text.ToCharArray();

            foreach (char c in charArray)
            {
                textBox.text += c;
                yield return new WaitForSeconds(typeRate);
            }

            yield return new WaitForSeconds(displayTime);

            finished?.Invoke();
        }

        public void StartTyping(string text, float displayTime = 0, Action finished = null)
        {
            StartCoroutine(TypeText(text, displayTime, finished));
        }

        public void StartTyping(string text)
        {
            StartCoroutine(TypeText(text));
        }

    }
}
