using UnityEngine;

public class EnemyAdvancedAI : MonoBehaviour
{
    public Transform jogador;
    public float velocidade = 2.5f;
    public float distanciaStop = 2f;
    public Transform[] pontosAlternativos;

    private Rigidbody2D rb;
    private Animator animator;
    private Transform destino;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        destino = pontosAlternativos.Length>0? pontosAlternativos[0] : jogador;
    }

    void Update()
    {
        if (jogador == null) return;
        float d = Vector2.Distance(transform.position, jogador.position);
        if (d < distanciaStop)
        {
            // escolhe rota alternativa
            int idx = Random.Range(0, pontosAlternativos.Length);
            destino = pontosAlternativos[idx];
        }
        else
        {
            destino = jogador;
        }
        Vector2 dir = (destino.position - transform.position).normalized;
        rb.velocity = new Vector2(dir.x * velocidade, rb.velocity.y);
        if (animator) animator.SetFloat("Velocidade", Mathf.Abs(dir.x));
        transform.localScale = new Vector3(Mathf.Sign(dir.x), 1, 1);
    }
}
