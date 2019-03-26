using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pulse;
    public GameObject shield;
    public GameObject target;

    public Slider sensitivity;

    public static float sens;
    public int powerUpsUsed = 0;
    public float pulseCooldown = 5f;
    public float shieldCooldown = 20f;

    private void Start()
    {
        sens = PlayerPrefs.GetFloat("sensitivity", 0.5f);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality", 0));
        switch (QualitySettings.GetQualityLevel())
        {
            case 0:
                pulse.GetComponent<DynamicCircle>().SetNumberOfPoints(8);
                break;
            case 2:
                pulse.GetComponent<DynamicCircle>().SetNumberOfPoints(16);
                break;
            case 3:
                pulse.GetComponent<DynamicCircle>().SetNumberOfPoints(32);
                break;
            default:
                break;
        }
        sensitivity.value = sens;
    }

    private void Update()
    {
        if (pulseCooldown > 0)
        {
            pulseCooldown -= Time.deltaTime;
        }

        if (shieldCooldown > 0)
        {
            shieldCooldown -= Time.deltaTime;
        }
    }

    public void SetSensitivity(float value)
    {
        sens = value;
        PlayerPrefs.SetFloat("sensitivity", sens);
        PlayerPrefs.Save();
    }
    
    #region GraphicsSettings
    public void SetToLow()
    {
        QualitySettings.SetQualityLevel(0);
        pulse.GetComponent<DynamicCircle>().SetNumberOfPoints(8);
        PlayerPrefs.SetInt("quality", 0);
        PlayerPrefs.Save();
    }

    public void SetToMedium()
    {
        QualitySettings.SetQualityLevel(2);
        pulse.GetComponent<DynamicCircle>().SetNumberOfPoints(16);
        PlayerPrefs.SetInt("quality", 2);
        PlayerPrefs.Save();
    }

    public void SetToHigh()
    {
        QualitySettings.SetQualityLevel(3);
        pulse.GetComponent<DynamicCircle>().SetNumberOfPoints(32);
        PlayerPrefs.SetInt("quality", 3);
        PlayerPrefs.Save();
    }
    #endregion

    public void OnPulseClicked()
    {
        if (pulseCooldown <= 0)
        {
            Vector3 pos = target.transform.position;
            pos -= new Vector3(0, 0.75f, 0);
            Instantiate(pulse, pos, Quaternion.identity);
            pulseCooldown = 5f;
            powerUpsUsed++;
            AchievementSystem.Notify(AchievementType.PowerUps, powerUpsUsed);
        }
    }
    public void OnShieldClicked()
    {
        if (shieldCooldown <= 0)
        {
            Vector3 pos = target.transform.position;
            pos -= new Vector3(0, 0.75f, 0);
            Instantiate(shield, pos, Quaternion.identity);
            shieldCooldown = 20f + Data.level/2;
            powerUpsUsed++;
            AchievementSystem.Notify(AchievementType.PowerUps, powerUpsUsed);
        }
    }
}
