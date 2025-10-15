using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TMP_Text scoreCounterText;
    public GameManager gameManager;
    public LevelManager levelManager;

    public float score;
    public float scoreMultiplier = 3f;


    void Update()
    {
        if (gameManager.gameActive == true) score += Time.deltaTime * scoreMultiplier * levelManager.levelSpeed;     //calculates new score
        scoreCounterText.text = score.ToString("0");
    }
}
