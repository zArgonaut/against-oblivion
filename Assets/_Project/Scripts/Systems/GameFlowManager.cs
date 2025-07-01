using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    public static GameFlowManager instancia;
    public string[] fases;
    int indice;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void Avancar()
    {
        if (indice + 1 >= fases.Length)
            SceneManager.LoadScene("MainMenu");
        else
        {
            indice++;
            SceneManager.LoadScene(fases[indice]);
        }
    }

    public void Resetar()
    {
        indice = 0;
        SceneManager.LoadScene(fases[indice]);
    }
}
