using DG.Tweening;

namespace Kozar.Science
{
    public class Swap
    {
        private Item _item;
        private Slot _slot;
        private Release _release;
        private float _easeTime;
        
        internal Swap(Item item, Slot slot, float easeTime, Release release)
        {
            _item = item;
            _slot = slot;
            _easeTime = easeTime;
            _release = release;
        }
        
        internal void SwapItems(Item item, Slot slot)
        {
            item.transform.DOMove(slot.transform.position, _easeTime)
                .SetLink(item.gameObject)
                .SetEase(Ease.InOutBack)
                .OnComplete(() =>
                {
                    slot.SetItem(item);
                    slot.gameObject.layer = 6;
                    item.transform.parent = slot.transform;
                    item.PreviousSlot = slot;
                    item = null;
                    slot = null;
                });
        }
    }
}