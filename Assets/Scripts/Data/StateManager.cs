using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kozar.Science
{
    [CreateAssetMenu(fileName = "State Manager Provider", menuName = "State Provider", order = 0)]
    public class StateManager : ScriptableObject
    {
        #region PUBLIC FIELDS

        [ReadOnly] public GameState gameState;

        #endregion
        
        #region PUBLIC PROPERTIES
        
        public GameState GameState
        {
            get => gameState;
            set => gameState = value;
        }
        
        #endregion

        #region PUBLIC METHODS

        public void SetGameState(GameState gameState)
        {
            GameState = gameState;
        }

        #endregion

    }

    public enum GameState
    {
        Play,
        End
    }
}