using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kozar.Science
{
    public class SlotManagement : MonoBehaviour
    {
        #region INSPECTOR FIELDS

        public List<Slot> slots;

        #endregion

        #region PUBLIC PROPERTIES

        public List<Slot> EmptySlots => slots.FindAll(slot => slot.IsEmpty);
        
        
        #endregion
    }
}