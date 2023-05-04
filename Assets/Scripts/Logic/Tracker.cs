using System;
using UnityEngine;

namespace Kozar.Science
{
    public class Tracker : MonoBehaviour
    {
        #region INSPECTOR FIELDS

        [SerializeField] private Transform targetTransform;
        [SerializeField] private Vector3 offset;

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
            transform.position = targetTransform.position + offset;
        }

        #endregion
    }
}