# Localization-Unity3D

# Usage

* Create xml file for setting languages.
* Load your language and use as following.

```cs
LanguageManager.Instance.LoadLanguage(English);
fruit1.text = LanguageManager.Instance.GetString("Fruits/Apple");
```


