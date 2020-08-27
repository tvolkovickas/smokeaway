using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float speed = -1.5f;
    [SerializeField] PowerUpTypes powerUpType;
    [SerializeField] AudioClip audioClip;
    PowerUps powerUps;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        powerUps = FindObjectOfType<PowerUps>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fag")
        {
            if (PlayerPrefs.GetString("audio") != "off")
            {
                AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
            }
            powerUps.ActivatePowerUp(powerUpType);
            Destroy(gameObject);
        }

        if (collision.tag == "BottomWall")
        {
            Destroy(gameObject);
        }
    }
}
