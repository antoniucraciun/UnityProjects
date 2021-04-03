using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryCamera : MonoBehaviour
{
	public List<Dialogue> dialogues;

	public TMP_Text dialogue;
	public TMP_Text characterName;

	public Transform initialPosition;
	public Transform kidDialoguePosition;

	public GameObject dialogueUI;

	int index;

	public GameObject child;

	private void Start()
	{
		index = 0;
		Camera.main.transform.position = initialPosition.position;
		Camera.main.transform.rotation = initialPosition.rotation;
		StartDialogue();
	}

	public void StartDialogue()
	{
		dialogue.text = dialogues[index].dialogue;
		characterName.text = dialogues[index].characterName;
	}

	public void ContinueDialogue()
	{
		index++;
		if (index >= dialogues.Count)
		{
			dialogueUI.SetActive(false);
			Camera.main.GetComponent<ThirdPersonCamera>().enabled = true;
			child.GetComponent<Animator>().SetBool("isTalking", false);
			return;
		}
		dialogue.text = dialogues[index].dialogue;
		characterName.text = dialogues[index].characterName;
		if(index == 5)
		{
			Camera.main.transform.position = kidDialoguePosition.position;
			Camera.main.transform.rotation = kidDialoguePosition.rotation;
		}
	}

	public void SetAnimation()
	{
		child.GetComponent<Animator>().SetBool("isTalking", true);
	}

}
