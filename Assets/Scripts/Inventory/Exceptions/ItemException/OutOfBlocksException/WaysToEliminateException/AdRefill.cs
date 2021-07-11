using UnityEngine;

public class AdRefill : WayToEliminateInventoryOutOfBlocksException
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
