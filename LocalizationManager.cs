#region License
/*================================================================
Product:    LocalizationManager
Developer:  Onur Tanrıkulu
Company:    Onur Tanrikulu
Date:       24/01/2017 16:14

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public static class LocalizationManager
{
    private static Dictionary<string, string> localizedTexts;
   
    /// <summary>
    /// Gets the localized text.
    /// </summary>
    /// <returns>The localized text.</returns>
    /// <param name="key">localized key value("apple", "start")</param>
    public static string GetLocalizedText(string key)
    {
        string text = string.Empty;

        if (localizedTexts.ContainsKey(key))
        {
            text = localizedTexts[key];
        }
        else
        {
            Debug.LogError("Cannot load text: " + key);
        }

        return text;
    }

    /// <summary>
    /// Loads language file from harddrive.
    /// </summary>
    /// <param name="languageCode">international language code("en_US", "de_DE", "tr_TR")</param>
    public static void LoadLanguage(string languageCode)
    {
        localizedTexts = new Dictionary<string, string>();
        string fileDirectory = Path.Combine(Application.streamingAssetsPath, "Localization");
        string fileName = languageCode + ".json";
        string filePath = Path.Combine(fileDirectory, fileName);

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            LocalizationData data = JsonUtility.FromJson<LocalizationData>(jsonData);

            for(int i = 0; i < data.items.Length; i++)
            {
                LocalizationItem item = data.items[i];
                localizedTexts.Add(item.key, item.text);
            }
        }
        else
        {
            Debug.LogError("Cannot load file: " + filePath);
        }
    }
}
