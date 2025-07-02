using UnityEngine;

public enum WeaponType
{
    Porrete,
    Rifle,
    Shotgun,
    Granada,
    PaoBaguete
}

[System.Serializable]
public class WeaponSlot
{
    public WeaponType tipo;
    public int municao;
}

public class InventoryManager : MonoBehaviour
{
    public WeaponSlot[] armas = new WeaponSlot[4];
    public int bandagens = 0;
    public int powerUps = 0;

    public WeaponSlot ArmaEquipada => armas.Length > 0 ? armas[0] : null;

    public void AdicionarMunicao(WeaponType tipo, int quantidade)
    {
        foreach (var slot in armas)
        {
            if (slot.tipo == tipo)
            {
                slot.municao += quantidade;
                break;
            }
        }
    }

    public void UsarBandagem(PlayerHealth vida, int quantidade)
    {
        if (bandagens <= 0) return;
        vida.Curar(quantidade);
        bandagens--;
    }
}
