using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Network
{
    public class InGameNetworkController : Photon.PunBehaviour
    {
        [SerializeField] private NetworkPlayer _localPlayerPrefab;
        [SerializeField] private NetworkPlayer _remotePlayerPrefab;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(10);
            InstantiateLocalPlayer();
        }

        public void InstantiateLocalPlayer()
        {
            var instantiated = Instantiate(_localPlayerPrefab);
            instantiated.SetOwnership(PhotonNetwork.player);
            photonView.RPC("RPC_InstantiateLocalPlayer", PhotonTargets.OthersBuffered);
            PhotonNetwork.isMessageQueueRunning = true;
        }

        [PunRPC]
        public void RPC_InstantiateLocalPlayer(PhotonMessageInfo photonMessageInfo)
        {
            Debug.Log("Instantiate Local Player");
            var instantiated = Instantiate(_remotePlayerPrefab);
            instantiated.SetOwnership(photonMessageInfo.sender);
        }
    }
}
