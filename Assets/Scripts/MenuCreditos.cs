using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCreditos : MonoBehaviour
{
    public Button botaoVoltar;

    void Start()
    {
        botaoVoltar.onClick.AddListener(OnClickBotaoVoltar);
    }

    void OnClickBotaoVoltar(){
        SceneManager.LoadScene("MainMenu");
    }
}
