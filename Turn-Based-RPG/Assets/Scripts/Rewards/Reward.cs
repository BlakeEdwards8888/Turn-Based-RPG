using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Rewards
{
    public abstract class Reward : ScriptableObject
    {
        public abstract IEnumerator GiveReward(GameObject target);
    }
}
