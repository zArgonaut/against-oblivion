using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState { MenuInicial, Jogando, Pausado, Upgrade, GameOver, Vitoria, Loja, ModoHorda }
    public enum Difficulty { Facil, Normal, Dificil }

    public GameState State { get; private set; } = GameState.MenuInicial;
    public Difficulty CurrentDifficulty { get; private set; } = Difficulty.Normal;

    public float scoreMultiplier { get; private set; } = 1f;

    int pendingScore = -1;
    const int startSceneIndex = 1; // FaseDeserto

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void StartGame(Difficulty difficulty, int slot)
    {
        CurrentDifficulty = difficulty;
        scoreMultiplier = DifficultyMultiplier(difficulty);

        var data = LoadGame(slot);
        if (data != null)
        {
            pendingScore = data.pontos;
        }
        else
        {
            pendingScore = 0;
        }

        ChangeState(GameState.Jogando);
        int scene = data != null ? data.faseAtual : startSceneIndex;
        SceneManager.LoadScene(scene);
    }

    public void ChangeState(GameState newState)
    {
        State = newState;
    }

    public void LoadShop()
    {
        ChangeState(GameState.Loja);
        SceneManager.LoadScene("LojaEntreFases");
    }

    public void SaveGame(int slot)
    {
        var data = new SaveData
        {
            faseAtual = SceneManager.GetActiveScene().buildIndex,
            pontos = ScoreManager.instance ? ScoreManager.instance.pontos : 0,
            dificuldade = CurrentDifficulty
        };
        SaveSystem.Save(slot, data);
    }

    public SaveData LoadGame(int slot)
    {
        var data = SaveSystem.Load(slot);
        if (data != null)
        {
            CurrentDifficulty = data.dificuldade;
            scoreMultiplier = DifficultyMultiplier(CurrentDifficulty);
        }
        return data;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (pendingScore >= 0 && ScoreManager.instance != null)
        {
            ScoreManager.instance.SetPontos(pendingScore);
            pendingScore = -1;
        }
    }

    float DifficultyMultiplier(Difficulty diff)
    {
        switch (diff)
        {
            case Difficulty.Facil: return 1f;
            case Difficulty.Normal: return 1.25f;
            case Difficulty.Dificil: return 1.5f;
        }
        return 1f;
    }
}
