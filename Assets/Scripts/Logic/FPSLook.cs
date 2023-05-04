using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Kozar.Science
{
    internal class FPSLook : Input
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
            InitiliazeSettings();
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

        private void InitiliazeSettings()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        private void Look()
        {
            var sensitivityX = playerControllerData.SensitivityX;
            var sensitivityY = playerControllerData.SensitivityY;

            var mouseX = MouseX * Time.deltaTime * sensitivityX;
            
            var mouseY = MouseY * Time.deltaTime * sensitivityY;
            
            _yRot += mouseX;
            
            _xRot -= mouseY;
            
            _xRot = Mathf.Clamp(_xRot, -90f, 90f);
            
            transform.localRotation = Quaternion.Euler(_xRot, _yRot, 0f);
            orientationTransform.localRotation = Quaternion.Euler(0f, _yRot, 0f);
        }

        #endregion
    }
}

