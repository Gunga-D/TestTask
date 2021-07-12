using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Inventory
{
    public class OutOfBlocksError : InventoryItemError
    {
        [Header("Offsets")]
        [SerializeField] private float _topOffset;
        [SerializeField] private float _bottomOffset;
        [SerializeField] private float _leftOffset;
        [SerializeField] private float _rightOffset;

        [Header("Solvers")]
        [SerializeField]
        private List<WayToEliminateInventoryOutOfBlocksError> _solverServices =
            new List<WayToEliminateInventoryOutOfBlocksError>();

        [Header("FrontElements")]
        [SerializeField] private GameObject _frontElements;

        [Header("Handlers")]
        [SerializeField] CloseButtonHandler _closeHandler;

        private InventoryMenuItem _troubleMaker;

        public event Action<InventoryMenuItem> RemovedFromErrorsList;

        private void Awake()
        {
            _closeHandler.Closed += Unrelease;
        }

        private void OnDisableHandlersEvents()
        {
            _closeHandler.Closed -= Unrelease;
        }

        private void OnDisableServicesEvents()
        {
            foreach (var solverService in _solverServices)
            {
                solverService.Solved -= EliminateError;
            }
        }

        public override void Initialize(InventoryMenuItem brokenItem)
        {
            _troubleMaker = brokenItem;

            foreach (var solverService in _solverServices)
            {
                solverService.InitializeProblem(brokenItem);

                solverService.Solved += EliminateError;
            }
        }

        public override void Throw()
        {
            RectTransform instanceRect = GetComponent<RectTransform>();
            instanceRect.offsetMin = new Vector2(_leftOffset, instanceRect.offsetMin.y);
            instanceRect.offsetMax = new Vector2(-_rightOffset, instanceRect.offsetMax.y);
            instanceRect.offsetMax = new Vector2(instanceRect.offsetMax.x, -_topOffset);
            instanceRect.offsetMin = new Vector2(instanceRect.offsetMin.x, _bottomOffset);

            instanceRect.localScale = Vector3.one;
        }

        public override void EliminateError()
        {
            OnDisableHandlersEvents();
            OnDisableServicesEvents();

            RemovedFromErrorsList?.Invoke(_troubleMaker);

            Destroy(this.gameObject);
        }

        public override void Release()
        {
            _frontElements.SetActive(true);
        }

        public override void Unrelease()
        {
            _frontElements.SetActive(false);
        }
    }
}
