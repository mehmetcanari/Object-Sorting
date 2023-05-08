using System;
using UnityEngine;

namespace Kozar.Science
{
    public class CharacterMovement : MonoBehaviour
    {
        #region SHARED FIELDS

        [SerializeField] private PlayerControllerData playerControllerData;
        [SerializeField] private StateManager stateManager;
        [SerializeField] private ClickInputProvider clickInputProvider;
        #endregion
        
        #region INSPECTOR FIELDS
        
        [SerializeField] private Rigidbody characterRigidbody;
        [SerializeField] private Transform characterTransform;

        #endregion

        #region PRIVATE PROPERTIES

        private Vector3 LocalDirection => GetLocalDirection(characterTransform);

        #endregion

        #region UNITY METHODS

        private void Update()
        {
            switch (stateManager.GameState)
            {
                case GameState.Play:
                    MoveCharacter(characterRigidbody);
                    break;
            }
        }

        #endregion
        
        #region PRIVATE METHODS

        private void MoveCharacter(Rigidbody targetRigidbody)
        {
            var velocity = LocalDirection * playerControllerData.CharacterSpeed;
            
            targetRigidbody.velocity = velocity;
        }

        private Vector3 GetLocalDirection(Transform targetTransform)
        {
            var provider = clickInputProvider;
            
            var horizontal = provider.IsPressedHold(KeyCode.A) ? -1 : provider.IsPressedHold(KeyCode.D) ? 1 : 0;
            var vertical = provider.IsPressedHold(KeyCode.S) ? -1 : provider.IsPressedHold(KeyCode.W) ? 1 : 0;
            
            var direction = new Vector3(horizontal, 0, vertical);
            var velocity = direction * playerControllerData.CharacterSpeed;
            
            return targetTransform.TransformDirection(velocity);
        }

        #endregion
    }
}