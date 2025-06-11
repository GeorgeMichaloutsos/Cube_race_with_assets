using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject gameOverPanel;

    private float survivalTime = 0f;
    private bool isOver = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOver)
        {
            survivalTime += Time.deltaTime;
            scoreText.text = "Score: " + Mathf.FloorToInt(survivalTime);
        }

        if (isOver && Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void GameOver()
    {
        isOver = true;
        gameOverPanel.SetActive(true);
        scoreText.text = "Your final Score is " + Mathf.FloorToInt(survivalTime) + "\n Press R to play again";
    }
}


