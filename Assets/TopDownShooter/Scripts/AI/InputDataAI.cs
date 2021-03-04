using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.AI
{
    public class InputDataAI : InputData
    {
        protected Vector3 _currentTarget;
        protected Transform _aiTransform;
        public void SetTarget(Transform aiTransform,Vector3 target)
        {
            _aiTransform = aiTransform;
            _currentTarget = target;
        }

        public override void ProcessInput()
        {
            base.ProcessInput();
        }
    }
}