# Localization-Unity3D
## Features

* Control your vehicle like subway surfers.
* Smooth lane changing with speed.
* Player acceleration.
* Editable lane size and numbers.

# Usage

* Create xml file for setting languages.
* Load your language and use as following.

```cs
LanguageManager.Instance.LoadLanguage(English);
fruit1.text = LanguageManager.Instance.GetString("Fruits/Apple");
```


