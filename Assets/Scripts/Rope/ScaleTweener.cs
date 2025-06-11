using DG.Tweening;
using UnityEngine;

namespace SHS.Assessment.Rope
{
    public class ScaleTweener : MonoBehaviour
    {
        [SerializeField] private float duration = 1f;
        [SerializeField] private Ease ease = Ease.Linear;
        [SerializeField] private float scaleFactor = 1.15f;

        private Tweener scaleTweener;

        #region Unity
        private void Start()
        {
            this.transform.localScale = Vector3.one;
            StartTween();
        }

        void OnDisable()
        {
            scaleTweener?.Kill();
        }
        #endregion

        #region Private
        private void StartTween()
        {
            this.transform.DOScale(scaleFactor, duration).SetEase(ease).SetLoops(-1, LoopType.Yoyo);
        }
        #endregion
    }
}