using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kozar.Science
{
    public class ObjectsVault : MonoBehaviour, ITypeChecker
    {
        #region INSPECTOR FIELDS

        public List<Item> items;
        
        public SlotManagement slotManagement;

        #endregion
        
        #region PUBLIC METHODS
        
        public bool CheckAnySameType(Item item)
        {
            return items.Exists(x => x.type == item.type);
        }

        public int SlotCount => slotManagement.slots.Count;
        
        public bool IfSlotsAreFull => items.Count >= SlotCount;

        public bool CheckIfItemDesiredCategory(Item item, ItemCategory category) => item.category == category;

        public bool CheckIfAllItemsAreSameCategory(ItemCategory category) => items.TrueForAll(x => x.category == category);

        public void DisableAllSlotsColliders() => slotManagement.slots.ForEach(x => x.GetComponent<Collider>().enabled = false);

        public void AddItem(Item item) => this.items.Add(item);

        public void RemoveItem(Item item) => this.items.Remove(item);

        #endregion
    }
}