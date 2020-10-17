using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text coinsText;
    [SerializeField] private Text currentScoreText;
    [SerializeField] private Text bestScoreText;
    [SerializeField] private GameObject newBestScoreTitle;
    [SerializeField] private string levelDifficultyTheBestScoreKey;

    private int score;
    private float floatScore;
    private string bestScoreSetText = "NEW BEST SCORE";

    private GameManager gameManager => GameManager.Instance;
   

    public int Coins
    {
        get
        {
            return PlayerPrefs.GetInt("COINS", 0);
        }
        set
        {
            PlayerPrefs.SetInt("COINS", value);
            coinsText.text = string.Format("{0: 000}", value);
        }
    }

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            currentScoreText.text = string.Format("{0: 0000}m", value);
        }
    }

    public int BestScore
    {
        get
        {
            return PlayerPrefs.GetInt(levelDifficultyTheBestScoreKey, 0);
        }
        set
        {
            PlayerPrefs.SetInt(levelDifficultyTheBestScoreKey, value);
        }
    }

    private void Awake()
    {
        coinsText.text = string.Format("{0: 000}", Coins);

        if (BestScore > 0)
        {
            bestScoreText.text = string.Format("BEST: {0: 0000}m", BestScore);
        }
        else
        {
            bestScoreText.text = string.Empty;
        }
    }

    private void Update()
    {
        if (gameManager.isGameActive)
        {
            floatScore += Time.deltaTime * gameManager.SpeedOfMovingObjects;
            Score = (int)floatScore;
        }

        if(Score > BestScore && !string.Equals(bestScoreText.text, bestScoreSetText))
        {
            bestScoreText.text = bestScoreSetText;
        }
    }

    public void GameOver()
    {
        if(Score > BestScore)
        {
            // Игрок поствил новый рекорд
            BestScore = Score;
            newBestScoreTitle.SetActive(true);
        }
    }
}
