using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<JetpackContoller>())
        {
            GameManager.Instance.GameOver();
        }
    }
}
