using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kozar.Science
{
    public class ScriptableResetManager : MonoBehaviour
    {
        #region SHARED FIELDS

        [SerializeField] private StateManager stateManager;
        [SerializeField] private GameScoreHandler gameScoreHandler;

        #endregion
        
        #region UNITY METHODS

        private void Awake()
        {
            ResetPoint();
            ResetState();
        }

        #endregion
        
        #region PRIVATE METHODS
        
        private void ResetPoint() => gameScoreHandler.ResetPoint();

        private void ResetState() => stateManager.gameState = GameState.Play;

        #endregion
    }
}