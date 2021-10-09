using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDownShooter.Inventory;

namespace TopDownShooter.Network
{
    public class NetworkPlayer : Photon.PunBehaviour
    {
        [SerializeField] private PhotonView[] _photonViewsForOwnership;
        [SerializeField] private PlayerInventoryController _inventoryController;
        public PhotonView[] PhotonViews { get { return _photonViewsForOwnership; } }
        public void SetOwnership(PhotonPlayer photonPlayer, int[] allocatedViewIdArray)
        {
            for (int i = 0; i < _photonViewsForOwnership.Length; i++)
            {
                _photonViewsForOwnership[i].viewID = allocatedViewIdArray[i];
                _photonViewsForOwnership[i].TransferOwnership(photonPlayer);
            }
            _inventoryController.Id = photonPlayer.ID;
        }
    }
}
