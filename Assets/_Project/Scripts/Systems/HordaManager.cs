using UnityEngine;

public class HordaManager : MonoBehaviour
{
    [Header("Configura\u00e7\u00e3o de Spawn")]
    public GameObject[] inimigos;
    public Transform[] pontosSpawn;
    public float intervaloSpawn = 5f;

    private float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnInimigo();
            timer = intervaloSpawn;
        }
    }

    void SpawnInimigo()
    {
        if (inimigos.Length == 0 || pontosSpawn.Length == 0) return;

        int idxInimigo = Random.Range(0, inimigos.Length);
        int idxPonto = Random.Range(0, pontosSpawn.Length);

        Instantiate(inimigos[idxInimigo], pontosSpawn[idxPonto].position, Quaternion.identity);
    }
}
