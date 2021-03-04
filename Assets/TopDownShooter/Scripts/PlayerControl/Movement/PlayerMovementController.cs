using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.PlayerControls
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] InputData _inputData;
        [SerializeField] Rigidbody _rigidbody;
        [SerializeField] Transform _targetTransform;
        [SerializeField] PlayerMovementSettings _playerMovementSettings;

        public void InitializeInput(InputData inputData)
        {
            _inputData = inputData;
        }
        private void Update()
        {
            _rigidbody.MovePosition(_rigidbody.position + 
                (_rigidbody.transform.forward * _inputData.Vertical * _playerMovementSettings.VerticalSpeed));
            _targetTransform.Rotate(0, _inputData.Horizontal * _playerMovementSettings.HorizontalSpeed, 0, Space.Self);
            //_rigidbody.MovePosition(_rigidbody.position + 
            //    (_rigidbody.transform.right * _inputData.Horizontal* _playerMovementSettings.HorizontalSpeed));
            //_rigidbody.MovePosition(_rigidbody.position +
            //    (_rigidbody.transform.up * _inputData.Jump * _playerMovementSettings.VerticalSpeed));
        }
    }
}