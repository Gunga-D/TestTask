using UnityEngine;
using UnityEngine.UI;

public class PaymentRefill : WayToEliminateInventoryOutOfBlocksException
{
    [SerializeField] private Text _costForRefillingText;
    [SerializeField] private int _costForRefilling;

    [SerializeField] private int _numberRefillingBlocksForPayment;

    private void Awake()
    {
        _costForRefillingText.text = _costForRefilling.ToString();

        InitializeSolvingProperties(_numberRefillingBlocksForPayment);
    }

    public void OnClick()
    {
        if (Bank.Instance.Withdraw(_costForRefilling))
        {
            SolveProblem();
        }
    }
}
