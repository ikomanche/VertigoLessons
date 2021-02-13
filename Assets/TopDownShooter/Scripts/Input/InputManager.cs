using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerInput
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] InputData _inputData;
        [SerializeField] InputData _rotationInputData;
        private Vector3 _lastMouseInput;
        private void Update()
        {
            _inputData.Horizontal = Input.GetAxis("Horizontal");
            _inputData.Vertical = Input.GetAxis("Vertical");
            //_inputData.Jump = Input.GetAxis("Jump");

            _rotationInputData.Horizontal = Input.mousePosition.x - _lastMouseInput.x;
            _lastMouseInput = Input.mousePosition;
        }
    }
}