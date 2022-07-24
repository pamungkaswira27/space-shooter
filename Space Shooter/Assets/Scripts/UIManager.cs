using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Game Over Popup")]
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] TextMeshProUGUI finalScoreText;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString("0000000");
    }

    public void OpenGameOverPopup()
    {
        finalScoreText.text = scoreKeeper.GetScore().ToString("0000000");
        gameOverCanvas.SetActive(true);
    }
}
