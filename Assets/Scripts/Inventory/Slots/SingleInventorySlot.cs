using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleInventorySlot : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> _slots = new List<InventorySlot>();
    private InventorySlot _activeSlot;

    public InventorySlot Instance
    {
        get
        {
            return _activeSlot;
        }
    }

    private void Awake()
    {
        foreach(var slot in _slots)
        {
            slot.Selected += OnSelectSlot;
        }
    }

    private void OnSelectSlot(InventorySlot slot)
    {
        if (_activeSlot)
        {
            _activeSlot.ChangeToUnselectStyle();
        }

        _activeSlot = slot;

        _activeSlot.ChangeToSelectStyle();
    }

    public void Place(InventoryItem item)
    {
        if (_activeSlot)
        {
            _activeSlot.Place(item);
        }
    }
}
