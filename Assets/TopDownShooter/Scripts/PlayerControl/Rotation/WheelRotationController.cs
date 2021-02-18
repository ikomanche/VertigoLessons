using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.PlayerControls
{
    public class WheelRotationController : MonoBehaviour
    {
        [SerializeField] private InputData _inputData;
        [SerializeField] private Transform _wheelTransform;
        [SerializeField] private WheelRotationSettings _wheelRotationSettings;
        Quaternion currentRotation;
        private void Start()
        {
            
        }
        private void Update()
        {
            //if (_inputData.Horizontal > 0 && _wheelTransform.localRotation.eulerAngles.y <= 60 || _wheelTransform.localRotation.eulerAngles.y > 300)
            //    _wheelTransform.Rotate(0, _inputData.Horizontal * _wheelRotationSettings.WheelRotationSpeed, 0, Space.Self);
            //else if (_inputData.Horizontal < 0 && _wheelTransform.localRotation.eulerAngles.y <= 60 || _wheelTransform.localRotation.eulerAngles.y > 300)
            //    _wheelTransform.Rotate(0, _inputData.Horizontal * _wheelRotationSettings.WheelRotationSpeed, 0, Space.Self);
            //else
            //{

            //}
            if(_inputData.Horizontal != 0)
            {
                if (_wheelTransform.localRotation.eulerAngles.y <= 50 || _wheelTransform.localRotation.eulerAngles.y > 310)
                    _wheelTransform.Rotate(0, _inputData.Horizontal * _wheelRotationSettings.WheelRotationSpeed, 0, Space.Self);
                else
                {
                    if (_inputData.Horizontal < 0)
                        _wheelTransform.Rotate(0, 2, 0);
                    else
                        _wheelTransform.Rotate(0, -2, 0);
                }
            }            

            if(_inputData.Vertical != 0)
            {
                _wheelTransform.Rotate(_inputData.Vertical * 1, 0, 0, Space.Self);
            }
            //else if (_inputData.Horizontal < 0 && _wheelTransform.localRotation.eulerAngles.y <= 60 || _wheelTransform.localRotation.eulerAngles.y > 300)
            //    _wheelTransform.Rotate(0, _inputData.Horizontal * _wheelRotationSettings.WheelRotationSpeed, 0, Space.Self);
            //else
            //{

            //}
        }
    }
}