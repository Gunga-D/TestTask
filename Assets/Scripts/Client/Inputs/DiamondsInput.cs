using System;
using UnityEngine.UI;
using UnityEngine;

public class DiamondsInput : InputIntForm
{
    [SerializeField] private Text _inputDiamondsText;

    public Action OnAppliedInput;

    private void Awake()
    {
        Initialize(_inputDiamondsText);
    }

    public void OnEndEdit()
    {
        OnAppliedInput?.Invoke();
    }
}
