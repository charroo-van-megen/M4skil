using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector3 targetPosition;
    private float travelTime;
    private float timer;

    private void Start()
    {
        PickNewTarget();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // Beweeg richting het target
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check of target bereikt is
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            PickNewTarget();
        }
    }

    void PickNewTarget()
    {
        // Random punt binnen speelveld (stel X: -8 tot 8, Y: -4 tot 4)
        targetPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0f);
        float distance = Vector3.Distance(transform.position, targetPosition);
        travelTime = distance / moveSpeed;
        timer = 0f;
    }
}
