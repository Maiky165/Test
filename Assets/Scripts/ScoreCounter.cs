using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TMP_Text scoreCounterText;
    public GameManager gameManager;

    public float score;
    public float scoreMultiplier = 10f;


    void Update()
    {
        if (gameManager.gameActive == true) score += Time.deltaTime * scoreMultiplier;     //calculates new score
        scoreCounterText.text = score.ToString("0");
    }
}
