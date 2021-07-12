using UnityEngine;
using Zenject;

namespace Client
{
    public class Client : MonoBehaviour
    {
        private DiamondsInput _diamondsInput;
        private TimeInput _timeInput;

        private Bank _bank;
        private TimersContainer _timersContainer;

        [Inject]
        private void ConstructInputs(DiamondsInput diamondsInput, TimeInput timeInput)
        {
            _diamondsInput = diamondsInput;
            _timeInput = timeInput;
        }

        [Inject]
        private void Contruct(Bank bank, TimersContainer timersContainer)
        {
            _bank = bank;
            _timersContainer = timersContainer;
        }

        private void Awake()
        {
            _diamondsInput.OnAppliedInput += OnDiamondsApply;
            _timeInput.OnAppliedInput += OnTimeApply;
        }

        private void OnDiamondsApply()
        {
            _bank.Deposit(_diamondsInput.GetValue());
        }

        private void OnTimeApply()
        {
            _timersContainer.DecreaseTimerAmount(_timeInput.GetValue());
        }

        private void OnDestroy()
        {
            _diamondsInput.OnAppliedInput -= OnDiamondsApply;
            _timeInput.OnAppliedInput -= OnTimeApply;
        }
    }
}
