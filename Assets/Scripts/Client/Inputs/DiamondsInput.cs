using System;
using UnityEngine.UI;
using UnityEngine;

namespace Client
{
    public class DiamondsInput : InputIntForm
    {
        [SerializeField] private Text _inputDiamondsText;

        public event Action OnAppliedInput;

        private void Awake()
        {
            Initialize(_inputDiamondsText);
        }

        public void OnEndEdit()
        {
            OnAppliedInput?.Invoke();
        }
    }
}
