using UnityEngine;
using System;

namespace Inventory
{
    public abstract class WayToEliminateInventoryOutOfBlocksError : MonoBehaviour, ISolver
    {
        private InventoryMenuItem _whatToSolve;
        private int _numberRefillingBlocks;

        public event Action Solved;

        protected void InitializeSolvingProperties(int numberRefillingBlocks)
        {
            _numberRefillingBlocks = numberRefillingBlocks;
        }

        public void InitializeProblem(InventoryMenuItem whatToSolve)
        {
            _whatToSolve = whatToSolve;
        }

        public void SolveProblem()
        {
            _whatToSolve.Refill(_numberRefillingBlocks);

            Solved?.Invoke();
        }
    }
}