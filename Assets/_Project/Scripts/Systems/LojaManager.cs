using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LojaManager : MonoBehaviour
{
    public TextMeshProUGUI txtPontos;
    public Button[] btnUpgrades;
    public int custoBase = 100;

    void Start()
    {
        AtualizarPontos();
        for (int i = 0; i < btnUpgrades.Length; i++)
        {
            int index = i;
            btnUpgrades[i].onClick.AddListener(() => ComprarUpgrade(index));
        }
    }

    void AtualizarPontos()
    {
        txtPontos.text = "Pontos: " + ScoreManager.instance.pontos;
    }

    void ComprarUpgrade(int slot)
    {
        int custo = custoBase * (slot + 1);
        if (ScoreManager.instance.pontos >= custo)
        {
            ScoreManager.instance.pontos -= custo;
            // aplicar efeito de upgrade conforme slot
            AtualizarPontos();
        }
    }
}
