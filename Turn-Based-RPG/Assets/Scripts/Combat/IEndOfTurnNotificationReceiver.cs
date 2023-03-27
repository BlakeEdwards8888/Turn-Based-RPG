using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public interface ITurnShiftNotificationReceiver
    {
        public abstract IEnumerator OnTurnStarted();
        public abstract IEnumerator OnTurnEnded();        
    }
}
