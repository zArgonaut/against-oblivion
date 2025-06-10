using UnityEngine;
using System.Collections;

public class BossColossoInstavel : MonoBehaviour
{
    public int vidaMaxima = 500;
    private int vidaAtual;
    public GameObject fxEntrada, fxPedras, fxOnda, fxDeslizamento, fxEscudo;
    public Transform[] pontosPedra;
    private bool emFuria = false;

    void Start()
    {
        vidaAtual = vidaMaxima;
        // entrada
        Instantiate(fxEntrada, transform.position, Quaternion.identity);
    }

    public void AtaquePedrada()
    {
        foreach (var p in pontosPedra)
            Instantiate(fxPedras, p.position, Quaternion.identity);
    }

    public void AtaqueOnda()
    {
        Instantiate(fxOnda, transform.position, Quaternion.identity);
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;
        if (vidaAtual <= vidaMaxima/2 && !emFuria)
            StartCoroutine(AtivarFuria());
        if (vidaAtual <= 0) Morrer();
    }

    IEnumerator AtivarFuria()
    {
        emFuria = true;
        Instantiate(fxDeslizamento, transform.position, Quaternion.identity);
        Instantiate(fxEscudo, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5f);
        // remover escudo
    }

    void Morrer()
    {
        Destroy(gameObject);
    }
}