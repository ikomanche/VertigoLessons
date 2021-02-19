using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    public class PlayerInventoryController : MonoBehaviour
    {
        [SerializeField] AbstractBasePlayerInventoryItemData[] _inventoryItemDataArray;
        [SerializeField] List<AbstractBasePlayerInventoryItemData>_instantiatedItemDataList;
        public Transform Parent;
        private void Start()
        {
            //testing
            InitializeInventory(_inventoryItemDataArray);
        }

        private void OnDestroy()
        {
            ClearInventory();
        }

        public void InitializeInventory(AbstractBasePlayerInventoryItemData[] inventoryItemDataArray)
        {
            ClearInventory();
            _instantiatedItemDataList = new List<AbstractBasePlayerInventoryItemData>(inventoryItemDataArray.Length);
            for (int i = 0; i < inventoryItemDataArray.Length; i++)
            {
                //inventoryItemDataArray[i].CreateIntoInventory(this);
                var instantiated = Instantiate(inventoryItemDataArray[i]);
                instantiated.CreateIntoInventory(this);
                _instantiatedItemDataList.Add(instantiated);
            }
        }

        private void ClearInventory()
        {
            if (_instantiatedItemDataList != null)
            {
                for (int i = 0; i < _instantiatedItemDataList.Count; i++)
                {
                    _instantiatedItemDataList[i].Destroy();
                }
            }
        }
    }
}