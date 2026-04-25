using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public float power = 5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed;
    }
}
