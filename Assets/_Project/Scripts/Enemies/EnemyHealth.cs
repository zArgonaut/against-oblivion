using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Vida")]
    public int vidaMaxima = 50;
    private int vidaAtual;

    [Header("Feedback Visual")]
    public GameObject fxDano;
    public GameObject fxMorte;
    public float tempoDestruicao = 2f;

    [Header("Pontuação")]
    public EnemyType tipo = EnemyType.Melee;

    private SpriteRenderer spriteRenderer;
    private Color corOriginal;

    void Start()
    {
        vidaAtual = vidaMaxima;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
            corOriginal = spriteRenderer.color;
    }

    public void LevarDano(int dano)
    {
        vidaAtual -= dano;

        if (fxDano != null)
            Instantiate(fxDano, transform.position, Quaternion.identity);

        StartCoroutine(FlashDano());

        if (vidaAtual <= 0)
            Morrer();
    }

    System.Collections.IEnumerator FlashDano()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = corOriginal;
        }
    }

    void Morrer()
    {
        if (fxMorte != null)
            Instantiate(fxMorte, transform.position, Quaternion.identity);

        // Adiciona pontuação
        if (ScoreManager.instance != null)
            ScoreManager.instance.AdicionarPontos(tipo);

        Destroy(gameObject, tempoDestruicao);
    }
}
