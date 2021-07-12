using System;
using UnityEngine;

namespace Inventory
{
    public class PlaceButtonHandler : MonoBehaviour
    {
        public event Action PlacedItem;

        public void Click()
        {
            PlacedItem?.Invoke();
        }
    }
}
