using System;
using UnityEngine;

public class PlaceButtonHandler : MonoBehaviour
{
    public Action PlacedItem;

    public void Click()
    {
        PlacedItem?.Invoke();
    }
}
