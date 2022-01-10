using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HemdemGames.Utilities.Attributes
{
    [Serializable]
    public class SceneField
    {
        [SerializeField] internal string sceneGuid;

        public string GetSceneName()
        {
            return Path.GetFileNameWithoutExtension(GetScenePath());
        }

        public int GetBuildIndex()
        {
            return SceneUtility.GetBuildIndexByScenePath(GetScenePath());
        }

        private string GetScenePath()
        {
            return AssetDatabase.GUIDToAssetPath(sceneGuid);
        }
    }
}