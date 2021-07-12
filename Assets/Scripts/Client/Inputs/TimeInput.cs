using System;
using UnityEngine.UI;
using UnityEngine;

namespace Client
{
    public class TimeInput : InputIntForm
    {
        [SerializeField] private Text _inputTimeText;

        public event Action OnAppliedInput;

        private void Awake()
        {
            Initialize(_inputTimeText);
        }

        public void OnEndEdit()
        {
            OnAppliedInput?.Invoke();
        }
    }
}
