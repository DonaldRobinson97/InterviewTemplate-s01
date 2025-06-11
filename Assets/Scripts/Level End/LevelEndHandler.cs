using DG.Tweening;
using SHS.Assessment.Observer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SHS.Assessment
{
    public class LevelEndHandler : MonoBehaviour
    {
        [SerializeField] private Image bgImage;

        [SerializeField] private Transform reloadButton;

        [SerializeField] private TMP_Text levelEndText;

        [SerializeField] private string levelWinMessage;

        [SerializeField] private string levelLoseMessage;

        [SerializeField] private string levelTimeoutMessage;

        [SerializeField] private float tweenDuration = 0.75f;

        [SerializeField] private Ease ease = Ease.OutQuad;

        #region Unity
        private void OnEnable()
        {
            EventBus.Subscribe(GameEvent.GAME_ENDED, OnLevelEnded);
            EventBus.Subscribe(GameEvent.GAME_TIMEOUT, OnLevelEnded);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(GameEvent.GAME_ENDED, OnLevelEnded);
            EventBus.Unsubscribe(GameEvent.GAME_TIMEOUT, OnLevelEnded);
        }
        #endregion

        #region Public
        private void Start()
        {
            bgImage.transform.localScale = Vector3.zero;
            reloadButton.localScale = Vector3.zero;
        }
        #endregion

        #region Private
        private void tweenLevelEnd()
        {
            bgImage.transform.DOScale(Vector3.one, tweenDuration).SetEase(ease).OnComplete(
                () =>
                {
                    reloadButton.transform.DOScale(Vector3.one, tweenDuration).SetEase(ease);
                }
            );
        }
        #endregion

        #region Callbacks
        private void OnLevelEnded(object Args)
        {
            if (Args != null)
            {
                bool iswin = (bool)Args;
                levelEndText.text = iswin ? levelWinMessage : levelLoseMessage;
            }
            else
            {
                levelEndText.text = levelTimeoutMessage;
            }
            tweenLevelEnd();
        }
        #endregion
    }
}