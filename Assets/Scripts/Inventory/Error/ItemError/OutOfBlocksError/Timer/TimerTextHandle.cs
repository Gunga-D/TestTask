using UnityEngine;
using UnityEngine.UI;

public class TimerTextHandle : MonoBehaviour
{
    [SerializeField] private Text _currentTimeText;
    
    public void UpdateValue(string time)
    {
        _currentTimeText.text = time;
    }
}
