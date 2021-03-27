using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerInput
{
    public class InputManager : MonoBehaviour
    {
        //[SerializeField] InputData _movementInput;
        //[SerializeField] InputData _rotationInput;
        [SerializeField] private AbstractInputData[] _inputDataArray;
        //private Vector3 _lastMouseInput;
        private void Update()
        {
            for (int i = 0; i < _inputDataArray.Length; i++)
            {
                _inputDataArray[i].ProcessInput();
            }

            //_movementInput.Horizontal = Input.GetAxis("Horizontal");
            //_movementInput.Vertical = Input.GetAxis("Vertical");
            //_inputData.Jump = Input.GetAxis("Jump"); //Jump Homework

            //_rotationInputData.Horizontal = Input.mousePosition.x - _lastMouseInput.x;
            //_lastMouseInput = Input.mousePosition;
        }
    }
}