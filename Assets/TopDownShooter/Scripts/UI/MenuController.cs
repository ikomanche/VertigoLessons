using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TopDownShooter.Network;
using System;
using TMPro;

namespace TopDownShooter.UI
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentState;

        private void Awake()
        {
            _currentState.text = "";
            //_currentState.color = Color.yellow;
            MessageBroker.Default.Receive<EventPlayerNetworkStateChange>().Subscribe(OnPlayerOnline);
        }

        private void OnPlayerOnline(EventPlayerNetworkStateChange obj)
        {
            _currentState.text = "Connection State : " + obj.PlayerNetworkState.ToString();
            //_currentState.color = Color.green;
        }

        public void _CreateRoomClick()
       {

       }

        public void _JoinRandomRoomClick()
        {

        }

        public void _SettingsCLick()
        {

        }
    }
}