using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui : MonoBehaviour
{
    public GameObject coinText;
    public GameObject timeText;
    public GameObject scoreText;

    private int coins = 0;
    private int score = 0;
    private int startingTime = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateTime();
    }

    private void updateTime()
    {
        float timeLeft = (startingTime - Mathf.Floor(Time.timeSinceLevelLoad));
        if (timeLeft <= 0)
        {
            Debug.Log("---GAME OVER---");
            return;
        }
        timeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Time: " + timeLeft;
    }

    public void addToScore(int points)
    {
        score += points;
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Points: " + score;
    }

    public void gotCoin()
    {
        coins++;
        addToScore(100);
        coinText.GetComponent<TMPro.TextMeshProUGUI>().text = "Coins: " + coins;
    }
}
