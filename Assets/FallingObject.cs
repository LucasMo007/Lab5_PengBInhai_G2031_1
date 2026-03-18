using UnityEngine;

public class FallingObject : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 碰到任何东西都销毁自己
        Destroy(gameObject);
    }
}
