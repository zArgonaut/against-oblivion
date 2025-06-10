using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Vida")]
    public int vidaMaxima = 100;
    public int vidaAtual;
    public Image barImage;

    void Awake()
    {
        vidaAtual = vidaMaxima;
        UpdateUI();
    }

    public void LevarDano(int dano)
    {
        vidaAtual -= dano;
        vidaAtual = Mathf.Clamp(vidaAtual, 0, vidaMaxima);
        UpdateUI();
        if (vidaAtual <= 0) Morrer();
    }

    public void Curar(int quantia)
    {
        vidaAtual += quantia;
        vidaAtual = Mathf.Clamp(vidaAtual, 0, vidaMaxima);
        UpdateUI();
    }

    void UpdateUI()
    {
        if (barImage) barImage.fillAmount = (float)vidaAtual / vidaMaxima;
    }

    void Morrer()
    {
        // lógica de morte
        Debug.Log("Player morreu");
    }
}
