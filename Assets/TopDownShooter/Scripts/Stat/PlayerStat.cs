using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using UniRx;
using UnityEngine;

namespace TopDownShooter.Stat
{ 
    public class PlayerStat: IDamageble
    {
        public int Id;
        public bool IsLocalPlayer { get; set; }

        public int InstanceID { get; private set; } = -1;
        public ReactiveProperty<float> Armor = new ReactiveProperty<float>(100);
        public ReactiveProperty<float> Health = new ReactiveProperty<float>(100);
        public ReactiveCommand OnDeath = new ReactiveCommand();

        public PlayerStat(int id,bool isLocalPlayer)
        {
            Id = id;
            IsLocalPlayer = isLocalPlayer;
            ScriptableStatManager.Instance.RegisterStat(this);
        }

        public void Damage(IDamage dmg)
        {
            if (Armor.Value > 0)
            {
                Armor.Value -= (dmg.Damage + (dmg.Damage * dmg.ArmorPenetration));
            }
            else
            {
                Health.Value -= dmg.Damage;
                Debug.Log("damaged : " + dmg + "cuurent health : " + Health);
                if (Health.Value <= 0)
                {
                    OnDeath.Execute();
                    //Destroy(gameObject);
                }
            }
            MessageBroker.Default.Publish(new EventPlayerGiveDamage(dmg.Damage, this,dmg.Stat));
        }
        public void Damage(float dmg,PlayerStat shooter)
        {
            if (Armor.Value > 0)
            {
                Armor.Value -= dmg;
            }
            else
            {
                Health.Value -= dmg;
                Debug.Log("damaged : " + dmg + "cuurent health : " + Health);
                if (Health.Value <= 0)
                {
                    OnDeath.Execute();
                    //Destroy(gameObject);
                }
            }
            MessageBroker.Default.Publish(new EventPlayerGiveDamage(dmg, this,shooter));
        }
    }
}