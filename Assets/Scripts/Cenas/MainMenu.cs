using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Chamado pelo bot�o Jogar
    public void PlayGame()
    {
        SceneManager.LoadScene("CenaInicial"); // Coloque o nome da cena principal
    }

    // Chamado pelo bot�o Sair
    public void QuitGame()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit(); // Funciona quando o jogo estiver buildado
    }
}