using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int score = 0;
    [SerializeField] private int levelObjective = 0;
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int lives = 3;

    private bool gameOver = false;

    [SerializeField] private GameObject gameOverPanel;
    //UI elements
    [SerializeField] private TextMeshProUGUI objectiveText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI liveText;
    [SerializeField] private TextMeshProUGUI scorePointsText;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InremetScore()
    {
        if (!gameOver)
        {
            score++;
            scorePointsText.text = score.ToString();
        }
    }

    public void UpdateLevelObjective()
    {
        if(levelObjective > 0)
        {
            levelObjective--;
        }
    }

    public void ChangeLevel(int currentLevel)
    {
        if (levelObjective == 0) 
        {
            currentLevel += 1;
            levelText.text = currentLevel.ToString();
        }
    }

    private void SetUpLevel(int currentLevel)
    {

    }

    public void DecreaseLive(int value)
    {
        if ((lives > 0))
        {
            lives = lives - value;
            if (lives < 0)
            {
                lives = 0;
                liveText.text = lives.ToString();
            }
            else
            {
                liveText.text = lives.ToString();
            }
        }
        else 
        {
            gameOver = true;

            GameOver(gameOver);
        
        }
    }

    public void DecreaseLive()
    {
        if ((lives > 0))
        {
            lives--;
            if (lives < 0)
            {
                lives = 0;
                liveText.text = lives.ToString();
            }
            else
            {
                liveText.text = lives.ToString();
            }
        }
        else
        {
            gameOver = true;

            GameOver(gameOver);

        }
    }

    public void GameOver(bool gameOver)
    {
        if (gameOver)
        {
            LevelManager.Instance.StopSpawning();
            GameObject.Find("Player").GetComponent<PlayerControler>().canMove = false;
            gameOverPanel.SetActive(true);
            Debug.Log("Game Over!");
        }

    }
}
