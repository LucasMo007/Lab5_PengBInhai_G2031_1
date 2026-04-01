using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Collected a normal falling object — add score
        if (collision.gameObject.CompareTag("FallingObject"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.AddScore(1);
        }

        // Hit a bomb — game over!
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.BombHit();
        }
    }
}
