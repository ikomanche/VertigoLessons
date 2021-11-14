using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Stat;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    public interface IDamage
    {
        float Damage { get; }
        float ArmorPenetration { get; }
        float TimeBasedDamage { get; }
        float DamageDuration { get; }

        PlayerStat Stat { get; }
    }
}