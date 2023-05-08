using System.Collections.Generic;
using UnityEngine;

namespace Kozar.Science
{
    [CreateAssetMenu(fileName = "Items", menuName = "Objects", order = 0)]
    public class ItemsData : ScriptableObject
    {
        #region INSPECTOR FIELDS

        public List<Item> items;

        #endregion
        
        #region PUBLIC PROPERTIES
        
        public List<Item> Items => items;

        #endregion
    }
}