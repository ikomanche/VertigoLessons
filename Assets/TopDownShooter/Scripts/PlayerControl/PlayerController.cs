using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using UnityEngine;
using NetworkPlayer = TopDownShooter.Network.NetworkPlayer;
using UniRx;
using System;
using TopDownShooter.Network;
using TopDownShooter.Stat;

namespace TopDownShooter { 
    public class PlayerController : MonoBehaviour,IPlayerStatHolder
    {
        [SerializeField] private DamagebleObjectBase[] _damagebleObjectBases;
        [SerializeField] private NetworkPlayer _networkPlayer;
        [SerializeField] protected PlayerInventoryController _inventoryController;

        public PlayerStat PlayerStat { get; set; }

        protected void Start()
        {
            _networkPlayer.RegisterStatHolder(_inventoryController);
            _networkPlayer.PlayerStat.OnDeath.Subscribe(OnDeathEventPlayerController).AddTo(gameObject);
            for (int i = 0; i < _damagebleObjectBases.Length; i++)
            {
                _networkPlayer.RegisterStatHolder(_damagebleObjectBases[i]);
            }
            _networkPlayer.RegisterStatHolder(this);
        }

        private void OnDeathEventPlayerController(Unit obj)
        {
            if (_networkPlayer.PlayerStat.IsLocalPlayer)
            {
                MatchMakingController.Instance.LeaveRoom();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SetStat(PlayerStat stat)
        {
            PlayerStat = stat;
            stat.OnDeath.Subscribe(OnDeathEventPlayerController).AddTo(gameObject);
        }
    }
}