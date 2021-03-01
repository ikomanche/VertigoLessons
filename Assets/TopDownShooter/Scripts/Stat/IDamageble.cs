﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Stat
{
    public static class DamagebleHelper
    {
        public static Dictionary<int, IDamageble> DamagebleList = new Dictionary<int, IDamageble>();
        public static void InitializeDamageble(this IDamageble damageble)
        {
            DamagebleList.Add(damageble.InstanceID, damageble);
        }
    }
    public interface IDamageble
    {        
        int InstanceID { get; }
        void Damage(float dmg);
    }
}