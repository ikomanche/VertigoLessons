using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Inventory/Player Inventory Canon Item Data")]
    public class PlayerInventoryCanonItemData : AbstractPlayerInventoryItemData<PlayerInventoryCanonItemMono>
    {
        private float _damage;
        public float Damage { get { return _damage; } }
        public override void CreateIntoInventory(PlayerInventoryController targetPlayerInventory)
        {
            var instantiated = InstantiateAndInitializePrefab(targetPlayerInventory.Parent);
            Debug.Log("Canon Item Data Class");
            //ScriptableShootManager.Instance.Shoot();
        }
    }
}