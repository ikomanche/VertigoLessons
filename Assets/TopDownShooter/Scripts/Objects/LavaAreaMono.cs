using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using TopDownShooter.Stat;
using UnityEngine;

namespace TopDownShooter.Objects
{
    public class LavaAreaMono : MonoBehaviour,IDamage
    {

        [SerializeField] private float _damage;
        public float Damage { get { return _damage; } }

        [Range(0, 1)]
        [SerializeField] private float _armorPenetration;
        public float ArmorPenetration { get { return _armorPenetration; } }

        [SerializeField] private float _timeBasedDamage;
        public float TimeBasedDamage { get { return _timeBasedDamage; } }

        [SerializeField] private float _damageDuration;
        public float DamageDuration { get { return _damageDuration; } }

        private void OnTriggerEnter(Collider collider)
        {
            int colliderInstanceID = collider.GetInstanceID();
            if (DamagebleHelper.DamagebleList.ContainsKey(colliderInstanceID))
            {
                DamagebleHelper.DamagebleList[colliderInstanceID].Damage(this);
            }
        }

    }
}