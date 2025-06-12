using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


namespace SHS.Assessment.SceneLoader
{
    public class BundleLoader : MonoBehaviour
    {
        [Header("Bundle Config")]
        [SerializeField] private string bundleUrl = "https://yourusername.github.io/unity-assetbundles/mybundle";
        [SerializeField] private string prefabName = "BgImage";

        [Header("Spawn Config")]
        [SerializeField] private Vector2 spawnPosition = Vector2.zero;
        [SerializeField] private Vector2 spawnRotation = Vector2.zero;

        private IEnumerator Start()
        {
            yield return StartCoroutine(DownloadAndLoadPrefab());
        }

        private IEnumerator DownloadAndLoadPrefab()
        {
            using UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(bundleUrl);
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to download AssetBundle: " + request.error);
                yield break;
            }

            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
            if (bundle == null)
            {
                Debug.LogError("Failed to load AssetBundle content.");
                yield break;
            }

            GameObject prefab = bundle.LoadAsset<GameObject>(prefabName);
            if (prefab == null)
            {
                Debug.LogError("Prefab not found in AssetBundle: " + prefabName);
                yield break;
            }

            Instantiate(prefab, spawnPosition, Quaternion.Euler(spawnRotation));
            bundle.Unload(false);
        }
    }
}