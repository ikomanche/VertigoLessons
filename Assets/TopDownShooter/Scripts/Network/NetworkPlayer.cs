using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDownShooter.Inventory;
using TopDownShooter.Stat;

namespace TopDownShooter.Network
{
    public class NetworkPlayer : Photon.PunBehaviour
    {
        private bool _initialized = false;
        public PlayerStat PlayerStat { get; private set; }
        //public bool IsLocalPlayer { get; set; }
        [SerializeField] private PhotonView[] _photonViewsForOwnership;
        [SerializeField] private PlayerInventoryController _inventoryController;
        private List<IPlayerStatHolder> _playerStatHolders = new List<IPlayerStatHolder>();
        public PhotonView[] PhotonViews { get { return _photonViewsForOwnership; } }
        public void SetOwnership(PhotonPlayer photonPlayer, int[] allocatedViewIdArray)
        {
            for (int i = 0; i < _photonViewsForOwnership.Length; i++)
            {
                _photonViewsForOwnership[i].viewID = allocatedViewIdArray[i];
                _photonViewsForOwnership[i].TransferOwnership(photonPlayer);
            }
            //_inventoryController.Id = photonPlayer.ID;
            PlayerStat = new PlayerStat(photonPlayer.ID, photonPlayer.isLocal);
            //IsLocalPlayer = photonPlayer.isLocal;
            for (int i = 0; i < _playerStatHolders.Count; i++)
            {
                _playerStatHolders[i].SetStat(PlayerStat);
            }
            _initialized = true;
        }

        public void RegisterStatHolder(IPlayerStatHolder statHolder)
        {
            _playerStatHolders.Add(statHolder);
            if (_initialized)
            {
                statHolder.SetStat(PlayerStat);
            }
        }
        public void UnregisterStatHolder(IPlayerStatHolder statHolder)
        {
            _playerStatHolders.Remove(statHolder);
        }
    }
}
