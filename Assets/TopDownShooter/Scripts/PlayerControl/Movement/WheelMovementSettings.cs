using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerControls
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Player/Wheel Movement Settings")]
    public class WheelMovementSettings : ScriptableObject
    {
        public float wheelMovementSpeed = 1;        
    }
}