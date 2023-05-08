using System;
using Kozar.Science;
using UnityEngine;

namespace Kozar.Science
{
    public sealed class Object : Item { }
}

public abstract class Item : MonoBehaviour
{
    #region PUBLIC FIELDS

    public Slot Slot { get; internal set; }
    
    public Slot PreviousSlot { get; internal set; }
    
    public ItemType type;
    
    public ItemCategory category;
    
    public Quaternion rotation;

    public bool isPlaced;

    #endregion

    #region PUBLIC PROPERTIES

    public bool IsPlaced => isPlaced;
    
    public Quaternion Rotation => rotation;

    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        RegisterRotation();
    }

    #endregion
    
    #region PUBLIC METHODS

    public void SetSlot(Slot slot) => Slot = slot;

    public void SetPreviousSlot(Slot slot) => PreviousSlot = slot;

    #endregion
    
    #region PRIVATE METHODS

    private void RegisterRotation() => rotation = transform.rotation;

    #endregion
}

#region SHARED ENUMS

public enum ItemType
{
    Ear,
    Glass,
    Shoe,
    Cap
}

public enum ItemCategory
{
    Work,
    Sport,
}

#endregion
