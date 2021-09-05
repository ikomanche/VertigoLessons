using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Network
{
    public class InGameNetworkController : Photon.PunBehaviour
    {
        [SerializeField] private NetworkPlayer _localPlayerPrefab;
        [SerializeField] private NetworkPlayer _remotePlayerPrefab;

        private void Start()
        {
            InstantiateLocalPlayer();
        }

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
