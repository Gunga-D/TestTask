using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItem : MonoBehaviour
{
    [SerializeField] private InventoryItem _realItem;

    [SerializeField] private Image _background;
    [SerializeField] private Color _selectBackgroundColor;
    [SerializeField] private Color _unselectBackgroundColor;

    [SerializeField] private Text _remainingAmountText;
    [SerializeField] private int _remainingAmount;

    private string _memoryAddressName = "RemainingInventoryItemsAmount";

    public Action<InventoryMenuItem> Selected;

    public InventoryItem RealItem
    {
        get
        {
            return _realItem;
        }
    }

    public bool IsEnough
    {
        get
        {
            return _remainingAmount > 0;
        }
    }

    private void Awake()
    {
        _memoryAddressName += _realItem.BarCode;

        RestoreRemainingAmountState();

        SetTextRemainingAmount();
    }

    private void SetTextRemainingAmount()
    {
        _remainingAmountText.text = _remainingAmount.ToString();
    }

    private void SaveRemainingAmountState()
    {
        PlayerPrefs.SetInt(_memoryAddressName, _remainingAmount);
    }

    private void RestoreRemainingAmountState()
    {
        _remainingAmount = PlayerPrefs.GetInt(_memoryAddressName, _remainingAmount);
    }

    public void ChangeToSelectStyle()
    {
        _background.color = _selectBackgroundColor;
    }

    public void ChangeToUnselectStyle()
    {
        _background.color = _unselectBackgroundColor;
    }

    public void ReduceAmount()
    {
        if (_remainingAmount > 0)
        {
            _remainingAmount--;

            SaveRemainingAmountState();

            SetTextRemainingAmount();
        }
    }

    public void Refill(int amount)
    {
        _remainingAmount += amount;


        SaveRemainingAmountState();

        SetTextRemainingAmount();
    }

    public void OnClick()
    {
        Selected?.Invoke(this);
    }
}
