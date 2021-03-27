using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Inventory/Player Inventory Canon Item Data")]
    public class PlayerInventoryCanonItemData :
        AbstractPlayerInventoryItemData<PlayerInventoryCanonItemMono>, IDamage
    {
        [SerializeField] private float _damage;
        public float Damage { get { return _damage; } }

        [SerializeField] private float _rpm = 1f;
        public float RPM { get { return _rpm; } }
        [Range(0, 1)]
        [SerializeField] private float _armorPenetration;
        public float ArmorPenetration { get { return _armorPenetration; } }

        [SerializeField] private float _timeBasedDamage = 0;
        public float TimeBasedDamage { get { return _timeBasedDamage; } }

        [SerializeField] private float _damageDuration = 0;
        public float DamageDuration { get { return _damageDuration; } }

        private float _lastShootTime;
        public override void Initialize(PlayerInventoryController targetPlayerInventory)
        {
            base.Initialize(targetPlayerInventory);
            var instantiated = InstantiateAndInitializePrefab(targetPlayerInventory.CanonParent);
            targetPlayerInventory.ReactiveShootCommand.Subscribe(OnReactiveShootCommand)
                .AddTo(_compositeDisposable);
            Debug.Log("Canon Item Data Class");
            //ScriptableShootManager.Instance.Shoot();
        }
        
        public override void Destroy()
        {
            base.Destroy();
        }

        private void OnReactiveShootCommand(Unit obj)
        {
            Debug.Log("reactiveCommand Shoot");
            Shoot();
        }

        public void Shoot()
        {
            if (Time.time - _lastShootTime > _rpm)
            {
                _instantiated.Shoot(this);
                _lastShootTime = Time.time;
            }
            else
            {
                Debug.LogError("Cannot shoot");
            }
        }
    }
}