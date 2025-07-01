// Controle básico de combate corpo a corpo do jogador.
// TODO: expandir com combos e diferentes tipos de ataque.
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMeleeCombat : MonoBehaviour
{
    [Header("Configura\u00e7\u00f5es de Ataque")]
    public Transform attackPoint; // Origem do ataque
    public float attackRange = 1f;
    public int damage = 1;
    public LayerMask enemyLayers;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Attack();
    }

    void Attack()
    {
        anim.SetTrigger("Attack");

        Vector3 origem = attackPoint ? attackPoint.position : transform.position;
        // Detecta inimigos no alcance do ataque
        Collider2D[] hits = Physics2D.OverlapCircleAll(origem, attackRange, enemyLayers);
        foreach (var hit in hits)
        {
            // Envia dano caso o alvo possua um m\u00e9todo apropriado
            hit.SendMessage("LevarDano", damage, SendMessageOptions.DontRequireReceiver);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 origem = attackPoint ? attackPoint.position : transform.position;
        Gizmos.DrawWireSphere(origem, attackRange);
    }
}
