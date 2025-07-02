using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    public int maxStamina = 100;
    public int currentStamina;
    public float regenRate = 15f;

    void Awake()
    {
        currentStamina = maxStamina;
    }

    void Update()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += Mathf.CeilToInt(regenRate * Time.deltaTime);
            if (currentStamina > maxStamina)
                currentStamina = maxStamina;
        }
    }

    public bool Use(int amount)
    {
        if (currentStamina < amount)
            return false;
        currentStamina -= amount;
        return true;
    }

    public void Restore(int amount)
    {
        currentStamina = Mathf.Clamp(currentStamina + amount, 0, maxStamina);
    }
}
