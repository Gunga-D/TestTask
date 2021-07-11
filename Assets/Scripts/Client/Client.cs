using UnityEngine;
using Zenject;

public class Client : MonoBehaviour
{
    private DiamondsInput _diamondsInput;
    private TimeInput _timeInput;

    [Inject]
    private void ConstructInputs(DiamondsInput diamondsInput, TimeInput timeInput)
    {
        _diamondsInput = diamondsInput;
        _timeInput = timeInput;
    }

    private void Awake()
    {
        _diamondsInput.OnAppliedInput += OnDiamondsApply;
        _timeInput.OnAppliedInput += OnTimeApply;
    }

    private void OnDiamondsApply()
    {
        Bank.Instance.Deposit(_diamondsInput.GetValue());
    }

    private void OnTimeApply()
    {
        TimersContainer.Instance.DecreaseTimerAmount(_timeInput.GetValue());
    }
}
