using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [HideInInspector] public int pontos = 0;
    public TextMeshProUGUI textoPontos;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void AdicionarPontos(int valor)
    {
        pontos += valor;
        AtualizarUI();
    }

    void AtualizarUI()
    {
        if (textoPontos) textoPontos.text = "PONTOS: " + pontos;
    }
}
