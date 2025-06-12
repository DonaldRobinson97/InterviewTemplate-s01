using UnityEngine;
using System;

namespace SHS.Assessment.Managers
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance;

        public TimeSpan SceneTime => DateTime.Now - _sceneStartTime;
        public TimeSpan SessionTime => DateTime.Now - _sessionStartTime;
        public TimeSpan TodayTime => TimeSpan.FromSeconds(PlayerPrefs.GetFloat("TodayTime", 0f) + (float)(DateTime.Now - _sessionStartTime).TotalSeconds);
        public TimeSpan LifetimeTime => TimeSpan.FromSeconds(PlayerPrefs.GetFloat("LifetimeTime", 0f) + (float)(DateTime.Now - _sessionStartTime).TotalSeconds);

        private DateTime _sceneStartTime;
        private DateTime _sessionStartTime;

        #region Unity
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            _sceneStartTime = DateTime.Now;
            _sessionStartTime = DateTime.Now;
        }

        private void OnDisable()
        {
            float todaySoFar = PlayerPrefs.GetFloat("TodayTime", 0f);
            float lifetimeSoFar = PlayerPrefs.GetFloat("LifetimeTime", 0f);
            float sessionDuration = (float)(DateTime.Now - _sessionStartTime).TotalSeconds;

            PlayerPrefs.SetFloat("TodayTime", todaySoFar + sessionDuration);
            PlayerPrefs.SetFloat("LifetimeTime", lifetimeSoFar + sessionDuration);
            PlayerPrefs.Save();
        }
        #endregion

        #region Public

        public void ResetSceneTimer()
        {
            _sceneStartTime = DateTime.Now;
        }
        #endregion
    }
}