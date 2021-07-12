using UnityEngine;

namespace Inventory
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private int _barCode;

        public int BarCode => _barCode;
    }
}
