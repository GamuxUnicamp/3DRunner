using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button botaoJogar, botaoOpcoes, botaoCreditos, botaoSair;

    void Start()
    {
        botaoJogar.onClick.AddListener(OnClickBotaoJogar);
        botaoOpcoes.onClick.AddListener(OnClickBotaoOpcoes);
        botaoCreditos.onClick.AddListener(OnClickBotaoCreditos);
        botaoSair.onClick.AddListener(OnClickBotaoSair);
    }

    void OnClickBotaoJogar()
    {
        Debug.Log("botao jogar");
        SceneManager.LoadScene("Jogo");
    }

    void OnClickBotaoOpcoes()
    {
        SceneManager.LoadScene("Opcoes");
    }

    void OnClickBotaoCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    void OnClickBotaoSair()
    {
        Debug.Log("botao sair");
        Application.Quit();
    }
}
