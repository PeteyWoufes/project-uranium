using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {
    public GameObject settingsUI;
    public GameObject topLayerUI;
    Resolution[] resolutions;
    public Dropdown dropdownMenu;

    public void Start()
    {
        resolutions = Screen.resolutions;
        dropdownMenu.onValueChanged.AddListener(delegate { Screen.SetResolution(resolutions[dropdownMenu.value].width, resolutions[dropdownMenu.value].height, false); });
        for (int i = 0; i < resolutions.Length; i++)
        {
            dropdownMenu.options[i].text = ResToString(resolutions[i]);
            dropdownMenu.value = i;
            dropdownMenu.options.Add(new Dropdown.OptionData(dropdownMenu.options[i].text));

        }
    }

    string ResToString(Resolution res)
    {
        return res.width + " x " + res.height;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit button pressed.");
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Play button pressed.");
    }

    public void Settings()
    {
        topLayerUI.SetActive(false);
        Debug.Log("Settings button pressed.");
    }
}
