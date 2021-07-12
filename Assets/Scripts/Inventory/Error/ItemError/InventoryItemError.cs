using System;

namespace Inventory
{
    public abstract class InventoryItemError : InventoryError
    {
        public abstract void Initialize(InventoryMenuItem brokenItem);
    }
}
