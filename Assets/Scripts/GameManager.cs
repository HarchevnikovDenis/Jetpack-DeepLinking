using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private new CameraShaking camera;
    [SerializeField] private float speedOfMovingObjects;

    public bool isMobileDevice { get; private set; }

    public static GameManager Instance { get; private set;}

    public bool isGameActive { get; set; } = true;

    public ScoreManager ScoreManager => scoreManager;
    public float SpeedOfMovingObjects => speedOfMovingObjects;

    #region Singleton
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            if(Instance != this)
            {
                Destroy(gameObject);
            }
        }

        if (Application.platform == RuntimePlatform.WindowsEditor ||
            Application.platform == RuntimePlatform.WindowsPlayer) isMobileDevice = false;
    }
    #endregion

    public void GameOver()
    {
        isGameActive = false;
        camera.ShakeCamera();
        scoreManager.GameOver();
    }
}
