using System;
using UnityEngine;
using Zenject;

public class Timer : MonoBehaviour
{
    [SerializeField] private TimerTextHandle _textHandle;

    [SerializeField] private float _startHours;
    [SerializeField] private float _startMinutes;
    [SerializeField] private float _startSeconds;

    private float _currentTime;

    private DateTime _pausedTime;

    private TimersContainer _timersContainer;

    public event Action<Timer> Finished;

    [Inject]
    private void Contruct(TimersContainer timersContainer)
    {
        _timersContainer = timersContainer;
    }

    private void Awake()
    {
        _timersContainer.AddTimer(this);

        _currentTime = _startHours * 3600f + _startMinutes * 60f + _startSeconds;
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;
        if(_currentTime <= 0)
        {
            Finished?.Invoke(this);
        }

        TimeSpan time = TimeSpan.FromSeconds(_currentTime);

        if (_textHandle)
        {
            _textHandle.UpdateValue($"{time.Hours.ToString()}:{time.Minutes.ToString()}:{time.Seconds.ToString()}");
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            _pausedTime = DateTime.Now;
        }
        else
        {
            _currentTime -= (float)((DateTime.Now - _pausedTime).TotalSeconds);
        }
    }

    public void DecreaseTime(float seconds)
    {
        _currentTime -= seconds;
    }
}
