using UnityEngine;
using UnityEngine.Serialization;

namespace Kozar.Science
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "Data", order = 0)]
    public class PlayerControllerData : ScriptableObject
    {
        #region INSPECTOR FIELDS

        [SerializeField] private float characterSpeed;
        [SerializeField] private float sensitivityX;
        [SerializeField] private float sensitivityY;

        #endregion

        #region PUBLIC PROPERTIES

        public float CharacterSpeed => characterSpeed;
        public float SensitivityX => sensitivityX;
        
        public float SensitivityY => sensitivityY;

        #endregion
    }
}