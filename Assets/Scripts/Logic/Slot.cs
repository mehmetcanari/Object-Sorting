using UnityEngine;

namespace Kozar.Science
{
    public class Slot : MonoBehaviour
    {
        #region INSPECTOR FIELDS

        public global::Item item;
        
        public bool isEmpty;

        #endregion

        #region PUBLIC PROPERTIES

        public bool IsEmpty => isEmpty;

        #endregion

        #region PUBLIC METHODS

        public void SetItem(global::Item item)
        {
            this.item = item;
            isEmpty = false;
            item.isPlaced = true;
            item.transform.parent = transform;
        }
        
        public void RemoveItem(global::Item item)
        {
            this.item = null;
            isEmpty = true;
            item.isPlaced = false;
            item.transform.parent = null;
        }

        #endregion
    }
}