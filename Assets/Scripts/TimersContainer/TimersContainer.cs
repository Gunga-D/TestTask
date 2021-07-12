using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimersContainer : MonoBehaviour
{
    private List<Timer> _timers = new List<Timer>();

    public void AddTimer(Timer timer)
    {
        _timers.Add(timer);
    }

    public void DecreaseTimerAmount(int value)
    {
        foreach(var timer in _timers)
        {
            timer.DecreaseTime(value);
        }
    }
}
