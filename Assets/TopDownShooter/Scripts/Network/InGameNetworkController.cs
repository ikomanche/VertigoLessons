using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using TopDownShooter.Inventory;
using TopDownShooter.Stat;

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
            MessageBroker.Default.Receive<EventPlayerShoot>().
                Subscribe(OnPlayerShoot).AddTo(gameObject);
            MessageBroker.Default.Receive<EventPlayerGiveDamage>().
                Subscribe(OnPlayerGetDamage).AddTo(gameObject);
        }


        private void OnPlayerShoot(EventPlayerShoot obj)
        {
            if (obj.Stat.IsLocalPlayer)
            {
                Shoot(obj.Origin);
            }
        }
        private void OnPlayerGetDamage(EventPlayerGiveDamage obj)
        {
            if (obj.ShooterStat.IsLocalPlayer)
            {
                Damage(obj.Damage,obj.ReceiverStat.Id,obj.ShooterStat.Id);
            }
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
            //var instantiated = Instantiate(_localPlayerPrefab);
            int[] allocatedViewIdArray = new int[_localPlayerPrefab.PhotonViews.Length];
            for (int i = 0; i < allocatedViewIdArray.Length; i++)
            {
                allocatedViewIdArray[i] = PhotonNetwork.AllocateViewID();
            }
            //int viewId = PhotonNetwork.AllocateViewID();
            //instantiated.photonView.viewID = viewId;
            //instantiated.SetOwnership(PhotonNetwork.player,allocatedViewIdArray);
            photonView.RPC("RPC_InstantiateLocalPlayer", PhotonTargets.AllBufferedViaServer,allocatedViewIdArray);
            PhotonNetwork.isMessageQueueRunning = true;
        }

        [PunRPC]
        public void RPC_InstantiateLocalPlayer(int[] viewIdArray,PhotonMessageInfo photonMessageInfo)
        {
            Debug.Log("Instantiate  Player" + photonMessageInfo.sender.name);
            var instantiated = Instantiate(photonMessageInfo.sender.isLocal ? _localPlayerPrefab : _remotePlayerPrefab);
            //instantiated.photonView.viewID = viewId;
            instantiated.SetOwnership(photonMessageInfo.sender,viewIdArray);
        }

        public void Shoot(Vector3 origin)
        {
            photonView.RPC("RPC_Shoot", PhotonTargets.Others,origin);
        }

        [PunRPC]
        public void RPC_Shoot(Vector3 origin,PhotonMessageInfo photonMessageInfo)
        {
            MessageBroker.Default.Publish(new EventPlayerShoot(origin, ScriptableStatManager.Instance.Find
                (photonMessageInfo.sender.ID)));
        }

        public void Damage(float dmg, int receiver,int shooter)
        {
            photonView.RPC("RPC_Damage", PhotonTargets.Others,dmg,receiver,shooter);
        }

        [PunRPC]
        public void RPC_Damage(float dmg,int receiver, int shooter)
        {
            var receiverStat = ScriptableStatManager.Instance.Find(receiver);//.Damage(dmg);
            var shooterStat = ScriptableStatManager.Instance.Find(shooter);//.Damage(dmg);

            receiverStat.Damage(dmg, shooterStat);

        }
    }
}
