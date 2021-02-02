using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons
{
    public class RotateObject : MonoBehaviour
    {        
        [SerializeField] private RotateSettings _rotateSettings;
        private void Update()
        {
            transform.Rotate(Vector3.forward, _rotateSettings.Speed * Time.deltaTime);
        }
    }
}