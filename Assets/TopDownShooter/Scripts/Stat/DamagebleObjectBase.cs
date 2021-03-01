using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Stat.Test
{
    public class DamagebleObjectBase : MonoBehaviour, IDamageble
    {
        [SerializeField] private Collider _collider;
        public int InstanceID { get; private set; }

        public virtual void Damage(float dmg)
        {
            Debug.Log("damaged : " + dmg);
        }

        protected virtual void Awake()
        {
            InstanceID = _collider.GetInstanceID();
            this.InitializeDamageble();
        }
    }
}