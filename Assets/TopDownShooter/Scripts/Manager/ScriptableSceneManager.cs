using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TopDownShooter.Network;
using System;
using UnityEngine.SceneManagement;

namespace TopDownShooter
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Manager/Scriptable Scene Manager")]
    public class ScriptableSceneManager : AbstractScriptableManager<ScriptableSceneManager>
    {
        [SerializeField] private string _MenuScene;
        [SerializeField] private string _GameScene;        
        public override void Initialize()
        {
            base.Initialize();
            SceneManager.LoadScene(_MenuScene);
            MessageBroker.Default.Receive<EventPlayerNetworkStateChange>().Subscribe(OnPlayerNetworkState)
                .AddTo(_compositeDisposable);
        }


        public override void Destroy()
        {
            base.Destroy();
        }
        private void OnPlayerNetworkState(EventPlayerNetworkStateChange obj)
        {
            Debug.Log("Network State Changed On Scene Manager To : " + obj.PlayerNetworkState);
            switch (obj.PlayerNetworkState)
            {
                case PlayerNetworkState.Offline:
                    break;
                case PlayerNetworkState.Connecting:
                    break;
                case PlayerNetworkState.Connected:
                    break;
                case PlayerNetworkState.InRoom:
                    break;
                case PlayerNetworkState.JoiningRoom:
                    SceneManager.LoadScene(_GameScene);
                    break;
                default:
                    break;
            }
        }
    }
}