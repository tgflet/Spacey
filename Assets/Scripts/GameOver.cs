using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static bool isFailure = false;
    private Text gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = GetComponent<Text>();
        gameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFailure)
        {
            Time.timeScale = 0;
            gameOver.enabled = true;
        }
        
    }
}
