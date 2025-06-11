using SHS.Assessment.Observer;
using SHS.Assessment.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SHS.Assessment.SceneLoader
{
    public class SceneSwitcher : MonoBehaviour
    {
        #region Unity
        private void OnEnable()
        {
            EventBus.Subscribe(GameEvent.LOAD_LOBBY, OnLoadScene);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(GameEvent.LOAD_LOBBY, OnLoadScene);
        }
        #endregion

        #region Public
        public void LoadLobby()
        {
            SceneManager.LoadScene(Helper.LobbySceneIndex);
        }
        #endregion

        #region Callbacks
        private void OnLoadScene(object Args)
        {
            LoadLobby();
        }
        #endregion
    }
}