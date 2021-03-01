using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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