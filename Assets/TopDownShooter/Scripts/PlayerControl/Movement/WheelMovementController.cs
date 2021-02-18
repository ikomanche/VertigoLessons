using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.PlayerControls
{
    public class WheelMovementController : MonoBehaviour
    {
        [SerializeField] private InputData _inputData;
        [SerializeField] private Transform _wheelTransform;
        [SerializeField] private WheelMovementSettings _wheelMovementSettings;
        private void Update()
        {
            _wheelTransform.Rotate(_inputData.Vertical * _wheelMovementSettings.wheelMovementSpeed, 0, 0, Space.Self);
        }
    }
}