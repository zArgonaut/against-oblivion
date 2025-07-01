using UnityEngine;

public class PlayerMeleeCombat : MonoBehaviour
{
    public int dano = 20;
    public float alcance = 1f;
    public LayerMask inimigoLayer;
    public Transform pontoAtaque;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
            Atacar();
    }

    void Atacar()
    {
        Collider2D hit = Physics2D.OverlapCircle(pontoAtaque.position, alcance, inimigoLayer);
        if (hit)
        {
            EnemyHealth inimigo = hit.GetComponent<EnemyHealth>();
            if (inimigo) inimigo.LevarDano(dano);
        }
    }
}
