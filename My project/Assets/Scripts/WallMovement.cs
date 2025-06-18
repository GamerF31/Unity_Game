using UnityEngine;
using System.Collections;

public class WallMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float hideHeight = 50f;
    public float moveInterval = 5f;
    public float waitTimeAtBottom = 3f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(MoveWall());
    }

    IEnumerator MoveWall()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveInterval);

            float timeElapsed = 0f;
            Vector3 targetPosition = new Vector3(initialPosition.x, hideHeight, initialPosition.z);

            while (transform.position.y > hideHeight)
            {
                transform.position = Vector3.Lerp(initialPosition, targetPosition, timeElapsed / moveSpeed);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(waitTimeAtBottom);

            timeElapsed = 0f;

            while (transform.position.y < initialPosition.y)
            {
                transform.position = Vector3.Lerp(targetPosition, initialPosition, timeElapsed / moveSpeed);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
}
