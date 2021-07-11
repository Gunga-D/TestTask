using UnityEngine;

public abstract class InventoryException : MonoBehaviour
{
    public abstract void Throw();

    public abstract void EliminateException();

    public abstract void Release();

    public abstract void Unrelease();
}
