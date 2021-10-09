using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TopDownShooter.Network;
using System;
using TMPro;
using UnityEngine.UI;

namespace TopDownShooter.UI
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentState;
        [SerializeField] private Button[] _networkButtons;
        [SerializeField] private TMP_InputField inputField;
        private void Awake()
        {
            UpdateUIWithNetworkState(MatchMakingController.Instance.CurrentNetworkState);
            _currentState.text = "";
            //_currentState.color = Color.yellow;
            MessageBroker.Default.Receive<EventPlayerNetworkStateChange>().Subscribe(OnPlayerNetworkState)
                .AddTo(gameObject);
            inputField.onEndEdit.AddListener(OnEndEdit);
        }

        private void OnEndEdit(string arg0)
        {
            PhotonNetwork.playerName = arg0;
        }

        private void OnPlayerNetworkState(EventPlayerNetworkStateChange obj)
        {
            var networkState = obj.PlayerNetworkState;
            UpdateUIWithNetworkState(networkState);
            //_currentState.color = Color.green;
        }

        private void UpdateUIWithNetworkState(PlayerNetworkState networkState)
        {
            _currentState.text = "Connection State : " + networkState.ToString();
            for (int i = 0; i < _networkButtons.Length; i++)
            {
                _networkButtons[i].interactable = networkState == PlayerNetworkState.Connected;
            }
        }

        public void _CreateRoomClick()
        {
            MatchMakingController.Instance.CreateRoom();
        }

        public void _JoinRandomRoomClick()
        {
            MatchMakingController.Instance.JoinRandomRoom();
        }

        public void _SettingsCLick()
        {
            Debug.LogError("Not implemented yet.");
        }
    }
}