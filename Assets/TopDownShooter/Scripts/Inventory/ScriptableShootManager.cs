using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

using TopDownShooter.Stat;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Inventory/Scriptable Shoot Manager")]
    public class ScriptableShootManager : AbstractScriptableManager<ScriptableShootManager>
    {
        public void Shoot(Vector3 origin, Vector3 direction,IDamage damage,PlayerStat stat)
        {
            RaycastHit rHit;
            var physic = Physics.Raycast(origin, direction, out rHit);
            MessageBroker.Default.Publish(new EventPlayerShoot(origin,stat));
            if (physic)
            {
                Debug.Log(" Collider :" + rHit.collider.name);
                int colliderInstanceID = rHit.collider.GetInstanceID();
                if (DamagebleHelper.DamagebleList.ContainsKey(colliderInstanceID))
                {
                    DamagebleHelper.DamagebleList[colliderInstanceID].Damage(damage);
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