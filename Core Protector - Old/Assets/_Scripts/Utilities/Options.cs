using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Options : MonoBehaviour
{
    public int aaSetting;
    public int textureSetting;
    public bool vSync;
    public int qualitySetting;
    public TMP_Dropdown qualityDrop;
    public TMP_Dropdown aaDrop;
    public TMP_Dropdown textureDrop;
    public Toggle vSyncToggle;
    public PostProcessVolume ppv;

    private void Start()
    {
        aaSetting = PlayerPrefs.GetInt("aaSetting", 3);
        textureSetting = PlayerPrefs.GetInt("textureSetting", 2);
        int useVsync = PlayerPrefs.GetInt("vSync", 0);
        vSync = useVsync == 0 ? false : true;
        qualitySetting = PlayerPrefs.GetInt("qualitySetting", 1);
        if (qualitySetting < 6)
        {
            SetQualitySetting(qualitySetting);
            qualityDrop.value = qualitySetting;
        }
        else
        {
            SetAA(aaSetting);
            SetTexture(textureSetting);
            SetVSync(vSync);
            qualityDrop.value = 5;
            aaDrop.value = aaSetting;
            textureDrop.value = textureSetting;
            vSyncToggle.isOn = vSync;
        }
    }

    public void SetAA(int setting)
    {
        QualitySettings.SetQualityLevel(6);
        qualitySetting = 6;
        qualityDrop.value = 5;
        switch (setting)
        {
            case 0:
                QualitySettings.antiAliasing = 2;
                break;
            case 1:
                QualitySettings.antiAliasing = 4;
                break;
            case 2:
                QualitySettings.antiAliasing = 8;
                break;
            default:
                QualitySettings.antiAliasing = 0;
                break;
        }
        aaSetting = setting;
        SaveSettings();
    }

    public void SetTexture(int setting)
    {
        QualitySettings.SetQualityLevel(6);
        qualitySetting = 6;
        qualityDrop.value = 5;
        switch (setting)
        {
            case 0:
                QualitySettings.masterTextureLimit = 0;
                break;
            case 1:
                QualitySettings.masterTextureLimit = 1;
                break;
            case 2:
                QualitySettings.masterTextureLimit = 2;
                break;
            case 3:
                QualitySettings.masterTextureLimit = 3;
                break;
            default:
                QualitySettings.masterTextureLimit = 1;
                break;
        }
        textureSetting = setting;
        SaveSettings();
    }

    public void SetVSync(bool setting)
    {
        QualitySettings.SetQualityLevel(6);
        qualitySetting = 6;
        qualityDrop.value = 5;
        if (setting)
            QualitySettings.vSyncCount = 1;
        else
            QualitySettings.vSyncCount = 0;
        vSync = setting;
        SaveSettings();
    }

    public void SetQualitySetting(int setting)
    {
        switch (setting)
        {
            case 0:
                QualitySettings.SetQualityLevel(1);
                break;
            case 1:
                QualitySettings.SetQualityLevel(2);
                break;
            case 2:
                QualitySettings.SetQualityLevel(3);
                break;
            case 3:
                QualitySettings.SetQualityLevel(4);
                break;
        }
        qualitySetting = setting;
        SaveSettings();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("aaSetting", aaSetting);
        PlayerPrefs.SetInt("textureSetting", textureSetting);
        int useVsync = vSync == true ? 1 : 0;
        PlayerPrefs.SetInt("vSync", useVsync);
        PlayerPrefs.SetInt("qualitySetting", qualitySetting);
        PlayerPrefs.Save();
    }

    public void SetBloom(bool value)
    {
        ppv.profile.GetSetting<Bloom>().active = value;
    }

    public void SetVignette(bool value)
    {
        ppv.profile.GetSetting<Vignette>().active = value;
    }

    public void SetGrading(bool value)
    {
        ppv.profile.GetSetting<ColorGrading>().active = value;
    }
}
