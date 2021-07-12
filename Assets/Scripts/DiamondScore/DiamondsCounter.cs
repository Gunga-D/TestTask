using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DiamondScore
{
    public class DiamondsCounter : MonoBehaviour
    {
        [SerializeField] private Text _diamondsText;

        private Bank _bank;

        [Inject]
        private void Construct(Bank bank)
        {
            _bank = bank;
        }

        private void Start()
        {
            _bank.VisualizedNumberOfDiamonds += UpdateValue;
        }

        private void OnDestroy()
        {
            _bank.VisualizedNumberOfDiamonds -= UpdateValue;
        }

        public void UpdateValue(int amount)
        {
            _diamondsText.text = amount.ToString();
        }
    }
}
