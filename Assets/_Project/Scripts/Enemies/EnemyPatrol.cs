using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float velocidade = 2f;
    public Transform[] pontosPatrulha;
    private int indice = 0;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (pontosPatrulha.Length == 0) return;
        Transform alvo = pontosPatrulha[indice];
        Vector2 dir = (alvo.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(dir.x * velocidade, rb.linearVelocity.y);
        if (Vector2.Distance(transform.position, alvo.position) < 0.2f)
            indice = (indice + 1) % pontosPatrulha.Length;
    }
}
