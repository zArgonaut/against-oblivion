using UnityEngine;
using System.Collections;

public class BossSombraCongelada : MonoBehaviour
{
    public enum Estado { Vulneravel, Oculto, Surprise }
    public Estado estado = Estado.Vulneravel;
    public float tempoVulneravel = 3f;
    public GameObject fxGarras, fxUivo, fxRajadaNeve, prefabDrone;
    private float timer;

    void Start()
    {
        timer = tempoVulneravel;
    }

    void Update()
    {
        if (estado == Estado.Vulneravel)
        {
            timer -= Time.deltaTime;
            if (timer <= 0) EntrarOculto();
        }
        // estados oculto e surprise
    }

    void EntrarOculto()
    {
        estado = Estado.Oculto;
        // lançar rajadas e drones
    }

    public void LevarDano(int dano)
    {
        if (estado != Estado.Vulneravel) return;
        Morrer();
    }

    public void SurpriseAttack()
    {
        estado = Estado.Surprise;
        // animar ataque e garras
        Instantiate(fxGarras, transform.position, Quaternion.identity);
        StartCoroutine(RelapseToOculto());
    }

    IEnumerator RelapseToOculto()
    {
        yield return new WaitForSeconds(5f);
        // uivar e tremer
        Instantiate(fxUivo, transform.position, Quaternion.identity);
        EntrarOculto();
    }

    void Morrer()
    {
        Destroy(gameObject);
        if (GameFlowManager.Instance != null)
            GameFlowManager.Instance.AdvanceLevel();
    }
}