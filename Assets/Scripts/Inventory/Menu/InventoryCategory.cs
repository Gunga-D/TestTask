using UnityEngine;
using System;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryCategory : MonoBehaviour
    {
        [SerializeField] private Sprite _unlockedImage;
        [SerializeField] private Sprite _lockedImage;
        [SerializeField] private Image _background;
        [SerializeField] private Image _icon;

        [SerializeField] public bool Unlocked;

        public event Action<InventoryCategory> Selected;

        private void Awake()
        {
            if (Unlocked)
            {
                ChangeToUnlockedStyle();
            }
            else
            {
                ChangeToLockedStyle();
            }
        }

        private void ChangeToUnlockedStyle()
        {
            _background.sprite = _unlockedImage;
            _icon.gameObject.SetActive(true);
        }

        private void ChangeToLockedStyle()
        {
            _background.sprite = _lockedImage;
            _icon.gameObject.SetActive(false);
        }

        public void OnClick()
        {
            Selected?.Invoke(this);
        }
    }

}