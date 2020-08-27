using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] GameObject[] lives;
    GameState gameState;

    public void UpdateLives()
    {
        int currentLives = gameState.GetLives();
        for (int i = currentLives; i < lives.Length; i++)
        {
            lives[i].SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameState = FindObjectOfType<GameState>();
        int currentLives = gameState.GetLives();
        for (int i = currentLives; i < lives.Length; i++)
        {
            lives[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
