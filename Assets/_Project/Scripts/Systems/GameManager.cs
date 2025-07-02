using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState { MenuInicial, Jogando, Pausado, Upgrade, GameOver, Vitoria, Loja, ModoHorda }
    public enum Difficulty { Facil, Normal, Dificil }

    public GameState State { get; private set; } = GameState.MenuInicial;
    public Difficulty CurrentDifficulty { get; private set; } = Difficulty.Normal;

    public float scoreMultiplier { get; private set; } = 1f;

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

    public void StartGame(Difficulty difficulty)
    {
        CurrentDifficulty = difficulty;
        scoreMultiplier = DifficultyMultiplier(difficulty);
        ChangeState(GameState.Jogando);
        SceneManager.LoadScene("FaseDeserto");
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
