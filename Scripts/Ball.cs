using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float initialSpeed = 2f;
    [SerializeField] AudioClip bounce;
    [SerializeField] AudioClip lose;

    PowerUps powerUps;
    GameState gameState;
    float currentSpeed;
    Vector2 distanceToFag;
    bool hasLaunched = false;
    Rigidbody2D rb;
    AudioSource audioSource;
    Fag fag;

    public void IncreaseSpeed(float speed)
    {
        currentSpeed += speed;
    }

    public void ResetSpeed()
    {
        currentSpeed = initialSpeed;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void ResetPosition()
    {
        hasLaunched = false;
    }

    public void LaunchBall()
    {
        if(gameObject.activeSelf && !hasLaunched)
        {
            hasLaunched = true;
            rb.velocity = (new Vector2(0f, 1f)) * currentSpeed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameState = FindObjectOfType<GameState>();
        powerUps = FindObjectOfType<PowerUps>();
        fag = FindObjectOfType<Fag>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        distanceToFag = transform.position - fag.transform.position;
        currentSpeed = initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasLaunched)
        {
            transform.position = (new Vector2(fag.transform.position.x, fag.transform.position.y)) + distanceToFag;
        } else
        {
            if (powerUps.IsMegaBallActive())
            {
                transform.localScale = new Vector3(2f, 2f, 1f);
            }
            else
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        float xVelocity = rb.velocity.normalized.x;
        float yVelocity = rb.velocity.normalized.y;

        if(xVelocity < 0)
        {
            xVelocity = Mathf.Clamp(xVelocity, -1f, -0.5f);
        }
        if (xVelocity >= 0)
        {
            xVelocity = Mathf.Clamp(xVelocity, 0.5f, 1f);
        }
        if (yVelocity < 0)
        {
            yVelocity = Mathf.Clamp(xVelocity, -1f, -0.5f);
        }
        if (yVelocity >= 0)
        {
            yVelocity = Mathf.Clamp(xVelocity, 0.5f, 1f);
        }

        rb.velocity = (new Vector2(xVelocity, yVelocity))* currentSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BottomWall")
        {
            audioSource.clip = lose;
            if (PlayerPrefs.GetString("audio") != "off")
            {
                audioSource.Play();
            }
            gameState.LooseLife();
        }

        if (hasLaunched)
        {
            audioSource.clip = bounce;
            if (PlayerPrefs.GetString("audio") != "off")
            {
                audioSource.Play();
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * currentSpeed;
    }
}
