using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.PlayerMovement
{
    public class PlayerRotationController : MonoBehaviour
    {
        [SerializeField] InputData _inputData;
        [SerializeField] Transform _tankTower;

        private void Update()
        {
            _tankTower.Rotate(0, _inputData.Horizontal, 0, Space.Self);
        }
    }
}