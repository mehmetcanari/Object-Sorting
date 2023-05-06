using UnityEngine;

namespace Kozar.Science
{
    public class Slot : MonoBehaviour
    {
        #region INSPECTOR FIELDS

        public Item item;
        
        public bool isEmpty;

        #endregion

        #region PUBLIC PROPERTIES

        public bool IsEmpty => isEmpty;

        #endregion

        #region PUBLIC METHODS

        public void SetItem(Item item)
        {
            this.item = item;
            isEmpty = false;
            item.isPlaced = true;
            item.transform.parent = transform;
            item.PreviousSlot = this;
            item.Slot = this;
        }
        
        public void RemoveItem(Item item)
        {
            this.item = null;
            isEmpty = true;
            item.isPlaced = false;
            item.transform.parent = null;
            item.Slot = null;
        }

        #endregion
    }
}