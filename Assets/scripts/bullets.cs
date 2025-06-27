using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 0.1f);
        if(hit.collider != null)
        {
            Destroy(hit.collider.gameObject); // EnemyTank verwijderen
            Destroy(gameObject);              // Bullet verwijderen
        }
    }
}
