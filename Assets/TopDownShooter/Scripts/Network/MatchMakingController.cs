using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TopDownShooter.Network
{
    public enum PlayerNetworkState { Offline,Connecting,Connected,InRoom,JoiningRoom}
    public class MatchMakingController : Photon.PunBehaviour
    {
        [SerializeField] private float _delayToConnect = 2;
        public static MatchMakingController Instance;
        private const string _networkVersion = "v1.0";
        private void Awake()
        {
            Instance = this;
            PhotonNetwork.CacheSendMonoMessageTargets(typeof(MatchMakingController));
        }

        IEnumerator Start()
        {
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.Offline));
            yield return new WaitForSeconds(_delayToConnect);
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.Connecting));
            PhotonNetwork.ConnectUsingSettings(_networkVersion);
        }

        public void CreateRoom()
        {
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.JoiningRoom));
            PhotonNetwork.CreateRoom(null);
        }

        public void JoinRandomRoom()
        {
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.JoiningRoom));
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.InRoom));
            PhotonNetwork.isMessageQueueRunning = false;
        }
        public override void OnLeftRoom()
        {
            base.OnLeftRoom();
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.Connected));
        }

        public override void OnDisconnectedFromPhoton()
        {
            base.OnDisconnectedFromPhoton();
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.Offline));
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.Connected));
            Debug.Log("On Connected To MASTER");
        }
        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();
            Debug.Log("ON JOINED LOBBY");
        }
    }
}