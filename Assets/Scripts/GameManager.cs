using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InputManager InputManager { get; private set; }

    [Header("Sistema de Di�logo")]
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string faseDescription = "Descri��o da sua fase aqui. Coleque informa��es importantes sobre objetivos, dicas ou lore da fase.";
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

        // Inicializa o di�logo como desativado
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

    // M�todo para mudar a descri��o da fase dinamicamente
    public void SetFaseDescription(string newDescription)
    {
        faseDescription = newDescription;

        // Se o di�logo estiver aberto, atualiza o texto imediatamente
        if (isDialogueActive && dialogueText != null)
        {
            dialogueText.text = faseDescription;
        }
    }

    // M�todo para fechar o di�logo programaticamente
    public void CloseDialogue()
    {
        isDialogueActive = false;
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    // M�todo para verificar se o di�logo est� aberto
    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }
}