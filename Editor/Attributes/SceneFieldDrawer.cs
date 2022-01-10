using System;
using System.Linq;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace HemdemGames.Utilities.Attributes
{
    [CustomPropertyDrawer(typeof(SceneField))]
    internal class SceneFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.serializedObject.Update();
            
            string[] sceneGuids = AssetDatabase.FindAssets("t:Scene");
            string[] sceneNames = sceneGuids.Select(AssetDatabase.GUIDToAssetPath).ToArray();
            GUIContent[] sceneNamesGUI = sceneNames.Select(sceneName => new GUIContent(sceneName)).ToArray();
            
            SerializedProperty sceneGuidProperty = property.FindPropertyRelative("sceneGuid");
            string sceneGuid = sceneGuidProperty.stringValue;
            int selectedIndex = Array.IndexOf(sceneGuids, sceneGuid);

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                selectedIndex = EditorGUI.Popup(position, label, selectedIndex, sceneNamesGUI);
                if (check.changed)
                {
                    sceneGuidProperty.stringValue = sceneGuids[selectedIndex];
                }
            }
            
            property.serializedObject.ApplyModifiedProperties();
        }
    }
}