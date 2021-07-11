using System;
using UnityEngine.UI;
using UnityEngine;

public class TimeInput : InputIntForm
{
    [SerializeField] private Text _inputTimeText;

    public Action OnAppliedInput;

    private void Awake()
    {
        Initialize(_inputTimeText);
    }

    public void OnEndEdit()
    {
        OnAppliedInput?.Invoke();
    }
}
