using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryPage : MonoBehaviour
    {
        [SerializeField] private List<InventoryMenuItem> _items = new List<InventoryMenuItem>();
        private InventoryMenuItem _selectedItem;

        private void Awake()
        {
            foreach (var item in _items)
            {
                item.Selected += OnSelectItem;
            }
        }

        private void OnSelectItem(InventoryMenuItem item)
        {
            if (_selectedItem)
            {
                _selectedItem.ChangeToUnselectStyle();
            }

            _selectedItem = item;

            _selectedItem.ChangeToSelectStyle();
        }

        public void Open()
        {
            this.gameObject.SetActive(true);
        }

        public void Close()
        {
            this.gameObject.SetActive(false);
        }

        public InventoryMenuItem GetSelectedItem()
        {
            return _selectedItem;
        }
    }
}
