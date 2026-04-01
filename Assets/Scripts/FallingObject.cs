using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isBomb = false;

    public void SetAsBomb(bool bomb)
    {
        isBomb = bomb;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Object fell off screen
        if (transform.position.y < -10f)
        {
            // If it was a normal collectible and it was missed, player loses a life
            if (!isBomb)
            {
                GameManager.Instance.LoseLife();
            }

            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy when hitting the ground (if ground exists below)
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!isBomb)
            {
                GameManager.Instance.LoseLife();
            }
            Destroy(gameObject);
        }
    }
}
