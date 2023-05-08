using System;
using UnityEngine;

namespace Kozar.Science
{
    public class CharacterMovement : ClickInputHandler
    {
        #region SHARED FIELDS

        [SerializeField] private PlayerControllerData playerControllerData;
        [SerializeField] private StateManager stateManager;
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
            var horizontal = IsPressedHold(KeyCode.A) ? -1 : IsPressedHold(KeyCode.D) ? 1 : 0;
            var vertical = IsPressedHold(KeyCode.S) ? -1 : IsPressedHold(KeyCode.W) ? 1 : 0;
            
            var direction = new Vector3(horizontal, 0, vertical);
            var velocity = direction * playerControllerData.CharacterSpeed;
            
            return targetTransform.TransformDirection(velocity);
        }

        #endregion
    }
}