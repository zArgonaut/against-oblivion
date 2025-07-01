using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    public static GameFlowManager Instance { get; private set; }

    [Tooltip("Order of playable scenes")] public string[] scenes = { "FaseDeserto", "FaseMontanha", "FaseGelo" };

    private int currentIndex = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void CreateManager()
    {
        if (Instance == null)
        {
            var go = new GameObject("GameFlowManager");
            Instance = go.AddComponent<GameFlowManager>();
        }
    }

    public void StartGame()
    {
        currentIndex = 0;
        LoadCurrent();
    }

    public void AdvanceLevel()
    {
        currentIndex++;
        if (currentIndex < scenes.Length)
            LoadCurrent();
        else
            SceneManager.LoadScene("MainMenu");
    }

    private void LoadCurrent()
    {
        if (currentIndex >= 0 && currentIndex < scenes.Length)
            SceneManager.LoadScene(scenes[currentIndex]);
    }
}
