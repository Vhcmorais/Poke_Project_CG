using UnityEngine;

public class NarrativeTrigger : MonoBehaviour
{
    [TextArea(3, 5)]
    public string storyText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            NarrativeManager manager = FindObjectOfType<NarrativeManager>();
            if (manager != null)
            {
                manager.ShowText(storyText);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            NarrativeManager manager = FindObjectOfType<NarrativeManager>();
            if (manager != null)
            {
                manager.HideText();
            }
        }
    }
}