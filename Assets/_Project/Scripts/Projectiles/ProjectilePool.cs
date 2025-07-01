using UnityEngine;
using System.Collections.Generic;

public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool instance;

    public ProjectileController projectilePrefab;
    public int initialSize = 10;

    private Queue<ProjectileController> pool = new Queue<ProjectileController>();

    void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        for (int i = 0; i < initialSize; i++)
            AddProjectile();
    }

    ProjectileController AddProjectile()
    {
        ProjectileController proj = Instantiate(projectilePrefab);
        proj.pool = this;
        proj.gameObject.SetActive(false);
        pool.Enqueue(proj);
        return proj;
    }

    public ProjectileController Get()
    {
        if (pool.Count == 0)
            AddProjectile();

        ProjectileController proj = pool.Dequeue();
        proj.gameObject.SetActive(true);
        return proj;
    }

    public void ReturnProjectile(ProjectileController proj)
    {
        proj.gameObject.SetActive(false);
        pool.Enqueue(proj);
    }
}
