using UnityEngine;

namespace Kozar.Science
{
    public class LevelManager : MonoBehaviour
    {
        #region PUBLIC METHODS

        public void ResetCurrentLevel()
        {
            var currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene.name);
        }

        #endregion
    }
}