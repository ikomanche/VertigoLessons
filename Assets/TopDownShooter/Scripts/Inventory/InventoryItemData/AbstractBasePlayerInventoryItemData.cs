using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TopDownShooter.Inventory
{
    public abstract class AbstractBasePlayerInventoryItemData : ScriptableObject
    {
        protected PlayerInventoryController _inventoryController;
        protected CompositeDisposable _compositeDisposable;
        public virtual void Initialize(PlayerInventoryController targetPlayerInventory)
        {
            _inventoryController = targetPlayerInventory;
            _compositeDisposable = new CompositeDisposable();
        }        

        public virtual void Destroy()
        {
            if(_compositeDisposable != null)
                _compositeDisposable.Dispose(); //Unsubscribe
            Destroy(this);
        }
    }
}