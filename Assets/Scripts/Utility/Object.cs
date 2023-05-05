using Kozar.Science;
using UnityEngine;

namespace Kozar.Science
{
    public sealed class Object : Item { }
}

public abstract class Item : MonoBehaviour
{
    public bool isPlaced = false;
    
    public Slot Slot { get; set; } 

    public bool IsPlaced
    {
        get => isPlaced;
        set => isPlaced = value;
    }
}