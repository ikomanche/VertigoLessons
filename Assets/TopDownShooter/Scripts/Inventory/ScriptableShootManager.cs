﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDownShooter.Stat;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Inventory/Scriptable Shoot Manager")]
    public class ScriptableShootManager : AbstractScriptableManager<ScriptableShootManager>
    {
        public void Shoot(Vector3 origin, Vector3 direction)
        {
            RaycastHit rHit;
            var physic = Physics.Raycast(origin, direction, out rHit);            
            if (physic)
            {
                Debug.Log(" Collider :" + rHit.collider.name);
                int colliderInstanceID = rHit.collider.GetInstanceID();
                if (DamagebleHelper.DamagebleList.ContainsKey(colliderInstanceID))
                {
                    DamagebleHelper.DamagebleList[colliderInstanceID].Damage(5);
                }
            }
        }

        public override void Initialize()
        {
            base.Initialize();
            Debug.Log("ShootManager Initialize");
        }

        public override void Destroy()
        {
            base.Destroy();
            Debug.Log("ShootManager Destroy");
        }
    }
}