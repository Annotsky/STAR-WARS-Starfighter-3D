using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    public int score;
    
    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
}
