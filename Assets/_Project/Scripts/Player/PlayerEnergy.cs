using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    [Header("Energy Settings")]
    public int maxEnergy = 100;
    public int currentEnergy;
    public float regenRate = 10f;

    void Awake()
    {
        currentEnergy = maxEnergy;
    }

    void Update()
    {
        if (currentEnergy < maxEnergy)
        {
            currentEnergy += Mathf.CeilToInt(regenRate * Time.deltaTime);
            if (currentEnergy > maxEnergy)
                currentEnergy = maxEnergy;
        }
    }

    public bool Consume(int amount)
    {
        if (currentEnergy < amount)
            return false;

        currentEnergy -= amount;
        return true;
    }

    public void Restore(int amount)
    {
        currentEnergy = Mathf.Clamp(currentEnergy + amount, 0, maxEnergy);
    }
}
