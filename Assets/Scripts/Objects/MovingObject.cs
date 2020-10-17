using UnityEngine;

public class MovingObject : MonoBehaviour
{
    private new Transform transform;
    private Vector3 movementDirection = Vector2.left;
    private float movementSpeed => GameManager.Instance.SpeedOfMovingObjects;

    private void Awake()
    {
        transform = gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        if(GameManager.Instance.isGameActive) MoveObject();
    }

    private void MoveObject()
    {
        transform.position += movementDirection * movementSpeed * Time.deltaTime;

        if(transform.position.x <= -15.0f)
        {
            Destroy(gameObject);
        }
    }
}
