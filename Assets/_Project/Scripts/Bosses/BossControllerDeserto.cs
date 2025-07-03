using UnityEngine;
using System.Collections;

public class BossControllerDeserto : MonoBehaviour
{
    public int vidaMaxima = 200;
    private int vidaAtual;
    public GameObject fxTempestade;
    public float intervaloAtaque = 5f;
    private bool evasao = false;

    void Start()
    {
        vidaAtual = vidaMaxima;
        InvokeRepeating(nameof(AtacarEmArea), 2f, intervaloAtaque);
    }

    void AtacarEmArea()
    {
        // Lógica de ataque em área de areia
        StartCoroutine(AtivarEvasao());
    }

    IEnumerator AtivarEvasao()
    {
        evasao = true;
        float duracao = Random.Range(2f, 3f);
        yield return new WaitForSeconds(duracao);
        evasao = false;
    }

    public void LevarDano(int dano)
    {
        if (evasao && Random.value < 0.5f) return;
        vidaAtual -= dano;
        if (vidaAtual <= vidaMaxima/2 && fxTempestade && !fxTempestade.activeSelf)
            fxTempestade.SetActive(true);
        if (vidaAtual <= 0) Morrer();
    }

    void Morrer()
    {
        Destroy(gameObject);
        if (GameManager.Instance != null)
            GameManager.Instance.NextPhase();
    }
}