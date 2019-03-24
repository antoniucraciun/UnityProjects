using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level/RiddleData")]
public class RiddleSO : ScriptableObject
{
    public int level;
    public string levelWord;
    [TextArea]
    public string levelRiddle;
}
