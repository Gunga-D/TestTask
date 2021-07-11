using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryMenu _menu;
    [SerializeField] private PlaceButtonHandler _btn;
    [SerializeField] private SingleInventorySlot _slot;

    [SerializeField] private Transform _exceptionArea;
    [SerializeField] private InventoryItemException _outOfBlocksException;
    private Dictionary<InventoryMenuItem, InventoryItemException> _allItemsWithErrors = 
        new Dictionary<InventoryMenuItem, InventoryItemException>();

    private void Awake()
    {
        _btn.PlacedItem += OnPlace;
    }

    private void OnPlace()
    {
        InventoryMenuItem item = _menu.GetSelectedItem();

        if (item)
        {
            if (item.IsEnough && _slot.Instance)
            {
                item.ReduceAmount();

                _slot.Place(item.RealItem);
            }
            else
            {
                if (_allItemsWithErrors.ContainsKey(item))
                {
                    _allItemsWithErrors[item].Release();
                }
                else
                {
                    InventoryItemException exception = CreateException(_outOfBlocksException, item);
                    exception.RemovedFromErrorsList += OnRemoveFromErrorsList;

                    _allItemsWithErrors.Add(item, exception);
                }
            }
        }
    }

    private InventoryItemException CreateException(InventoryItemException sample, InventoryMenuItem brokenItem)
    {
        InventoryItemException instance = Instantiate(sample);
        instance.transform.SetParent(_exceptionArea);

        instance.Initialize(brokenItem);
        instance.Throw();

        return instance;
    }

    private void OnRemoveFromErrorsList(InventoryMenuItem troubleMaker)
    {
        _allItemsWithErrors.Remove(troubleMaker);
    }
}
