using UnityEngine;
using UnityEngine.UI;

public class DiamondsCounter : MonoBehaviour
{
    [SerializeField] private Text _diamondsText;

    public void UpdateValue(int amount)
    {
        _diamondsText.text = amount.ToString();
    }
}
