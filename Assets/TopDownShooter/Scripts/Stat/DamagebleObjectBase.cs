using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TopDownShooter.Inventory;

namespace TopDownShooter.Stat
{
    public class DamagebleObjectBase : MonoBehaviour, IDamageble,IPlayerStatHolder
    {
        [SerializeField] private Collider _collider;
        public int InstanceID { get; private set; }

        public PlayerStat PlayerStat { get; set; }

        private Vector3 _defaultScale;
        
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
            else
            {
                PlayerStat.Damage(dmg);
            }
            
        }

        IEnumerator TimedBasedDamage(float damage,float duration)
        {
            while (duration > 0 || isOnDamagable)
            {
                yield return new WaitForSeconds(1);
                //if (Armor <= 0)
                //    Health.Value -= damage;
                //else
                //    Armor -= damage;
                duration -= 1;
                //if (Health.Value <= 0)
                //{
                //    OnDeath.Execute();
                //    Destroy(gameObject);
                //}
                PlayerStat.Damage(damage);
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

        public void SetStat(PlayerStat stat)
        {
            PlayerStat = stat;
        }
    }
}