using System;
using UnityEngine;

public class Bank : MonoBehaviour
{
    private int _numberOfDiamonds;
    private const string _memoryAddressName = "NumberOfDiamonds";

    public event Action<int> VisualizedNumberOfDiamonds;

    private void Awake()
    {
        RestoreDiamondsState();
    }

    private void Start()
    {
        VisualizedNumberOfDiamonds?.Invoke(GetBalance());
    }

    private void SaveDiamondsState()
    {
        PlayerPrefs.SetInt(_memoryAddressName, _numberOfDiamonds);
    }

    private void RestoreDiamondsState()
    {
        _numberOfDiamonds = PlayerPrefs.GetInt(_memoryAddressName, 0);
    }

    public void Deposit(int amount)
    {
        _numberOfDiamonds += amount;

        VisualizedNumberOfDiamonds?.Invoke(GetBalance());

        SaveDiamondsState();
    }

    public bool Withdraw(int amount)
    {
        if (_numberOfDiamonds >= amount)
        {
            _numberOfDiamonds -= amount;

            VisualizedNumberOfDiamonds?.Invoke(GetBalance());

            SaveDiamondsState();

            return true;
        }

        return false;
    }

    public int GetBalance()
    {
        return _numberOfDiamonds;
    }
}
