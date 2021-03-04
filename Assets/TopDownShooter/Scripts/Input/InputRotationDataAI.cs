using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.AI
{
    [CreateAssetMenu(menuName = "TopDown Shooter/User Input/AI /Rotation Input Data")]
    public class InputRotationDataAI : InputDataAI
    {
        public override void ProcessInput()
        {
            Vector3 dir = _currentTarget - _aiTransform.position;
            if(Mathf.Abs(dir.y - _aiTransform.rotation.eulerAngles.y) > 5)
            {
                Horizontal = 1;
            }
            else
            {
                Horizontal = 0;
            }
        }
    }
}