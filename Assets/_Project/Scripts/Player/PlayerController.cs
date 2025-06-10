
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float velocidade = 5f;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 movimento = new Vector2(h, v);
        rb.velocity = movimento * velocidade;
    }
}
