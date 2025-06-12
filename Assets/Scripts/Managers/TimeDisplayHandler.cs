using TMPro;
using UnityEngine;
using System;

namespace SHS.Assessment.Managers
{
    public class TimeDisplayHandler : MonoBehaviour
    {
        [SerializeField] private TMP_Text sceneText;
        [SerializeField] private TMP_Text sessionText;
        [SerializeField] private TMP_Text todayText;
        [SerializeField] private TMP_Text lifetimeText;

        #region Unity
        private void Start()
        {
            InvokeRepeating(nameof(UpdateText), 0f, 1f);
        }
        #endregion

        #region Private
        private void UpdateText()
        {
            sceneText.text = $"Scene Time: {FormatTime(TimeManager.Instance.SceneTime)}";
            sessionText.text = $"Session Time: {FormatTime(TimeManager.Instance.SessionTime)}";
            todayText.text = $"Today Time: {FormatTime(TimeManager.Instance.TodayTime)}";
            lifetimeText.text = $"Lifetime Time: {FormatTime(TimeManager.Instance.LifetimeTime)}";
        }

        private string FormatTime(TimeSpan time)
        {
            if (time.TotalDays >= 1)
                return $"{(int)time.TotalDays}d {time.Hours}h {time.Minutes}m {time.Seconds}s";
            else
                return $"{time.Hours}h {time.Minutes}m {time.Seconds}s";
        }
        #endregion
    }
}