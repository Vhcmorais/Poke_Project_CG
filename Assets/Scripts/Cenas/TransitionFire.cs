using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionFire : MonoBehaviour
{
    public string nomeCenaDestino = "CenaFogo";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entrou no portal Grass. Carregando: " + nomeCenaDestino);
            SceneManager.LoadScene(nomeCenaDestino);
        }
    }
}