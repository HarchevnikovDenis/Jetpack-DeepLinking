using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CoinTrigger : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.GetComponent<JetpackContoller>())
        {
            // User collect a COIN
            GameManager.Instance.ScoreManager.Coins++;
            animator.SetTrigger("Collect");
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
