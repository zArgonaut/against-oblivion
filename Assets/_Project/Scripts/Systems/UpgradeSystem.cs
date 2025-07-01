// Sistema responsável por gerenciar upgrades comprados pelo jogador.
// TODO: integrar com inventário e salvar progresso entre sessões.
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

    public bool TryPurchase(string id)
    {
        var upg = upgrades.Find(u => u.id == id);
        if (upg == null || upg.level >= upg.maxLevel)
            return false;

        int cost = upg.baseCost * (upg.level + 1);
        if (ScoreManager.instance.pontos < cost)
            return false;

        ScoreManager.instance.pontos -= cost;
        upg.level++;
        ApplyUpgrade(upg);
        return true;
    }

    void ApplyUpgrade(Upgrade upg)
    {
        // TODO: aplicar os efeitos reais de cada upgrade
        Debug.Log($"Upgrade {upg.id} aplicado. N\u00edvel {upg.level}");
    }
}
