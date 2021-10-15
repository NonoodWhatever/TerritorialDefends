using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingMenu : MonoBehaviour
{
    public AudioMixer Audio;
    Resolution[] resolutions;
    public Dropdown ResDropdown;
    private void Start()
    {
        resolutions = Screen.resolutions;

        ResDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
           {
                currentResolutionIndex = i;
            }
        }
        ResDropdown.AddOptions(options);
        ResDropdown.value = currentResolutionIndex;
        ResDropdown.RefreshShownValue();
    }

    public void SetRes (int ResIndex)
    {
        Resolution res = resolutions[ResIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
    public void SetVolume(float volume)
    {
        //Debug.Log(volume);
        Audio.SetFloat("Volume", volume);
    }
    public void SetFullscreen (bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;
    }
}
