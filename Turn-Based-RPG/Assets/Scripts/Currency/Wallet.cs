using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Currency
{
    public class Wallet : MonoBehaviour
    {
        float balance;

        public void AdjustBalance(float amount)
        {
            balance += amount;
        }
    }
}
