using SHS.Assessment.Observer;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace SHS.Assessment
{
    public class TimeoutHandler : MonoBehaviour
    {
        [SerializeField] private float timeoutDuration;
        [SerializeField] private TMP_Text timerText;

        private float timeLeft;
        private bool isRunning = false;

        #region Unity
        private void Start()
        {
            StartCountdown(timeoutDuration);
        }

        private void OnEnable()
        {
            EventBus.Subscribe(GameEvent.GAME_ENDED, OnGameEnded);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(GameEvent.GAME_ENDED, OnGameEnded);
        }

        private void Update()
        {
            if (!isRunning) return;

            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0f)
            {
                timeLeft = 0f;
                isRunning = false;
                UpdateTimerUI();
                OnTimerEnd();
            }
            else
            {
                UpdateTimerUI();
            }
        }

        #endregion

        #region Public
        public void StartCountdown(float duration)
        {
            timeLeft = duration;
            isRunning = true;
            UpdateTimerUI(); // immediate UI update
        }
        #endregion

        #region Private
        private void UpdateTimerUI()
        {
            int seconds = Mathf.CeilToInt(timeLeft);
            timerText.text = seconds + "s";
        }

        private void OnTimerEnd()
        {
            Debug.Log("Countdown finished!");
            EventBus.Publish(GameEvent.GAME_TIMEOUT);
        }

        private void StopCountdown()
        {
            isRunning = false;
        }
        #endregion

        #region Callbacks
        private void OnGameEnded(object Args)
        {
            StopCountdown();
        }
        #endregion
    }
}