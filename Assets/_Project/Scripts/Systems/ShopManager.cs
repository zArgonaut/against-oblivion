using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public TextMeshProUGUI txtScore;
    public Button upgradeWeaponBtn;
    public Button capacityBtn;
    public Button ammoBtn;

    public int weaponUpgradeCost = 200;
    public int capacityCost = 100;
    public int ammoCost = 50;

    public int capacityIncrease = 10;
    public int ammoIncrease = 20;

    InventoryManager inventory;
    UpgradeSystem upgradeSystem;

    void Start()
    {
        inventory = FindObjectOfType<InventoryManager>();
        upgradeSystem = FindObjectOfType<UpgradeSystem>();

        if (upgradeWeaponBtn) upgradeWeaponBtn.onClick.AddListener(BuyUpgrade);
        if (capacityBtn) capacityBtn.onClick.AddListener(BuyCapacity);
        if (ammoBtn) ammoBtn.onClick.AddListener(BuyAmmo);

        UpdateScore();
        UnlockSecretWeapon();
    }

    void UpdateScore()
    {
        if (txtScore && ScoreManager.instance != null)
            txtScore.text = "Pontos: " + ScoreManager.instance.pontos;
    }

    void BuyUpgrade()
    {
        if (ScoreManager.instance && ScoreManager.instance.SpendPoints(weaponUpgradeCost))
        {
            if (upgradeSystem) upgradeSystem.AplicarUpgrade();
            UpdateScore();
        }
    }

    void BuyCapacity()
    {
        if (ScoreManager.instance && ScoreManager.instance.SpendPoints(capacityCost))
        {
            if (inventory != null && inventory.ArmaEquipada != null)
                inventory.AumentarCapacidade(inventory.ArmaEquipada.tipo, capacityIncrease);
            UpdateScore();
        }
    }

    void BuyAmmo()
    {
        if (ScoreManager.instance && ScoreManager.instance.SpendPoints(ammoCost))
        {
            if (inventory != null && inventory.ArmaEquipada != null)
                inventory.AdicionarMunicao(inventory.ArmaEquipada.tipo, ammoIncrease);
            UpdateScore();
        }
    }

    void UnlockSecretWeapon()
    {
        if (ScoreManager.instance == null || inventory == null) return;
        if (SceneManager.GetActiveScene().buildIndex >= 4 && ScoreManager.instance.pontosGastos == 0)
        {
            foreach (var slot in inventory.armas)
            {
                if (slot != null && slot.tipo == WeaponType.Porrete)
                {
                    slot.tipo = WeaponType.PaoBaguete;
                    slot.municao = slot.capacidade;
                    break;
                }
            }
        }
    }
}
