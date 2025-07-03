using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public TextMeshProUGUI weaponText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI staminaText;

    InventoryManager inventory;
    PlayerHealth health;
    PlayerStamina stamina;

    void OnEnable()
    {
        if (inventory == null)
            inventory = FindObjectOfType<InventoryManager>();
        if (health == null)
            health = FindObjectOfType<PlayerHealth>();
        if (stamina == null)
            stamina = FindObjectOfType<PlayerStamina>();

        if (inventory != null)
            inventory.OnInventoryChanged += UpdateWeaponUI;
        if (health != null)
            health.OnHealthChanged += UpdateHealthUI;
        if (stamina != null)
            stamina.OnStaminaChanged += UpdateStaminaUI;

        UpdateWeaponUI();
        if (health != null) UpdateHealthUI(health.currentHealth);
        if (stamina != null) UpdateStaminaUI(stamina.currentStamina);
    }

    void OnDisable()
    {
        if (inventory != null)
            inventory.OnInventoryChanged -= UpdateWeaponUI;
        if (health != null)
            health.OnHealthChanged -= UpdateHealthUI;
        if (stamina != null)
            stamina.OnStaminaChanged -= UpdateStaminaUI;
    }

    void UpdateWeaponUI()
    {
        if (inventory == null || inventory.ArmaEquipada == null)
            return;

        var arma = inventory.ArmaEquipada;
        if (weaponText != null)
            weaponText.text = arma.tipo.ToString();
        if (ammoText != null)
        {
            string ammo = arma.capacidade == 0 ? "\u221E" : arma.municao + "/" + arma.capacidade;
            ammoText.text = ammo;
        }
    }

    void UpdateHealthUI(int value)
    {
        if (healthText != null)
            healthText.text = "HP: " + value;
    }

    void UpdateStaminaUI(int value)
    {
        if (staminaText != null)
            staminaText.text = "ST: " + value;
    }
}
