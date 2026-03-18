using UnityEngine;
using TMPro;

public class PlayerCollector : MonoBehaviour
{
    private int score = 0;

    public TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScoreText();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FallingObject"))
        {
            Destroy(collision.gameObject);
            score++;
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
