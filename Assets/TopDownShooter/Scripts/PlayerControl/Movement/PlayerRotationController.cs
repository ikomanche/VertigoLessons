using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.PlayerControls
{
    public class PlayerRotationController : MonoBehaviour
    {
        [SerializeField] PlayerInputData _inputData;
        [SerializeField] Transform _tankTower;

        private void Update()
        {
            _tankTower.Rotate(0, _inputData.Horizontal, 0, Space.Self);
        }
    }
}