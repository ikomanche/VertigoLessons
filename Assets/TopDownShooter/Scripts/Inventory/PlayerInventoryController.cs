using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    public class PlayerInventoryController : MonoBehaviour
    {
        [SerializeField] AbstractBasePlayerInventoryItemData[] _inventoryItemDataArray;
        public Transform Parent;
        private void Start()
        {
            InitializeInventory(_inventoryItemDataArray);
        }

        public void InitializeInventory(AbstractBasePlayerInventoryItemData[] inventoryItemDataArray)
        {
            for (int i = 0; i < inventoryItemDataArray.Length; i++)
            {
                inventoryItemDataArray[i].CreateIntoInventory(this);
            }
        }
    }
}