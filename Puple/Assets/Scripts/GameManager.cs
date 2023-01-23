using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject hazardPrefab;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI gameOverScoreText;
    public TMPro.TextMeshProUGUI highScoreText;
    public Image bgMenu;
    public GameObject gameOverMenu;
    public GameObject player;

    private static GameManager instance;
    public static GameManager Instance => instance;

    private static int highScore;
    private int score;
    private float timer;
    private bool gameOver;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void OnEnable()
    {
        scoreText.text = "0";
        score = 0;
        gameOver = false;
        player.SetActive(true);
        StartCoroutine(SpawnHazards());
    }

    void Start()
    {
        instance = this;
        StartCoroutine(SpawnHazards());
    }

    private void Update()
    
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                WaitFor05Seconds();
                Time.timeScale = 0;
                bgMenu.gameObject.SetActive(true);
            }
            else
            {
                WaitFor05Seconds();
                Time.timeScale = 1;
                bgMenu.gameObject.SetActive(false);

            }
        }
        
        if (gameOver)
        {
            return;
        }
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            score++;
            scoreText.text = score.ToString();
            timer = 0;
        }
        
        
    }

    private IEnumerator SpawnHazards()
    {
        var hazardToSpawn = Random.Range(1, 4);

        for (int i = 0; i < hazardToSpawn; i++)
        {
            var x = Random.Range(-7, 7);
            var drag = Random.Range(0f, 3f);
            var hazard = Instantiate(hazardPrefab, new Vector3(x, 15, 0), Quaternion.Euler(90,90,90));
            hazard.GetComponent<Rigidbody>().drag = drag;
        }
        yield return new WaitForSeconds(1f); 
        yield return SpawnHazards();
    }

    public void GameOver()
    {
        if (score > highScore)
        {
            highScore = score;
        }
        highScoreText.text = highScore.ToString();
        gameOverScoreText.text = score.ToString();
        gameOver = true;
        gameObject.SetActive(false);
        gameOverMenu.SetActive(true);
    }

    IEnumerator WaitFor05Seconds()
    {
        yield return new WaitForSeconds(0.5f);
    }
    
    
    public void Enable()
    {
        gameObject.SetActive(true);
    }
}
