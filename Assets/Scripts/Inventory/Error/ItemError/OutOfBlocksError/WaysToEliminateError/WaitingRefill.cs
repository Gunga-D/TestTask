using UnityEngine;

namespace Inventory
{
    public class WaitingRefill : WayToEliminateInventoryOutOfBlocksError
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
}
