using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDownShooter.Inventory;

namespace TopDownShooter.Stat
{
    public static class DamagebleHelper
    {
        public static Dictionary<int, IDamageble> DamagebleList = new Dictionary<int, IDamageble>();
        public static void InitializeDamageble(this IDamageble damageble)
        {
            DamagebleList.Add(damageble.InstanceID, damageble);
        }

        public static void DestroyDamageble(this IDamageble damageble)
        {
            DamagebleList.Remove(damageble.InstanceID);
        }
    }
    public interface IDamageble
    {        
        int InstanceID { get; }
        void Damage(IDamage dmg);
    }
}