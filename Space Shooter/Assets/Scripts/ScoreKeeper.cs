using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score;

    public int GetScore()
    {
        return score;
    }

    public void AddScore(int score)
    {
        this.score += score;
        Mathf.Clamp(this.score, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
