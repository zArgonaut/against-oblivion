using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 10f;
    public int dano = 10;
    public float lifeTime = 3f;
    public LayerMask hitMask;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & hitMask) != 0)
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.LevarDano(dano);
            }
            Destroy(gameObject);
        }
    }
}
