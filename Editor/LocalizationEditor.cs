#region License
/*================================================================
Product:    LocalizationManager
Developer:  Onur Tanrıkulu
Company:    Onur Tanrikulu
Date:       24/01/2017 17:40

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using UnityEngine;
using UnityEditor;
using System.IO;

public class LocalizationEditor : EditorWindow
{
    private static string localizationDirectory;
    private string languageCode;
    public LocalizationData localizationData;
 
    [MenuItem("Window/Localization Editor")]
    private static void Inıt()
    {
        EditorWindow.GetWindow(typeof(LocalizationEditor)).Show();

        localizationDirectory = Path.Combine(Application.streamingAssetsPath, "Localization");

        if (!Directory.Exists(localizationDirectory))
            {
                Directory.CreateDirectory(localizationDirectory);
            }
    }

    private void OnGUI()
    {
        languageCode = EditorGUILayout.TextField("Language Code", languageCode);

        if (localizationData != null)
        {
            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty serializedProperty = serializedObject.FindProperty("localizationData");
            EditorGUILayout.PropertyField(serializedProperty, true);
            serializedObject.ApplyModifiedProperties();

            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Save", GUILayout.Height(50)))
            {
                SaveData();
            } 
        }
        else
        {
            GUILayout.FlexibleSpace();
        }
            
        if (GUILayout.Button ("Load", GUILayout.Height(50))) 
        {
            LoadData ();
        }

        if (GUILayout.Button ("Create", GUILayout.Height(50)))
        {
            CreateNewData ();
        }
    }

    private void LoadData()
    {
        string filePath = EditorUtility.OpenFilePanel ("Select localization data file", localizationDirectory, "json");

        if (!string.IsNullOrEmpty (filePath)) 
        {
            string jsonData = File.ReadAllText (filePath);

            languageCode = Path.GetFileNameWithoutExtension(filePath);
            localizationData = JsonUtility.FromJson<LocalizationData> (jsonData);
        }
    }

    private void SaveData()
    {
        string fileName = languageCode + ".json";
        string filePath = Path.Combine(localizationDirectory, fileName);

        if (!string.IsNullOrEmpty(filePath))
        {
            string jsonData = JsonUtility.ToJson(localizationData);
            File.WriteAllText(filePath, jsonData);
            AssetDatabase.Refresh();
        }
    }

    private void CreateNewData()
    {
        localizationData = new LocalizationData ();
    }
}


