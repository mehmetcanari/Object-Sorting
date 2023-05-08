using System;
using UnityEngine;

namespace Kozar.Science
{
    public class ScriptableResetManager : MonoBehaviour
    {
        #region SHARED FIELDS

        [SerializeField] private StateManager stateManager;
        [SerializeField] private Point point;

        #endregion
        
        #region UNITY METHODS

        private void Awake()
        {
            ResetPoint();
            ResetState();
        }

        #endregion
        
        #region PRIVATE METHODS
        
        private void ResetPoint()
        {
            point.ResetPoint();
        }
        
        private void ResetState()
        {
            stateManager.gameState = GameState.Play;
        }
        
        #endregion
    }
}