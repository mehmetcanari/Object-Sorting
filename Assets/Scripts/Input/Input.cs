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

        #region DERIVABLE PROPERTIES

        protected float MouseX => UnityEngine.Input.GetAxisRaw("Mouse X");
        protected float MouseY => UnityEngine.Input.GetAxisRaw("Mouse Y");

        #endregion
    }
}

