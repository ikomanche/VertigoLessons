using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerControls
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Player/Wheel Rotation Settings")]
    public class WheelRotationSettings : ScriptableObject
    {
        public float WheelRotationSpeed = 1;
    }
}