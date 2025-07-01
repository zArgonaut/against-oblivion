// Sistema responsável por gerenciar upgrades comprados pelo jogador.
// TODO: integrar com inventário de itens e armazenar progresso em arquivo.
using UnityEngine;
using System.Collections.Generic;

public class UpgradeSystem : MonoBehaviour
{
    [System.Serializable]
    public class Upgrade
    {
        public string id;
        public int level;
        public int maxLevel = 3;
        public int baseCost = 100;
    }

    public List<Upgrade> upgrades = new List<Upgrade>();
    private Dictionary<string, Upgrade> lookup = new Dictionary<string, Upgrade>();

    void Awake()
    {
        foreach (var upg in upgrades)
            lookup[upg.id] = upg;
        LoadProgress();
    }

    public bool TryPurchase(string id)
    {
        if (!lookup.TryGetValue(id, out var upg) || upg.level >= upg.maxLevel)
            return false;

        int cost = upg.baseCost * (upg.level + 1);
        if (ScoreManager.instance.pontos < cost)
            return false;

        ScoreManager.instance.pontos -= cost;
        upg.level++;
        ApplyUpgrade(upg);
        SaveProgress(upg);
        return true;
    }

    // Aqui cada upgrade deve modificar estatísticas ou liberar habilidades.
    void ApplyUpgrade(Upgrade upg)
    {
        // TODO: aplicar os efeitos reais de cada upgrade
        Debug.Log($"Upgrade {upg.id} aplicado. Nível {upg.level}");
    }

    void SaveProgress(Upgrade upg)
    {
        PlayerPrefs.SetInt($"upgrade_{upg.id}", upg.level);
        PlayerPrefs.Save();
    }

    void LoadProgress()
    {
        foreach (var upg in upgrades)
        {
            upg.level = PlayerPrefs.GetInt($"upgrade_{upg.id}", upg.level);
        }
    }
}
