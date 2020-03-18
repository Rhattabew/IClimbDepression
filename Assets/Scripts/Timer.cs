using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Text timerText;
    public float seconds;

    private void Start()
    {
        //Allows for the text to be displayed in the UI
        timerText = GetComponent<Text>() as Text;
    }

    public void Update()
    {
        //Gets the current time allowing the timer to go up
        seconds = (int)(Time.time);
        //Creates the string in the game UI to show the players time
        timerText.text = "Time: " + seconds.ToString("00");
    }
}
