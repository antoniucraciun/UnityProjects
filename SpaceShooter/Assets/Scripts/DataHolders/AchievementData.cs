using UnityEngine;

[CreateAssetMenu(menuName = "Data/Achievement")]
public class AchievementData : ScriptableObject
{
    public string description;
    public int reward;
    public string rewardType;
    public int requirement;
    public string requirementType;
    public Sprite icon;
}
