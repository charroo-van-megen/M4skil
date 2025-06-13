using UnityEngine;

public class Tank : MonoBehaviour
{
    // 🚗 Beweging
    private Vector3 velocity;
    private float speed = 0f;
    private float acceleration = 0.1f;

    // 📐 Randen scherm
    private Vector2 min;
    private Vector2 max;

    // 🔫 Bullet prefab (zet in Inspector)
    [SerializeField] private GameObject bulletPrefab;

    void Start()
    {
        // Bereken schermranden in wereldcoördinaten
        min = Camera.main.ScreenToWorldPoint(Vector2.zero);
        max = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        // Rotatie fix: tank wijst naar boven? Zet hem -90 graden
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }

    void Update()
    {
        // ⬅➡ Sturen
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0f, 0f, -horizontal * 100f * Time.deltaTime);

        // ⬆⬇ Versnellen / vertragen
        float vertical = Input.GetAxis("Vertical");
        speed += vertical * acceleration;
        speed = Mathf.Clamp(speed, 0f, 5f); // Optioneel: begrens snelheid

        // 🚗 Beweging
        velocity = transform.right * speed;
        transform.position += velocity * Time.deltaTime;

        // 🔁 Wrapping
        Vector3 pos = transform.position;
        if (pos.x > max.x) pos.x = min.x;
        if (pos.x < min.x) pos.x = max.x;
        if (pos.y > max.y) pos.y = min.y;
        if (pos.y < min.y) pos.y = max.y;
        transform.position = pos;

        // 🔫 Bullet schieten
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogWarning("Bullet prefab niet ingesteld in de Inspector!");
        }
    }
}
