using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] float initialSpeed = 2f;
    Vector2 distanceToFag;
    Fag fag;
    bool hasLaunched = false;
    Rigidbody2D rb;
    PowerUps powerUps;

    public void Shoot()
    {
        if (!hasLaunched)
        {
            hasLaunched = true;
            rb.velocity = (new Vector2(0f, 1f)) * initialSpeed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        fag = FindObjectOfType<Fag>();
        powerUps = FindObjectOfType<PowerUps>();
        distanceToFag = transform.position - fag.transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasLaunched)
        {
            transform.position = (new Vector2(fag.transform.position.x, fag.transform.position.y)) + distanceToFag;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TopWall")
        {
            Destroy(gameObject);
            powerUps.DeactivateMissile();
        }
    }
}
