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

        // Instancia o HordaManager apenas se ainda n\u00e3o houver um ativo na cena
        var managerExistente = FindObjectOfType<HordaManager>();
        if (hordaManagerPrefab != null && managerExistente == null)
        {
            var hordaGO = Instantiate(hordaManagerPrefab);
            var horda = hordaGO.GetComponent<HordaManager>();
            if (horda != null)
                horda.pontosSpawn = spawnPoints;
        }

        // Instancia HUD de pontuação apenas se ainda não existir
        if (scoreHUDPrefab != null && FindObjectOfType<ScoreManager>() == null)
            Instantiate(scoreHUDPrefab);

        // Instancia painel administrativo
        if (adminPanelPrefab != null)
            Instantiate(adminPanelPrefab);
    }
}
