using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // ==========================================
    // SINGLETON PATTERN
    // ==========================================
    // Only one GameManager can exist at a time.
    // Any script can access it via GameManager.Instance
    public static GameManager Instance { get; private set; }

    [Header("Game Settings")]
    [SerializeField] private int maxLives = 3;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private GameObject gameOverPanel;

    private int score = 0;
    private int lives;
    private bool isGameOver = false;

    public bool IsGameOver => isGameOver;

    void Awake()
    {
        // Singleton enforcement: if an instance already exists, destroy this one
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        lives = maxLives;
        UpdateScoreUI();
        UpdateLivesUI();

        // Make sure Game Over panel is hidden at start
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    // Called when player collects a falling object
    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;
        UpdateScoreUI();
    }

    // Called when player misses a falling object or hits a bomb
    public void LoseLife()
    {
        if (isGameOver) return;

        lives--;
        UpdateLivesUI();

        if (lives <= 0)
        {
            TriggerGameOver();
        }
    }

    // Called when player hits a bomb — instant game over
    public void BombHit()
    {
        if (isGameOver) return;

        TriggerGameOver();
    }

    private void TriggerGameOver()
    {
        isGameOver = true;

        // Show Game Over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // Stop all movement by pausing the game
        Time.timeScale = 0f;

        Debug.Log("GAME OVER! Final Score: " + score);
    }

    // Call this from a Restart button
    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }
}
