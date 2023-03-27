using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class Identifier : MonoBehaviour
    {
        [SerializeField] string displayName;

        public string GetDisplayName()
        {
            return displayName;
        }
    }
}
