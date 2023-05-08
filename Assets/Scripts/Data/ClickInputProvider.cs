using UnityEngine;

namespace Kozar.Science
{
    [CreateAssetMenu(fileName = "Input Provider", menuName = "Provider", order = 0)]
    public class ClickInputProvider : ScriptableObject, IKeyboardInputProvider, IMouseInputProvider
    {
        #region PUBLIC METHODS

        public bool IsPressedHold(KeyCode keyCode)
        {
            if (UnityEngine.Input.GetKey(keyCode)) { return true; }
            return false;
        }

        public bool IsClicked()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0)) { return true; }
            return false;
        }
        
        public bool IsReleased()
        {
            if (UnityEngine.Input.GetMouseButtonUp(0)) { return true; }
            return false;
        }

        #endregion

        #region DERIVABLE PROPERTIES

        public float MouseX => UnityEngine.Input.GetAxisRaw("Mouse X");
        
        public float MouseY => UnityEngine.Input.GetAxisRaw("Mouse Y");

        #endregion
    }

    public interface IMouseInputProvider
    {
        public float MouseX { get; }
    }

    public interface IKeyboardInputProvider
    {
        public bool IsPressedHold(KeyCode keyCode);
        
        public bool IsClicked();
        
        public bool IsReleased();
    }
}