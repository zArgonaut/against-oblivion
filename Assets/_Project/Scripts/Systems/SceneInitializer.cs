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
        // Instancia o jogador - usa a factory se o prefab estiver faltando
        GameObject playerObj = playerPrefab != null ? playerPrefab : PrefabFactory.CreatePlayer();
        if (playerObj != null && playerSpawn != null && FindObjectOfType<PlayerMovement>() == null)
            Instantiate(playerObj, playerSpawn.position, Quaternion.identity);

        // Instancia o HordaManager e configura pontos de spawn
        if (FindObjectOfType<HordaManager>() == null)
        {
            GameObject prefab = hordaManagerPrefab != null ? hordaManagerPrefab : new GameObject("HordaManager", typeof(HordaManager));
            var hordaGO = Instantiate(prefab);
            var horda = hordaGO.GetComponent<HordaManager>();
            if (horda != null)
                horda.pontosSpawn = spawnPoints;
        }

        // Instancia HUD de pontuação
        if (FindObjectOfType<ScoreManager>() == null)
        {
            GameObject hud = scoreHUDPrefab != null ? scoreHUDPrefab : PrefabFactory.CreateScoreHUD();
            if (hud != null) Instantiate(hud);
        }

        // Instancia painel administrativo
        if (FindObjectOfType<AdminDebugPanel>() == null)
        {
            GameObject admin = adminPanelPrefab != null ? adminPanelPrefab : PrefabFactory.CreateAdminPanel();
            if (admin != null) Instantiate(admin);
        }
    }
}
