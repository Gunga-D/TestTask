using System;

public abstract class InventoryItemException : InventoryException
{
    public Action<InventoryMenuItem> RemovedFromErrorsList;

    public abstract void Initialize(InventoryMenuItem brokenItem);
}
