using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CameraShaking : MonoBehaviour
{
    [SerializeField] private Animator gameOverScreenCanvas;
    [SerializeField] private Animator animator;

    public void ShakeCamera()
    {
        animator.SetTrigger("Shake");
        gameOverScreenCanvas.SetTrigger("ShowGameOverScreen");
    }
}
