using System.Collections;
using SHS.Assessment.Observer;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SHS.Assessment.SceneLoader
{
    public class SceneLoadHandler : MonoBehaviour
    {
        [SerializeField] private int gameSceneIndex = 1;

        [SerializeField] private LoadScreenHandler LoadPanel;

        [SerializeField] private float minLoadTime = 2f;

        private float timer = 0f;

        #region Unity
        private void OnEnable()
        {
            EventBus.Subscribe(GameEvent.LOAD_GAME, OnGameLoad);
        }

        private void OnDisable()
        {
            EventBus.Subscribe(GameEvent.LOAD_GAME, OnGameLoad);
        }
        #endregion

        #region Public
        #endregion

        #region Private
        private void LoadGameScene()
        {
            StartCoroutine(LoadAsync());
        }

        private IEnumerator LoadAsync()
        {
            LoadPanel.ToggleContainer(true);
            timer = 0f;

            float fakeProgress = 0f;

            AsyncOperation operation = SceneManager.LoadSceneAsync(gameSceneIndex);
            operation.allowSceneActivation = false;

            while (!operation.isDone)
            {
                float targetProgress = Mathf.Clamp01(operation.progress / 0.9f);
                fakeProgress = Mathf.MoveTowards(fakeProgress, targetProgress, Time.deltaTime);

                LoadPanel.SetValues(fakeProgress);
                timer += Time.deltaTime;

                if (operation.progress >= 0.9f && timer >= minLoadTime)
                {
                    while (fakeProgress < 1f)
                    {
                        fakeProgress = Mathf.MoveTowards(fakeProgress, 1f, Time.deltaTime * 0.5f);
                        LoadPanel.SetValues(fakeProgress);
                        yield return null;
                    }

                    yield return new WaitForSeconds(0.01f);
                    operation.allowSceneActivation = true;
                }

                yield return null;
            }
        }

        #endregion

        #region Callbacks
        private void OnGameLoad(object args)
        {
            LoadGameScene();
        }
        #endregion
    }
}