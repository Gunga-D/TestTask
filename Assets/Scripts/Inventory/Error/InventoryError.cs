using UnityEngine;

namespace Inventory
{
    public abstract class InventoryError : MonoBehaviour
    {
        public abstract void Throw();

        public abstract void EliminateError();

        public abstract void Release();

        public abstract void Unrelease();
    }
}
