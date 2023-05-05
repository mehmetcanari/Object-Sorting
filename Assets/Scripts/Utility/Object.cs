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

    public Slot Slot { get; private set; }
    
    public Quaternion rotation;

    public bool isPlaced = false;

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

    public void SetSlot(Slot slot)
    {
        Slot = slot;
    }

    #endregion


    #region PRIVATE METHODS

    private void RegisterRotation()
    {
        rotation = transform.rotation;
    }

    #endregion
    
}