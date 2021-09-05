using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace TopDownShooter.Network
{
    public enum InGameNetworkState { NotReady,Ready}
    public class InGameNetworkController : Photon.PunBehaviour
    {
        [SerializeField] private NetworkPlayer _localPlayerPrefab;
        [SerializeField] private NetworkPlayer _remotePlayerPrefab;
        private InGameNetworkState _inGameNetworkState;

        private void Awake()
        {
            MessageBroker.Default.Receive<EventSceneLoaded>().
                Subscribe(OnSceneLoaded).AddTo(gameObject);
        }

        private void OnSceneLoaded(EventSceneLoaded obj)
        {
            switch (obj.SceneName)
            {
                case "GameScene":
                    _inGameNetworkState = InGameNetworkState.Ready;
                    PhotonNetwork.isMessageQueueRunning = true;
                    InstantiateLocalPlayer();
                    break;
                default:
                    _inGameNetworkState = InGameNetworkState.NotReady;
                    break;
            }
        }

        //private void Start()
        //{
        //    InstantiateLocalPlayer();
        //}

        public void InstantiateLocalPlayer()
        {
            var instantiated = Instantiate(_localPlayerPrefab);
            int viewId = PhotonNetwork.AllocateViewID();
            instantiated.photonView.viewID = viewId;
            instantiated.SetOwnership(PhotonNetwork.player);
            photonView.RPC("RPC_InstantiateLocalPlayer", PhotonTargets.OthersBuffered,viewId);
            PhotonNetwork.isMessageQueueRunning = true;
        }

        [PunRPC]
        public void RPC_InstantiateLocalPlayer(int viewId,PhotonMessageInfo photonMessageInfo)
        {
            Debug.Log("Instantiate Local Player");
            var instantiated = Instantiate(_remotePlayerPrefab);
            instantiated.photonView.viewID = viewId;
            instantiated.SetOwnership(photonMessageInfo.sender);
        }
    }
}
