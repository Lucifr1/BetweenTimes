using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

	public TMP_Text nameText;
	public TMP_Text dialogueText;
	public Button b1;
	public Button b2;
	public Button b3;

	//public Animator animator;

	private Queue<string> sentences;

	// Use this for initialization

	public void StartDialogue(Dialogue dialogue)
	{
		//animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences = new Queue<string>();

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;

			yield return new WaitForSeconds(0.05f);
		}
	}

	void EndDialogue()
	{
		b1.gameObject.SetActive(false);
		b2.gameObject.SetActive(true);
		b3.gameObject.SetActive(true);
	}

}