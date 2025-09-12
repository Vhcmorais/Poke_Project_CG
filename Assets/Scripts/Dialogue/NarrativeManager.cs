using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class NarrativeManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.5f;

    private bool isTyping = false;

    void Start()
    {
        dialogueText.text = "";
    }

    public void ShowText(string newText)
    {
        if(!isTyping)
        {
            StartCoroutine(TypeText(newText));
        }
    }

    private IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    public void HideText()
    {
        if(!isTyping)
        {
            StartCoroutine(DeleteText());
        }
    }

    private IEnumerator DeleteText()
    {
        isTyping = true;

        while(dialogueText.text.Length > 0)
        {
            dialogueText.text =
                dialogueText.text.Substring(0, dialogueText.text.Length - 1);
            yield return new
            WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }
}
