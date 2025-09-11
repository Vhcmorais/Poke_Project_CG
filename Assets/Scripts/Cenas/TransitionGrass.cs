using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionGrass : MonoBehaviour
{
    public string nomeCenaDestino = "CenarioPlanta";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entrou no portal Grass. Carregando: " + nomeCenaDestino);
            SceneManager.LoadScene(nomeCenaDestino);
        }
    }
}