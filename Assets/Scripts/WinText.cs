using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinText : MonoBehaviour
{
    public static bool isWinner=false;
    private Text winner;
    // Start is called before the first frame update
    void Start()
    {
        winner = GetComponent<Text>();
        winner.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWinner)
        {
            Time.timeScale = 0;
            winner.enabled = true;
        }
    }
}
