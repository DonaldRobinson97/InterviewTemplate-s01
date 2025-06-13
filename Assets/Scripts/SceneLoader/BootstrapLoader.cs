using UnityEngine;
using UnityEngine.SceneManagement;

namespace SHS.Assessment
{
    public class BootstrapLoader : MonoBehaviour
    {
        [SerializeField] private int indextoLoad = 1;

        void Start()
        {
            SceneManager.LoadSceneAsync(indextoLoad, LoadSceneMode.Additive);
        }
    }
}
