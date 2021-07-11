using System;
using UnityEngine;

public class CloseButtonHandler : MonoBehaviour
{
    public Action Closed;

    public void OnClick()
    {
        Closed?.Invoke();
    }
}
