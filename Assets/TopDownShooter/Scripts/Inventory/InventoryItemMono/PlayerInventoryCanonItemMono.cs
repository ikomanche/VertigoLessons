using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Stat;
using UnityEngine;

namespace TopDownShooter.Inventory
{

    public class PlayerInventoryCanonItemMono : AbstractPlayerInventoryItemMono
    {
        //took Damage from scriptableObject --w6 hw
        [SerializeField] private Transform _canonShootPoint;
        [SerializeField] private PlayerInventoryCanonItemData _playerInventoryCanonItemData;
        //private float dmg;
        public void Shoot(IDamage damage,PlayerStat stat)
        {
            //dmg = _playerInventoryCanonItemData.Damage;
            ScriptableShootManager.Instance.Shoot(_canonShootPoint.position, _canonShootPoint.forward,damage,stat);
        }
    }
}