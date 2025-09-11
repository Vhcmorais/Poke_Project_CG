using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InputManager InputManager { get; private set; }

    [Header("Sistema de Diálogo")]
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string faseDescription = "Descrição da sua fase aqui. Coleque informações importantes sobre objetivos, dicas ou lore da fase.";
    public KeyCode dialogueKey = KeyCode.R;

    private bool isDialogueActive = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        InputManager = gameObject.AddComponent<InputManager>();

        // Inicializa o diálogo como desativado
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
    }

    private void Update()
    {
        // Verifica se a tecla R foi pressionada
        if (Input.GetKeyDown(dialogueKey))
        {
            ToggleDialogue();
        }
    }

    public void ToggleDialogue()
    {
        isDialogueActive = !isDialogueActive;

        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(isDialogueActive);

            if (isDialogueActive && dialogueText != null)
            {
                dialogueText.text = faseDescription;
                Time.timeScale = 0f; // Pausa o jogo
            }
            else
            {
                Time.timeScale = 1f; // Retoma o jogo
            }
        }
    }

    // Método para mudar a descrição da fase dinamicamente
    public void SetFaseDescription(string newDescription)
    {
        faseDescription = newDescription;

        // Se o diálogo estiver aberto, atualiza o texto imediatamente
        if (isDialogueActive && dialogueText != null)
        {
            dialogueText.text = faseDescription;
        }
    }

    // Método para fechar o diálogo programaticamente
    public void CloseDialogue()
    {
        isDialogueActive = false;
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    // Método para verificar se o diálogo está aberto
    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }
}