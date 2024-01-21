using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Changes the language settings of both scenes.
/// </summary>
public class LanguageSettings : MonoBehaviour
{
    [SerializeField] List<GameObject> UI_Eng;
    [SerializeField] List<GameObject> UI_Ger;

    // Standard Language is English.
    public static string Language = "English";

    private void Start()
    {
        if (Language == "English")
        {
            EnglishUI();
        }
        else
        {
            GermanUI();
        }
    }

    /// <summary>
    /// Switches all UI-Elements to English.
    /// </summary>
    public void EnglishUI()
    {
        foreach (var obj in UI_Ger)
           obj.SetActive(false);

        foreach (var obj in UI_Eng)
           obj.SetActive(true);

        Language = "English";
    }

    /// <summary>
    /// Switches all UI-Elements to German.
    /// </summary>
    public void GermanUI()
    {
        foreach (var obj in UI_Ger)
            obj.SetActive(true);

        foreach (var obj in UI_Eng)
            obj.SetActive(false);

        Language = "German";
    }
}
