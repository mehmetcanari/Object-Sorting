using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kozar.Science
{
    public class UIManager : MonoBehaviour
    {
        #region PRIVATE FIELDS

        [SerializeField] private GameScoreHandler gameScoreHandler;
        [SerializeField] private StateManager stateManager;
        [SerializeField] private TextMeshProUGUI pointText;
        [SerializeField] private GameObject endPanel;

        public Action OnEndGame;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            OnEndGame += EnableEndPanel;
            OnEndGame += ShowPoint;
            OnEndGame += EnableCursor;
            OnEndGame += EndState;
        }

        #endregion
        
        #region PRIVATE METHODS

        private void EnableEndPanel() => endPanel.SetActive(true);

        private void ShowPoint() => pointText.SetText("Puan: " + gameScoreHandler.GetPoint);
        
        public void EndState() => stateManager.GameState = GameState.End;
        
        private void EnableCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        #endregion
    }
}