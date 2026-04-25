using UnityEngine;

public class PlayerController_2P : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefub;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float coolDown;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    private float timer = 0;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer < coolDown) return;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            Shoot(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            Shoot(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            Shoot(Vector2.zero);
        }
    }

    private void FixedUpdate()
    {
        LimitPosition();
    }

    private void Shoot(Vector2 knockbackDir)
    {
        Instantiate(bulletPrefub, firePoint.position, transform.rotation);
        timer = 0;

        if (knockbackDir != Vector2.zero)
        {
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(knockbackDir * 5f, ForceMode2D.Impulse);
        }
    }

    private void LimitPosition()
    {
        Vector3 pos = transform.position;

        if (pos.y > maxY)
        {
            pos.y = maxY;
            rb.linearVelocity = Vector2.zero;
        }
        else if (pos.y < minY)
        {
            pos.y = minY;
            rb.linearVelocity = Vector2.zero;
        }

        transform.position = pos;
    }
}