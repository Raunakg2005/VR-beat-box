using UnityEngine;
using TMPro; // Needed for the text

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int currentScore = 0;

    // We will call this from our punch script!
    public void AddScore(int amount)
    {
        currentScore += amount;
        scoreText.text = "SCORE: " + currentScore;
    }

    public void PauseGame()
    {
        // Setting time to 0 literally freezes the entire game world
        Time.timeScale = 0; 
    }

    public void PlayGame()
    {
        // Setting time to 1 resumes normal speed
        Time.timeScale = 1; 
    }
}