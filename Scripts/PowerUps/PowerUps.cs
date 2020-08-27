using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    [SerializeField] PowerUp mirrorPowerUp;
    [SerializeField] PowerUp fagPowerUp;
    [SerializeField] PowerUp ballPowerUp;
    [SerializeField] PowerUp missilePowerUp;
    [SerializeField] int powerUpActiveTime = 5;
    [SerializeField] GameObject missile;
    [SerializeField] Text powerUpText;

    Ball ball;
    Fag fag;
    bool mirrorPowerUpActive = false;
    float mirrorPowerUpActiveTime = 0f;
    bool fagPowerUpActive = false;
    float fagPowerUpActiveTime = 0f;
    bool ballPowerUpActive = false;
    float ballPowerUpActiveTime = 0f;
    bool missilePowerUpActive = false;


    public void CreatePowerUp(Vector3 position, Quaternion rotation)
    {
        if (!IsPowerUpActive())
        {
            int randomValue = Convert.ToInt32(UnityEngine.Random.Range(0f, 10f));
            switch (randomValue)
            {
                case 0:
                    {
                        Instantiate(mirrorPowerUp, position, rotation);
                        break;
                    }
                case 3:
                    {
                        Instantiate(missilePowerUp, position, rotation);
                        break;
                    }
                case 5:
                    {
                        Instantiate(fagPowerUp, position, rotation);
                        break;
                    }
                case 9:
                    {
                        Instantiate(ballPowerUp, position, rotation);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }
    }  

    public void ActivatePowerUp(PowerUpTypes powerUpTypes)
    {
        if (IsPowerUpActive())
        {
            return;
        }

        switch (powerUpTypes)
        {
            case PowerUpTypes.BallPowerUp:
                {
                    ballPowerUpActive = true;
                    return;
                }
            case PowerUpTypes.FagPowerUp:
                {
                    fagPowerUpActive = true;
                    return;
                }
            case PowerUpTypes.MirrorPowerUp:
                {
                    mirrorPowerUpActive = true;
                    return;
                }
            case PowerUpTypes.MissilePowerUp:
                {
                    missilePowerUpActive = true;
                    ball.Hide();
                    Instantiate(missile, fag.transform.position + new Vector3(0f, 0.5f), fag.transform.rotation);
                    return;
                }
        }
    }

    public bool IsMirroActive()
    {
        return mirrorPowerUpActive;
    }

    public bool IsMegaFagActive()
    {
        return fagPowerUpActive;
    }  

    public bool IsMegaBallActive()
    {
        return ballPowerUpActive;
    }

    public bool IsMissileActive()
    {
        return missilePowerUpActive;
    }
  

    public void DeactivateMissile()
    {
        missilePowerUpActive = false;
        ball.ResetPosition();
        ball.Show();
    }
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        fag = FindObjectOfType<Fag>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMirrorPowerUp();
        UpdateMegaFagPowerUp();
        UpdateMegaBallPowerUp();
    }

    private bool IsPowerUpActive()
    {
        return mirrorPowerUpActive || fagPowerUpActive || ballPowerUpActive || missilePowerUpActive;
    }

    private void UpdateMirrorPowerUp()
    {
        if (mirrorPowerUpActive)
        {
            mirrorPowerUpActiveTime += Time.deltaTime;
            int activeInSeconds = Convert.ToInt32(mirrorPowerUpActiveTime);
            powerUpText.text = (powerUpActiveTime - activeInSeconds).ToString();

            if (activeInSeconds >= powerUpActiveTime)
            {
                mirrorPowerUpActive = false;
                mirrorPowerUpActiveTime = 0f;
            }
        }
    }

    private void UpdateMegaFagPowerUp()
    {
        if (fagPowerUpActive)
        {
            fagPowerUpActiveTime += Time.deltaTime;
            int activeInSeconds = Convert.ToInt32(fagPowerUpActiveTime);
            powerUpText.text = (powerUpActiveTime - activeInSeconds).ToString();

            if (activeInSeconds >= powerUpActiveTime)
            {
                fagPowerUpActive = false;
                fagPowerUpActiveTime = 0f;
            }
        }
    }

    private void UpdateMegaBallPowerUp()
    {
        if (ballPowerUpActive)
        {
            ballPowerUpActiveTime += Time.deltaTime;
            int activeInSeconds = Convert.ToInt32(ballPowerUpActiveTime);
            powerUpText.text = (powerUpActiveTime - activeInSeconds).ToString();

            if (activeInSeconds >= powerUpActiveTime)
            {
                ballPowerUpActive = false;
                ballPowerUpActiveTime = 0f;
            }
        }
    }
}
