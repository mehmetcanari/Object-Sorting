using System;
using UnityEngine;
using DG.Tweening;

namespace Kozar.Science
{
    public class Carrier : Input { }
    
    internal class Hovering
    {
        protected readonly Item HoveredItem;
        protected readonly Transform followTransform;
        protected readonly float hoverSpeed;

        internal Hovering(Item hoveredItem, Transform followTransform, float hoverSpeed)
        {
            HoveredItem = hoveredItem;
            this.followTransform = followTransform;
            this.hoverSpeed = hoverSpeed;
        }

        internal void HoverItem()
        {
            HoveredItem.transform.DOMove(followTransform.position, hoverSpeed);
        }
        
        internal void SetParent(Transform obj,Transform parent)
        {
            obj.transform.SetParent(parent);
        }
    }
}