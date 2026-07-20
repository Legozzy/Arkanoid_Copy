using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int score;
    private static int topScore;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Ball.Instance.onBrickDestroy += Ball_onBrickDestroy;
    }

    private void Ball_onBrickDestroy(object sender, System.EventArgs e)
    {
        AddScore(1);
    }

    public void AddScore(int addScoreAmount)
    {
        score += addScoreAmount;
        Debug.Log("Score: " + score);
    }

    public int GetScore()
    {
        return score;
    }

}
