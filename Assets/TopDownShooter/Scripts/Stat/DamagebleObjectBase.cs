using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TopDownShooter.Inventory;

namespace TopDownShooter.Stat
{
    public class DamagebleObjectBase : MonoBehaviour, IDamageble
    {
        [SerializeField] private Collider _collider;
        public int InstanceID { get; private set; }
        public float Health = 100;
        public float Armor = 100;
        private Vector3 _defaultScale;
        public ReactiveCommand OnDeath = new ReactiveCommand();
        private bool isOnDamagable = false;

        protected virtual void Awake()
        {
            InstanceID = _collider.GetInstanceID();
            this.InitializeDamageble();
            _defaultScale = transform.localScale;
        }

        //private void Update()
        //{
        //    transform.localScale = Vector3.Lerp(transform.localScale,
        //        (Health / 100) * _defaultScale, Time.deltaTime);
        //}

        public virtual void Damage(IDamage dmg)
        {
            if(dmg.TimeBasedDamage > 0)
            {
                StartCoroutine(TimedBasedDamage(dmg.TimeBasedDamage, dmg.DamageDuration));
            }
            if(Armor > 0)
            {
                Armor -= (dmg.Damage + (dmg.Damage * dmg.ArmorPenetration));
            }
            else
            {
                Health -= dmg.Damage;
                Debug.Log("damaged : " + dmg + "cuurent health : " + Health);
                if (Health <= 0)
                {
                    OnDeath.Execute();
                    Destroy(gameObject);
                }
            }
        }

        IEnumerator TimedBasedDamage(float damage,float duration)
        {
            while(duration > 0 || isOnDamagable)
            {
                yield return new WaitForSeconds(1);
                if (Armor <= 0)
                    Health -= damage;
                else
                    Armor -= damage;
                duration -= 1;
                if (Health <= 0)
                {
                    OnDeath.Execute();
                    Destroy(gameObject);
                }                    
            }           
            
        }

        private void OnTriggerEnter(Collider other)
        {
            isOnDamagable = true;
        }
        private void OnTriggerExit(Collider other)
        {
            isOnDamagable = false;
        }

        public virtual void Destroy()
        {
            this.DestroyDamageble();
        }        
    }
}