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
        if (playerPrefab != null && playerSpawn != null && FindObjectOfType<PlayerMovement>() == null)
            Instantiate(playerPrefab, playerSpawn.position, Quaternion.identity);

        // Instancia o HordaManager e configura pontos de spawn
        if (hordaManagerPrefab != null && FindObjectOfType<HordaManager>() == null)
        {
            var hordaGO = Instantiate(hordaManagerPrefab);
            var horda = hordaGO.GetComponent<HordaManager>();
            if (horda != null)
                horda.pontosSpawn = spawnPoints;
        }

        // Instancia HUD de pontuação
        if (scoreHUDPrefab != null && FindObjectOfType<ScoreManager>() == null)
            Instantiate(scoreHUDPrefab);

        // Instancia painel administrativo
        if (adminPanelPrefab != null && FindObjectOfType<Canvas>() == null)
            Instantiate(adminPanelPrefab);
    }
}
