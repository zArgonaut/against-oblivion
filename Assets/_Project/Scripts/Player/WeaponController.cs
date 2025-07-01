using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Settings")]
    public ProjectileController projectilePrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;
    public int damage = 25;
    public int energyCost = 10;

    private float fireTimer = 0f;
    private PlayerEnergy energy;

    void Start()
    {
        energy = GetComponent<PlayerEnergy>();
    }

    void Update()
    {
        fireTimer -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && fireTimer <= 0f)
        {
            if (energy == null || energy.Consume(energyCost))
            {
                Shoot();
                fireTimer = fireRate;
            }
        }
    }

    void Shoot()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            ProjectileController proj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            proj.dano = damage;
        }
    }
}
