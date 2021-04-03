using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicDialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
	public string characterName;
	[TextArea]
	public string dialogue;
}
