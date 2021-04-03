using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementDispaly : MonoBehaviour
{
    public AchievementData ach;
    public SaveVars vars;

    public Image icon;

    public int reward;
    public int requirement;

    public TMP_Text descriptionText;
    public TMP_Text requirementText;

    bool claimed = false;

	void Start ()
    {
        reward = ach.reward;
        requirement = ach.requirement;
        descriptionText.text = ach.description;
        requirementText.text = vars.astraEnemiesKilled.ToString() + " / " + requirement.ToString();
        icon.sprite = ach.icon;
    }

    public void OnClaimClicked()
    {
        if (vars.astraEnemiesKilled >= requirement)
        {
            AchievementController.instance.ManageClaims(reward, ach.requirementType);
        }
    }
}
