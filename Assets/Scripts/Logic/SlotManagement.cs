using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kozar.Science
{
    public class SlotManagement : MonoBehaviour
    {
        #region INSPECTOR FIELDS

        [SerializeField] private List<Slot> slots;

        #endregion

        #region PUBLIC PROPERTIES

        public List<Slot> Slots => slots;
        
        public List<Slot> EmptySlots => slots.FindAll(slot => slot.IsEmpty);
        
        public List<Slot> FilledSlots => slots.FindAll(slot => !slot.IsEmpty);

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            slots = GetAllSlotsInChildren();
        }

        #endregion
        
        #region PRIVATE METHODS

        private List<Slot> GetAllSlotsInChildren()
        {
            slots = new List<Slot>();
            foreach (Transform child in transform)
            {
                Slot slot = child.GetComponent<Slot>();
                if (slot != null)
                {
                    slots.Add(slot);
                }
            }
            return slots;
        }

        #endregion
    }
}