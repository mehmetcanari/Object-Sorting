using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Kozar.Science
{
    internal class FPSLook : MonoBehaviour
    {
        #region SHARED FIELDS

        [SerializeField] private PlayerControllerData playerControllerData;
        [SerializeField] private StateManager stateManager;

        #endregion
        
        #region PRIVATE FIELDS
        
        [SerializeField] private Transform orientationTransform;
        private float _xRot;
        private float _yRot;

        #endregion

        #region UNITY METHODS

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            switch (stateManager.GameState)
            {
                case GameState.Play:
                    Look();
                    break;
            }
        }
        

        #endregion

        #region PRIVATE METHODS

        private void Look()
        {
            var sensitivityX = playerControllerData.SensitivityX;
            var sensitivitY = playerControllerData.SensitivityY;
            
            var mouseX = UnityEngine.Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX;
            var mouseY = UnityEngine.Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivitY;
            
            _yRot += mouseX;
            
            _xRot -= mouseY;
            
            _xRot = Mathf.Clamp(_xRot, -90f, 90f);
            
            transform.localRotation = Quaternion.Euler(_xRot, _yRot, 0f);
            orientationTransform.localRotation = Quaternion.Euler(0f, _yRot, 0f);
        }

        #endregion
    }
}

