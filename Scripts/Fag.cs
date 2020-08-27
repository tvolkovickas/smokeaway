using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fag : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 6f;
    Ball ball;
    PowerUps powerUps;
    private bool moveLeft = false;
    private bool moveRight = false;
    float currentMinX;
    float currentMaxX;

    public void Shoot()
    {
        if (powerUps.IsMissileActive())
        {
            FindObjectOfType<Missile>().Shoot();
        } else
        {
            ball.LaunchBall();
        }
    }

    public void StartMoveLeft()
    {
        moveLeft = true;
    }

    public void StopMoveLeft()
    {
        moveLeft = false;
    }

    public void StartMoveRight()
    {
        moveRight = true;
    }

    public void StopMoveRightt()
    {
        moveRight = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        powerUps = FindObjectOfType<PowerUps>();
        ball = FindObjectOfType<Ball>();
        currentMinX = minX;
        currentMaxX = maxX;
    }

    // Update is called once per frame
    void Update()
    {
        float direction = powerUps.IsMirroActive() ? -1f : 1f;
        if (Input.GetKey(KeyCode.LeftArrow) || moveLeft)
        {
            var fagPos = new Vector2(Mathf.Clamp(transform.position.x - (speed* direction * Time.deltaTime), currentMinX, currentMaxX), transform.position.y);
            transform.position = fagPos;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || moveRight)
        {
            var fagPos = new Vector2(Mathf.Clamp(transform.position.x + (speed * direction * Time.deltaTime), currentMinX, currentMaxX), transform.position.y);
            transform.position = fagPos;
        }

        if (powerUps.IsMegaFagActive())
        {
            transform.localScale = new Vector3(2f, 1f, 1f);
            currentMinX = minX + 0.5f;
            currentMaxX = maxX - 0.5f;
        } else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            currentMinX = minX;
            currentMaxX = maxX;
        }
      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (powerUps.IsMissileActive())
            {
                FindObjectOfType<Missile>().Shoot();
            }
            else
            {
                ball.LaunchBall();
            }
        }
    }
}
