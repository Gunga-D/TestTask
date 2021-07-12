using System;
using UnityEngine;

namespace Inventory
{
    public class CloseButtonHandler : MonoBehaviour
    {
        public event Action Closed;

        public void OnClick()
        {
            Closed?.Invoke();
        }
    }
}
