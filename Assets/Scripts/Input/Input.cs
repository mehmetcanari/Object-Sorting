using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kozar.Science
{
    public abstract class Input : MonoBehaviour
    {
        #region PUBLIC METHODS

        protected bool IsPressedHold(KeyCode keyCode)
        {
            if (UnityEngine.Input.GetKey(keyCode)) { return true; }
            return false;
        }

        #endregion
    }
}

