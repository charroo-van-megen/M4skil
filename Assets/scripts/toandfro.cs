using UnityEngine;
using TMPro;

public class toandfro : MonoBehaviour
{
    [SerializeField] Transform a;
    [SerializeField] Transform b;
    [SerializeField] Transform player;
    [SerializeField] TextMeshProUGUI stopwatch;

    float duration;
    float time = 0f;
    bool fromAToB = true;

    Vector3 differenceVector;
    Vector3 direction;
    float distance;

    void Start()
    {
        distance = Vector3.Distance(a.position, b.position);
        float speed = 1f;
        duration = distance / speed;

        player.position = a.position;
    }

    void Update()
    {
        time += Time.deltaTime;

        // Interpolation progress
        float t = time / duration;

        // Set movement direction and difference vector for debug purposes
        if (fromAToB)
        {
            differenceVector = b.position - a.position;
            player.position = Vector3.Lerp(a.position, b.position, t);
        }
        else
        {
            differenceVector = a.position - b.position;
            player.position = Vector3.Lerp(b.position, a.position, t);
        }

        distance = differenceVector.magnitude;
        direction = differenceVector.normalized;

        // Debug output (optional)
        // Debug.Log($"Direction: {direction}, Distance: {distance}");

        // Update UI
        stopwatch.text = time.ToString("F3");

        // Switch direction when done
        if (time >= duration)
        {
            fromAToB = !fromAToB;
            time = 0f;
        }
    }
}
