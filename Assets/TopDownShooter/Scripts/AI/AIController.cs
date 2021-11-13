using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using TopDownShooter.PlayerControls;
using TopDownShooter.PlayerInput;
using UnityEngine;
using UniRx;
using System;

namespace TopDownShooter.AI
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private InputDataAI _aiMovementInput;
        [SerializeField] private InputDataAI _aiRotationtInput;
        [SerializeField] private InputDataAI _towerRotationInput;
        [SerializeField] private PlayerMovementController _playerMovementController;
        [SerializeField] private PlayerInventoryController _inventoryController;
        [SerializeField] private TowerRotationController _playerTowerRotationController;

        public List<AITarget> TargetList;
        private Vector3 _targetMovementPosition;
        private CompositeDisposable _targetDispose;
        //public Transform _movementTarget;
        //public Transform _towerTarget;
        private void Start()
        {
            _aiMovementInput = Instantiate(_aiMovementInput);
            _aiRotationtInput = Instantiate(_aiRotationtInput);
            _towerRotationInput = Instantiate(_towerRotationInput);

            _playerMovementController.InitializeInput(_aiMovementInput);
            _playerTowerRotationController.InitializeInput(_towerRotationInput);

            UpdateTarget();
        }

        public void UpdateTarget()
        {
            _targetMovementPosition = transform.position + (TargetList[0].transform.position - transform.position).normalized *
                (Vector3.Distance(TargetList[0].transform.position, transform.position) - 5);

            _aiMovementInput.SetTarget(transform, _targetMovementPosition);
            _aiRotationtInput.SetTarget(transform, _targetMovementPosition);
            _towerRotationInput.SetTarget(_playerTowerRotationController.TowerTransform,
                TargetList[0].transform.position);

            _targetDispose = new CompositeDisposable();
            TargetList[0].PlayerStat.OnDeath.Subscribe(OnTargetDeath).AddTo(_targetDispose);
        }

        private void OnTargetDeath(Unit obj)
        {
            Debug.Log("Target is Dead");
            TargetList.RemoveAt(0);

            if(TargetList.Count > 0)
            {
                UpdateTarget();
            }
            else
            {
                this.enabled = false;
            }
        }

        private void Update()
        {           

            _aiMovementInput.ProcessInput();
            _aiRotationtInput.ProcessInput();
            _towerRotationInput.ProcessInput();

            if(_towerRotationInput.Horizontal < 0.2f && Vector3.Distance(_targetMovementPosition,
                transform.position) < 25)
                _inventoryController.ReactiveShootCommand.Execute();
        }
    }
}