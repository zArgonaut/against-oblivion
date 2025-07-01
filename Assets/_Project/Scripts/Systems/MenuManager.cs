using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Jogar()
    {
        GameFlowManager.Instance?.StartGame();
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
