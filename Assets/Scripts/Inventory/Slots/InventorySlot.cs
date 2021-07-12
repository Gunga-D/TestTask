using System;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image _background;
        [SerializeField] private Color _selectBackgroundColor;
        [SerializeField] private Color _unselectBackgroundColor;

        private InventoryItem _currentItem;

        public event Action<InventorySlot> Selected;

        private void CreateItem(InventoryItem item)
        {
            _currentItem = Instantiate(item);

            _currentItem.transform.SetParent(this.transform);

            RectTransform currentItemRect = _currentItem.GetComponent<RectTransform>();
            currentItemRect.offsetMin = new Vector2(0f, currentItemRect.offsetMin.y);
            currentItemRect.offsetMax = new Vector2(0f, currentItemRect.offsetMax.y);
            currentItemRect.offsetMax = new Vector2(currentItemRect.offsetMax.x, 0f);
            currentItemRect.offsetMin = new Vector2(currentItemRect.offsetMin.x, 0f);

            currentItemRect.localScale = Vector3.one;
        }

        private void ChangeCurrentItem(InventoryItem item)
        {
            Destroy(_currentItem);

            CreateItem(item);
        }

        public void Place(InventoryItem item)
        {
            if (_currentItem)
            {
                ChangeCurrentItem(item);
            }
            else
            {
                CreateItem(item);
            }
        }

        public void OnClick()
        {
            Selected?.Invoke(this);
        }

        public void ChangeToSelectStyle()
        {
            _background.color = _selectBackgroundColor;
        }

        public void ChangeToUnselectStyle()
        {
            _background.color = _unselectBackgroundColor;
        }
    }
}
