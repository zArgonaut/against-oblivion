using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject playerPrefab;
    public Transform playerSpawn;

    public GameObject hordaManagerPrefab;
    public Transform[] spawnPoints;

    public GameObject scoreHUDPrefab;
    public GameObject adminPanelPrefab;

    void Awake()
    {
        // Instancia o jogador
        if (playerPrefab != null && playerSpawn != null)
            Instantiate(playerPrefab, playerSpawn.position, Quaternion.identity);

        // Instancia o HordaManager e configura pontos de spawn,
        // evitando duplicatas caso já exista um ativo na cena
        var hordaManagerExistente = FindObjectOfType<HordaManager>();
        if (hordaManagerPrefab != null && hordaManagerExistente == null)
        {
            var hordaGO = Instantiate(hordaManagerPrefab);
            var horda = hordaGO.GetComponent<HordaManager>();
            if (horda != null)
                horda.pontosSpawn = spawnPoints;
        }

        // Instancia HUD de pontuação apenas se ainda não existir
        var scoreManagerExistente = FindObjectOfType<ScoreManager>();
        if (scoreHUDPrefab != null && scoreManagerExistente == null)
            Instantiate(scoreHUDPrefab);

        // Instancia painel administrativo apenas se ainda não houver Canvas
        var canvasExistente = FindObjectOfType<Canvas>();
        if (adminPanelPrefab != null && canvasExistente == null)
            Instantiate(adminPanelPrefab);
    }
}
