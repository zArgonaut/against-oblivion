using UnityEngine;

public class HordaManager : MonoBehaviour
{
    [Header("Configura\u00e7\u00e3o de Spawn")]
    public GameObject[] inimigos;
    public Transform[] pontosSpawn;
    public float intervaloSpawn = 5f;

    [Header("Boss")]
    public GameObject bossPrefab;
    public int pontosParaBoss = 100;

    private float timer;
    private bool bossSpawnado = false;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnInimigo();
            timer = intervaloSpawn;
        }

        if (!bossSpawnado && ScoreManager.instance != null && ScoreManager.instance.pontos >= GetPontosParaBoss())
        {
            SpawnBoss();
        }
    }

    void SpawnInimigo()
    {
        if (inimigos.Length == 0 || pontosSpawn.Length == 0) return;

        int idxInimigo = Random.Range(0, inimigos.Length);
        int idxPonto = Random.Range(0, pontosSpawn.Length);

        Instantiate(inimigos[idxInimigo], pontosSpawn[idxPonto].position, Quaternion.identity);
    }

    void SpawnBoss()
    {
        if (bossPrefab == null || pontosSpawn.Length == 0) return;
        bossSpawnado = true;
        int idxPonto = Random.Range(0, pontosSpawn.Length);
        Instantiate(bossPrefab, pontosSpawn[idxPonto].position, Quaternion.identity);
    }

    public int GetPontosParaBoss()
    {
        var diff = GameManager.Instance ? GameManager.Instance.CurrentDifficulty : GameManager.Difficulty.Normal;
        switch (diff)
        {
            case GameManager.Difficulty.Facil:
                return Mathf.RoundToInt(pontosParaBoss * 0.75f);
            case GameManager.Difficulty.Dificil:
                return Mathf.RoundToInt(pontosParaBoss * 1.5f);
            default:
                return pontosParaBoss;
        }
    }
}
