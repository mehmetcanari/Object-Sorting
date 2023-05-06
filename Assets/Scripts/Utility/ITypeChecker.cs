namespace Kozar.Science
{
    public interface ITypeChecker
    {
        bool CheckAnySameType(Item item);
        void AddItem(Item item);
        
        void RemoveItem(Item item);
    }
}