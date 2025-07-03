using UnityEngine;

public class FXManager : MonoBehaviour
{
    public static FXManager Instance { get; private set; }

    [Header("Particle Prefabs")]
    public GameObject bloodFX;
    public GameObject dustFX;
    public GameObject explosionFX;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayBlood(Vector3 position)
    {
        if (bloodFX != null)
            Instantiate(bloodFX, position, Quaternion.identity);
    }

    public void PlayDust(Vector3 position)
    {
        if (dustFX != null)
            Instantiate(dustFX, position, Quaternion.identity);
    }

    public void PlayExplosion(Vector3 position)
    {
        if (explosionFX != null)
            Instantiate(explosionFX, position, Quaternion.identity);
    }
}
