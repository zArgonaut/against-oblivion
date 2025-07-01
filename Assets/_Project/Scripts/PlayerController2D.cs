using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Header("Movimentação")]
    public float velocidade = 5f;
    public float forcaPulo = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    private bool estaNoChao;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * velocidade, rb.velocity.y);
    }

    void Jump()
    {
        estaNoChao = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (estaNoChao && Input.GetButtonDown("Jump"))
            rb.velocity = new Vector2(rb.velocity.x, forcaPulo);
    }
}
