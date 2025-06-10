using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SHS.Assessment
{
    public class LoadScreenHandler : MonoBehaviour
    {
        [SerializeField] private GameObject mainContainer;
        [SerializeField] private TMP_Text loadText;
        [SerializeField] private Image progressImage;
        [SerializeField] private string loadTextPrefix = "Loading... ";

        #region Unity
        private void Start()
        {
            Initialise();
        }
        #endregion

        #region Public
        public void SetValues(float progress)
        {
            progressImage.fillAmount = progress;
            loadText.text = loadTextPrefix + Mathf.RoundToInt(progress * 100) + "%";
        }

        public void ToggleContainer(bool toggle)
        {
            mainContainer.SetActive(toggle);
        }
        #endregion

        #region Private
        private void Initialise()
        {
            SetValues(0f);
            ToggleContainer(false);
        }
        #endregion
    }
}
