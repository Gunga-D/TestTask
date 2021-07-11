using UnityEngine;
using System;

public abstract class WayToEliminateInventoryOutOfBlocksException : MonoBehaviour, ISolver
{
    private InventoryMenuItem _whatToSolve;
    private int _numberRefillingBlocks;

    public Action Solved;

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