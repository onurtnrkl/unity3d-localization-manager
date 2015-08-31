using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    public Text fruit1;
    public Text fruit2;
    public Text fruit3;

	void Start ()
    {
        SetText();
    }

    public void OnClick(string language)
    {
        LanguageManager.Instance.LoadLanguage(language);
        SetText();
    }

    private void SetText()
    {
        fruit1.text = LanguageManager.Instance.GetString("Fruits/Apple");
        fruit2.text = LanguageManager.Instance.GetString("Fruits/Raspberry");
        fruit3.text = LanguageManager.Instance.GetString("Fruits/Banana");
    }
}
