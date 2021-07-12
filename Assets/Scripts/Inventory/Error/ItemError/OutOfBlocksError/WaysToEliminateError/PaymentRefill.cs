using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Inventory
{
    public class PaymentRefill : WayToEliminateInventoryOutOfBlocksError
    {
        [SerializeField] private Text _costForRefillingText;
        [SerializeField] private int _costForRefilling;

        [SerializeField] private int _numberRefillingBlocksForPayment;

        private Bank _bank;

        [Inject]
        private void Construct(Bank bank)
        {
            _bank = bank;
        }

        private void Awake()
        {
            _costForRefillingText.text = _costForRefilling.ToString();

            InitializeSolvingProperties(_numberRefillingBlocksForPayment);
        }

        public void OnClick()
        {
            if (_bank.Withdraw(_costForRefilling))
            {
                SolveProblem();
            }
        }
    }
}
