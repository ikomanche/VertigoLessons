using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.AI
{
    [CreateAssetMenu(menuName = "TopDown Shooter/User Input/AI /Movement Input Data")]
    public class InputMovementDataAI : InputDataAI
    {
        public override void ProcessInput()
        {
            float distance = Vector3.Distance(_aiTransform.position, _currentTarget);
            if(distance > 25)
            {
                Vertical = 1;
            }
            else
            {
                Vertical = 0;
            }

            Vector3 dir = _currentTarget - _aiTransform.position;
            var rotation = Quaternion.LookRotation(dir, Vector3.up).eulerAngles;
            if (rotation.y > 360)
                rotation.y -= 360;
            else if (rotation.y < 0)
                rotation.y += 360;
            var rotationGap = Mathf.Abs(rotation.y - _aiTransform.rotation.eulerAngles.y);
            bool isRotationNegative = (rotationGap > 0) ? false : true;
            if (Mathf.Abs(rotationGap) > 5)
            {
                //var val = isRotationNegative ? -1 : 1;
                float horizontalClamped = Mathf.Clamp(rotationGap / 180, -1, 1);
                Horizontal = horizontalClamped;
                
            }
            else
            {
                Horizontal = 0;
            }

        }
    }
}