using UnityEngine;

public class Bank : MonoBehaviour
{
    public static Bank Instance;

    [SerializeField] DiamondsCounter _diamondsCounter;
    private int _numberOfDiamonds;
    private const string _memoryAddressName = "NumberOfDiamonds";

    private void Awake()
    {
        Instance = this;

        RestoreDiamondsState();

        _diamondsCounter.UpdateValue(_numberOfDiamonds);
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

        _diamondsCounter.UpdateValue(_numberOfDiamonds);

        SaveDiamondsState();
    }

    public bool Withdraw(int amount)
    {
        if (_numberOfDiamonds >= amount)
        {
            _numberOfDiamonds -= amount;

            _diamondsCounter.UpdateValue(_numberOfDiamonds);

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
