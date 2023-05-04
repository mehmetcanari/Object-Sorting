using System;
using UnityEngine;

namespace Kozar.Science
{
    public class CameraTracker : MonoBehaviour
    {
        #region INSPECTOR FIELDS

        [SerializeField] private Transform targetTransform;

        #endregion
        
        #region UNITY METHODS

        private void Update()
        {
            TrackTarget();
        }

        #endregion

        #region PRIVATE METHODS

        private void TrackTarget()
        {
            transform.position = targetTransform.position;
        }

        #endregion
    }
}