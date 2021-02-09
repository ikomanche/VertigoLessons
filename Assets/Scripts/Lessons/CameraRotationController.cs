using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons
{
    public class CameraRotationController : MonoBehaviour
    {
        //[SerializeField] private CameraSettings _cameraSettings;
       //[SerializeField] private Transform _rotationTarget;
        [SerializeField] private Transform _positionTarget;
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private float lerpSpeed;

        private void Update()
        {
            CameraMovementFollow();
            CameraRotationFollow();
        }

        private void CameraRotationFollow()
        {
            //_cameraTransform.rotation = Quaternion.Lerp(_cameraTransform.rotation, Quaternion.LookRotation(_rotationTarget.forward), Time.deltaTime * _cameraSettings.RotationLerpSpeed);
            //Quaternion.Lerp(_cameraTransform.rotation, Quaternion.LookRotation(_positionTarget.forward), Time.deltaTime * lerpSpeed);
            _cameraTransform.rotation = _positionTarget.rotation;
        }


        private void CameraMovementFollow()
        {
            //_cameraTransform.localPosition = _cameraSettings.PositionOffset;
            //_cameraTransform.localPosition = _positionTarget.position /*+ new Vector3(0, 4, -10)*/;
            _cameraTransform.localPosition = Vector3.Lerp(_cameraTransform.position, _positionTarget.position, Time.deltaTime);
        }

    }
}