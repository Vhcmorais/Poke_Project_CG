using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionAir : MonoBehaviour
{
    public string nomeCenaDestino = "CenaAr";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entrou no portal Ar. Carregando: " + nomeCenaDestino);
            SceneManager.LoadScene(nomeCenaDestino);
        }
    }
}