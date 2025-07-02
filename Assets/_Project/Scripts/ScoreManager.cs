using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public enum EnemyType
{
    Melee,
    Ranged,
    Flyer
}

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [System.Serializable]
    public struct EnemyScore
    {
        public EnemyType tipo;
        public int valorBase;
    }

    public EnemyScore[] valores;
    private Dictionary<EnemyType, int> lookup = new Dictionary<EnemyType, int>();

    [HideInInspector] public int pontos = 0;
    public TextMeshProUGUI textoPontos;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            foreach (var e in valores)
                lookup[e.tipo] = e.valorBase;
        }
        else Destroy(gameObject);
    }

    public void AdicionarPontos(EnemyType tipo)
    {
        int valor = lookup.ContainsKey(tipo) ? lookup[tipo] : 1;
        float mult = GameManager.Instance ? GameManager.Instance.scoreMultiplier : 1f;
        pontos += Mathf.RoundToInt(valor * mult);
        AtualizarUI();
    }

    public void AdicionarPontos(int valor)
    {
        float mult = GameManager.Instance ? GameManager.Instance.scoreMultiplier : 1f;
        pontos += Mathf.RoundToInt(valor * mult);
        AtualizarUI();
    }

    public void SetPontos(int valor)
    {
        pontos = valor;
        AtualizarUI();
    }

    void AtualizarUI()
    {
        if (textoPontos) textoPontos.text = "PONTOS: " + pontos;
    }
}
