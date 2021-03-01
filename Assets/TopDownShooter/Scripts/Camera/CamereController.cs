using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDownShooter.Shooting;

namespace TopDownShooter.Camera
{
    public class CamereController : MonoBehaviour
    {
        [SerializeField] private CameraSettings _cameraSettings;
        [SerializeField] private Transform _rotationTarget;
        //[SerializeField] private Transform _positionTarget;
        [SerializeField] private Transform _cameraTransform;
        //[SerializeField] private ShootingManager _shootingManager;

        private void Update()
        {
            CameraRotationFollow();
            CameraMovementFollow();
            //if(Input.GetKeyDown(KeyCode.Space))
            //{
            //    _shootingManager.Shoot(_cameraTransform.position, _cameraTransform.forward);
            //    Debug.Log("Shot");
            //}
        }

        private void CameraRotationFollow()
        {
            _cameraTransform.rotation = Quaternion.Lerp(_cameraTransform.rotation,
                Quaternion.LookRotation(_rotationTarget.forward),
                Time.deltaTime * _cameraSettings.RotationLerpSpeed);
        }

        private void CameraMovementFollow()
        {
            //Vector3 offset = (_cameraTransform.right * _cameraSettings.PositionOffset.x) +
            //    (_cameraTransform.up * _cameraSettings.PositionOffset.y) +
            //    (_cameraTransform.forward * _cameraSettings.PositionOffset.z);
            _cameraTransform.localPosition = _cameraSettings.PositionOffset;
            //_cameraTransform.position = Vector3.Lerp(_cameraTransform.position, _targetTransform.position + offset,
            //    Time.deltaTime * _cameraSettings.PositionlerpSpeed);
        }
    }
}