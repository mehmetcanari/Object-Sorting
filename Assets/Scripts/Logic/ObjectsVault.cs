using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kozar.Science
{
    public class ObjectsVault : MonoBehaviour, ITypeChecker
    {
        #region INSPECTOR FIELDS

        public List<Item> items;

        #endregion
        
        #region PUBLIC METHODS
        
        public bool CheckAnySameType(Item item)
        {
            return this.items.Exists(x => x.type == item.type);
        }
        
        public void AddItem(Item item)
        {
            this.items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            this.items.Remove(item);
        }

        #endregion
    }
}