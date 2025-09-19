using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NarrativeManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.03f;

    private Queue<string> sentences;
    private Coroutine typingCoroutine;

    void Awake()
    {
        sentences = new Queue<string>();
    }

    public void ShowText(string fullText)
    {
        sentences.Clear();

        string[] lines = fullText.Split(new char[] { '.', '\n' });

        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
                sentences.Enqueue(line.Trim() + ".");
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            HideText();
            return;
        }

        string sentence = sentences.Dequeue();

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        // Espera 0.8 segundos antes de mostrar a próxima frase
        yield return new WaitForSeconds(0.8f);
        DisplayNextSentence();
    }

    public void HideText()
    {
        dialogueText.text = "";
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);
    }
}