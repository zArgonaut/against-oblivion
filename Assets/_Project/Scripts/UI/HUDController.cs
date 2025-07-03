using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public TextMeshProUGUI weaponText;
    InventoryManager inventory;

    void Start()
    {
        if (inventory == null)
            inventory = FindObjectOfType<InventoryManager>();
    }

    void Update()
    {
        if (weaponText == null || inventory == null || inventory.ArmaEquipada == null)
            return;

        var arma = inventory.ArmaEquipada;
        string ammo = arma.capacidade == 0 ? "\u221E" : arma.municao + "/" + arma.capacidade;
        weaponText.text = arma.tipo + ": " + ammo;
    }
}
