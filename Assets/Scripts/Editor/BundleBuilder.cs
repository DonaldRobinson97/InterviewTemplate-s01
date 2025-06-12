using UnityEngine;
using UnityEditor;

namespace SHS.Assessment.BundleHandler
{
    public class BundleBuilder
    {
        [MenuItem("Assets/Build AssetBundles")]
        static void BuildAllAssetBundles()
        {
            BuildPipeline.BuildAssetBundles("Assets/AssetBundles",
                BuildAssetBundleOptions.None,
                BuildTarget.StandaloneWindows);
        }
    }
}
