using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Stat
{
    [CreateAssetMenu(menuName ="TopDown Shooter/Inventory/ScriptableStatManager")]
    public class ScriptableStatManager : AbstractScriptableManager<ScriptableStatManager>
    {
        private List<PlayerStat> _playerStatList = new List<PlayerStat>();

        public void RegisterStat(PlayerStat stat)
        {
            _playerStatList.Add(stat);
        }

        public PlayerStat Find(int id)
        {
            for (int i = 0; i < _playerStatList.Count; i++)
            {
                if (_playerStatList[i].Id == id)
                {
                    return _playerStatList[i];
                }
            }
            throw new System.Exception("Could not find player stat with id : " + id);
        }
    }


}