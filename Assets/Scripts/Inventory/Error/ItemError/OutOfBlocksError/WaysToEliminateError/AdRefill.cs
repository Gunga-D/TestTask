using UnityEngine;

namespace Inventory
{
    public class AdRefill : WayToEliminateInventoryOutOfBlocksError
    {
        [SerializeField] private int _numberRefillingBlocksForAd;

        private void Awake()
        {
            InitializeSolvingProperties(_numberRefillingBlocksForAd);
        }

        public void OnClick()
        {
            SolveProblem();
        }
    }
}
