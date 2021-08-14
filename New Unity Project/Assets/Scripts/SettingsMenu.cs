using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
/*Holds functions for a pause menu
-Toggle Fullscreen
-Quality dropdown
-Resolution dropdown
-Music volume slider
 */
public class SettingsMenu : MonoBehaviour
{
    //Music Slider variables
    public Slider musicSlider;
    public AudioMixer musicAudioMixer;
    public float musicVolume;

    //Resolution Dropdown variables
    public TMPro.TMP_Dropdown resolutionDropDown;
    Resolution[] resolutions;

    private void Start()
    {
        //Creates a list of resolutions for the screen and inserts them all into a dropdown
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i=0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();

        //Sets music to max on awake
        musicVolume = 1;
        musicSlider.value = musicVolume;
        musicAudioMixer.SetFloat("music", Mathf.Log10(musicSlider.value) * 20);
    }

    //Sets resolution of screen ------------------------ NEEDS TO BE FIXED
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    //Sets volume logarithmathically because decibles
    public void setMusicVolume(float m)
    {
        musicAudioMixer.SetFloat("music", Mathf.Log10(m) * 20);
        musicVolume = m;
    }
    //Sets game quality according to Unity Standards
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    //Sets game to fullscreen
    public void SetFullscreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
