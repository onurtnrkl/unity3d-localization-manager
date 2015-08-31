using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class LanguageManager : ScriptableObject
{
    #region Singleton
    private static LanguageManager instance = null;

    public static LanguageManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = CreateInstance<LanguageManager>();
            }
            return instance;
        }
    }
    #endregion

    private XmlDocument doc = null;
    private XmlElement ele = null;

    private string languagePath = string.Empty;
    private string[] languageFiles = null;

    void Awake()
    {
        if(PlayerPrefs.GetString("LANGUAGE") == null)
        {
            PlayerPrefs.SetString("LANGUAGE", Application.systemLanguage.ToString());
        }
        languagePath = Application.dataPath + "/Resources/Languages/";
        CollectLanguages();
        LoadLanguage(PlayerPrefs.GetString("LANGUAGE"));
    }

    void OnDestroy()
    {
        doc = null;
        ele = null;
    }

    private void CollectLanguages()
    {
        DirectoryInfo dir = new DirectoryInfo(languagePath);
        FileInfo[] files = dir.GetFiles("*.xml");
        languageFiles = new string[files.Length];
        int i = 0;
        foreach (FileInfo go in files)
        {
            languageFiles[i] = go.FullName;
            i++;
        }
    }

    private string GetLanguageFile(string language)
    {
        foreach (string go in languageFiles)
        {
            if (go.EndsWith(language + ".xml"))
            {
                return go;
            }
        }
        return string.Empty;
    }

    public void LoadLanguage(string language)
    {
        string loadFile = GetLanguageFile(language);
        doc = new XmlDocument();
        StreamReader reader = new StreamReader(loadFile);
        doc.Load(reader);
        ele = doc.DocumentElement;
        reader.Close();
        PlayerPrefs.SetString("LANGUAGE", language);
    }

    public string GetString(string path)
    {
        XmlNode node = ele.SelectSingleNode(path);
        if (node == null)
        {
            return path;
        }
        else
        {
            string value = node.InnerText;
            value = value.Replace("\\n", "\n");
            return value;
        }
    }
}