using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using TopDownShooter.PlayerControls;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.AI
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private InputDataAI _aiMovementInput;
        [SerializeField] private InputDataAI _aiRotationtInput;
        [SerializeField] private PlayerMovementController _playerMovementController;
        [SerializeField] private PlayerInventoryController _inventoryController;
        [SerializeField] private TowerRotationController _playerTowerRotationController;

        public Transform Target;
        private void Awake()
        {
            _aiMovementInput = Instantiate(_aiMovementInput);
            _aiRotationtInput = Instantiate(_aiRotationtInput);

            _playerMovementController.InitializeInput(_aiMovementInput);
            _playerTowerRotationController.InitializeInput(_aiRotationtInput);

            
        }

        private void Update()
        {
            _aiMovementInput.SetTarget(transform, Target.position);
            _aiRotationtInput.SetTarget(transform, Target.position);

            _aiMovementInput.ProcessInput();
            _aiRotationtInput.ProcessInput();
        }
    }
}