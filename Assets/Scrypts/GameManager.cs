using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] public int score = 0;
    [SerializeField] public int levelObjective = 5;
    [SerializeField] public int currentLevel = 1;
    [SerializeField] private int lives = 3;

    private bool gameOver = false;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;
    //UI elements
    [SerializeField] private TextMeshProUGUI objectiveText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI liveText;
    [SerializeField] private TextMeshProUGUI scorePointsText;

    [SerializeField] private const int levelObjectiveBase = 5;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetUpStartLevel();

        
    }

    // Update is called once per frame
    void Update()
    {
        //ChangeLevel(currentLevel);
        SetUpStartLevel();
        ChangeLevel(currentLevel);
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

    public void ChangeLevel(int newCurrentLevel)
    {
        if (levelObjective == 0) 
        {
            //currentLevel += 1;
            newCurrentLevel += 1;
            //currentLevel = newCurrentLevel;
            levelText.text = newCurrentLevel.ToString();

            var newlevelObjective = levelObjectiveBase * newCurrentLevel;
            objectiveText.text = newlevelObjective.ToString();
        }

        currentLevel = newCurrentLevel;
    }

    private void SetUpNextLevel(int currentLevel)
    {
        levelObjective = levelObjective * currentLevel;
        currentLevel++;
    }

    private void SetUpStartLevel()
    {
        objectiveText.text = levelObjective.ToString();
        levelText.text = currentLevel.ToString();
        liveText.text = lives.ToString();
        scorePointsText.text = score.ToString();
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

    public void IncreaseLive()
    {
        if ((lives > 0))
        {
            lives++;
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

    public void RestartGame()
    {
        HandyTools.LoadCurrentScene();
    }
}
