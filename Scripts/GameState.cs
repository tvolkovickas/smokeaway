using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] float damegePoints = 1f;
    [SerializeField] float ballSpeedIncrease = 0.25f;
    [SerializeField] int lifes = 5;
  
    Ball ball;
    Lives lives;
    GameLevel gameLevel;
    float numberOfSquaresDestroyed = 0f;
    float score = 0f;
    int totalSquares = 0;

    public void CountSquares()
    {
        totalSquares++;
    }

    public int GetLives()
    {
        return lifes;
    }

    public void LooseLife()
    {
        lifes--;
        ball.ResetPosition();
        ball.ResetSpeed();
        if(lifes <= 0)
        {
            gameLevel.GameOver();
        } else
        {
            lives.UpdateLives();
        }
    }
  

    private void Start()
    {
        gameLevel = FindObjectOfType<GameLevel>();
        lives = FindObjectOfType<Lives>();
        ball = FindObjectOfType<Ball>();
        scoreText.text = score.ToString();
    }

    private void Update()
    {
       
    }

    public void DestroySquare()
    {
        score += damegePoints;
        scoreText.text=score.ToString();

        numberOfSquaresDestroyed++;

        if(numberOfSquaresDestroyed % 4 == 0)
        {
            ball.IncreaseSpeed(ballSpeedIncrease);
        }

        if(numberOfSquaresDestroyed >= totalSquares)
        {
            gameLevel.Win();
        }
    }
}
