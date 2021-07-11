using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private int _barCode;
    [SerializeField] private GameObject _prefab;

    public GameObject Prefab
    {
        get
        {
            return _prefab;
        }
    }

    public int BarCode
    {
        get
        {
            return _barCode;
        }
    }
}
