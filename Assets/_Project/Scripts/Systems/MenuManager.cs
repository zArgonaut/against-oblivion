using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Jogar()
    {
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
