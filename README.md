# unity3d-localization-manager

# Usage

* Create json localization file with editor window(Windows/Localization Editor).
* Load your language and use as following.

```cs
LocalizationManager.LoadLanguage("en_US");
fruit.text = LocalizationManager.GetLocalizedText("apple");
```


