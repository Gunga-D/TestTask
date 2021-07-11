using UnityEngine;

public class WaitingRefill : WayToEliminateInventoryOutOfBlocksException
{
    [SerializeField] private Timer _timer;
    [SerializeField] private int _numberRefillingBlocksForWaiting;

    private void Awake()
    {
        InitializeSolvingProperties(_numberRefillingBlocksForWaiting);

        _timer.Finished += OnTimeEnded;
    }

    private void OnTimeEnded(Timer timer)
    {
        timer.Finished -= OnTimeEnded;

        SolveProblem();
    }
}
