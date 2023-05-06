using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Kozar.Science
{
    public class ItemInitiliazer : MonoBehaviour
    {
        #region INSPECTOR FIELDS

        [SerializeField] private SlotManagement slotManagement;
        [SerializeField] private ItemsData itemsData;
        [SerializeField] private List<global::Item> items;

        #endregion

        #region PRIVATE PROPERTIES
        
        private List<global::Item> NotPlacedItems => items.FindAll(item => !item.IsPlaced);

        #endregion
        
        #region UNITY METHODS

        private void Start()
        {
            InitiliazeItems();
            SpawnItemsAtEachEmptySlots();
        }

        #endregion

        #region PRIVATE METHODS

        private void InitiliazeItems()
        {
            var items = itemsData.Items;
            
            for (int i = 0; i < items.Count; i++)
            {
                global::Item item = Instantiate(items[i], Vector3.zero, Quaternion.identity);
                this.items.Add(item);
                item.gameObject.SetActive(false);
            }
        }
        
        private void SpawnItemsAtEachEmptySlots()
        {
            var emptySlots = slotManagement.EmptySlots;
            
            for (int i = 0; i < emptySlots.Count; i++)
            {
                global::Item item = NotPlacedItems[UnityEngine.Random.Range(0, NotPlacedItems.Count)];
                emptySlots[i].SetItem(item);
                item.transform.position = emptySlots[i].transform.position;
                item.gameObject.SetActive(true);
                item.SetSlot(emptySlots[i]);
                item.PreviousSlot = emptySlots[i];
                emptySlots[i].gameObject.layer = 6;
            }
        }

        #endregion
    }
}