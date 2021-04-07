﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class ManagerInitializerMono : MonoBehaviour
    {
        [SerializeField] private AbstractScriptableManagerBase[] _abstractScriptableManagerArray;
        private List<AbstractScriptableManagerBase>_instantiatedAbstractScriptableManagerList;
        [SerializeField] private bool _dontDestroyOnLoad = true;
        private void Start()
        {
            _instantiatedAbstractScriptableManagerList = new List<AbstractScriptableManagerBase>
                (_abstractScriptableManagerArray.Length);
            for (int i = 0; i < _abstractScriptableManagerArray.Length; i++)
            {
                var instantiated = Instantiate(_abstractScriptableManagerArray[i]);
                instantiated.Initialize();
                _instantiatedAbstractScriptableManagerList.Add(instantiated);
            }
            if(_dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        private void OnDestroy()
        {
            if(_instantiatedAbstractScriptableManagerList != null)
            {
                for (int i = 0; i < _instantiatedAbstractScriptableManagerList.Count; i++)
                {
                    _instantiatedAbstractScriptableManagerList[i].Destroy();
                }
            }
            
        }
    }
}