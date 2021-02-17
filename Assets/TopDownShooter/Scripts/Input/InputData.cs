using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerInput
{
    [CreateAssetMenu(menuName = "TopDown Shooter/User Input/Input Data")]
    public class InputData : ScriptableObject
    {        
        public float Horizontal;
        public float Vertical;

        [Header("Axis Base Control")]
        [SerializeField] private bool _axisActive;
        [SerializeField] private string AxisNameHorizontal;
        [SerializeField] private string AxisNameVertical;

        [Header("Key Base Control")]
        [SerializeField] private bool _keyBaseHorizontalActive;
        [SerializeField] private KeyCode PositiveHorKeyCode;
        [SerializeField] private KeyCode NegativeHorKeyCode;
        [SerializeField] private bool _keyBaseVerticalActive;
        [SerializeField] private KeyCode PositiveVerKeyCode;
        [SerializeField] private KeyCode NegativeVerKeyCode;
        [SerializeField] private float _increaseAmount = 0.015f;
        //public float Jump;

        public void ProcessInput()
        {
            if(_axisActive)
            {
                Horizontal = Input.GetAxis(AxisNameHorizontal);
                Vertical = Input.GetAxis(AxisNameVertical);
            }
            else
            {
                if(_keyBaseHorizontalActive)
                {
                    KeyBaseAxisControl(ref Horizontal, PositiveHorKeyCode, NegativeHorKeyCode);
                }
                if(_keyBaseVerticalActive)
                {
                    KeyBaseAxisControl(ref Vertical, PositiveVerKeyCode, NegativeVerKeyCode);
                }
            }            
        }

        private void KeyBaseAxisControl(ref float value, KeyCode positive, KeyCode negative)
        {
            bool positiveActive = Input.GetKey(positive);
            bool negativeActive = Input.GetKey(negative);            

            if (positiveActive)
            {
                value += _increaseAmount;
            }
            else if (negativeActive)
            {
                value -= _increaseAmount;
            }
            else
            {
                value = 0;
            }

            value = Mathf.Clamp(value, -1, 1);
        }
    }
}