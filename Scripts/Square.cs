using System;
using UnityEngine;

public class Square : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX;
    [SerializeField] Sprite[] damageLevels;
    GameState gameState;
    PowerUps powerUps;
    SpriteRenderer spriteRenderer;
    int maxDamage = 2;
    int currentDamage = 0;

    private void Start()
    {
        gameState = FindObjectOfType<GameState>();
        gameState.CountSquares();
        powerUps = FindObjectOfType<PowerUps>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentDamage++;
        if (powerUps.IsMegaBallActive())
        {
            currentDamage = maxDamage + 1;
        }

        if (currentDamage > maxDamage)
        {
            DestroySqure();
        }
        else
        {
            spriteRenderer.sprite = damageLevels[currentDamage - 1];
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Missile")
        {
            DestroySqure();
        }
    }

    private void DestroySqure()
    {
        Destroy(gameObject);
        gameState.DestroySquare();
        var explosion = Instantiate(destroyVFX, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(explosion, 2f);
        powerUps.CreatePowerUp(gameObject.transform.position, gameObject.transform.rotation);
    }
}
