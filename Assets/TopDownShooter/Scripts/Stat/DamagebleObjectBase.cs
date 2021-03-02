using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Stat.Test
{
    public class DamagebleObjectBase : MonoBehaviour, IDamageble
    {
        [SerializeField] private Collider _collider;
        public int InstanceID { get; private set; }
        public float Health = 100;
        private Vector3 _defaultScale;

        protected virtual void Awake()
        {
            InstanceID = _collider.GetInstanceID();
            this.InitializeDamageble();
            _defaultScale = transform.localScale;
        }

        private void Update()
        {
            transform.localScale = Vector3.Lerp(transform.localScale,
                (Health / 100) * _defaultScale, Time.deltaTime);
        }

        public virtual void Damage(float dmg)
        {
            Health -= dmg;
            Debug.Log("damaged : " + dmg +"cuurent health : " + Health);
            if(Health <= 0)
            {
                Destroy(gameObject);
            }

        }

        public virtual void Destroy()
        {
            this.DestroyDamageble();
        }        
    }
}