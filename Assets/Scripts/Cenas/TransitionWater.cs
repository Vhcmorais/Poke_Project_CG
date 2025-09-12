using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionWater : MonoBehaviour
{
    public string nomeCenaDestino = "CenarioAgua";  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nomeCenaDestino);
        }
    }
}
