using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Jogar()
    {
        if (GameFlowManager.Instance != null)
            GameFlowManager.Instance.StartGame();
        else
            SceneManager.LoadScene("FaseDeserto");
    }

    public void MostrarLoja()
    {
        SceneManager.LoadScene("LojaEntreFases");
    }

    public void Sair()
    {
        Application.Quit();
    }
}
