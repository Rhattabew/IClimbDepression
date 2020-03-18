using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public float score;
    public GameObject player;
    float height;
    float seconds;

    private void Start()
    {
        //Allows for the text to be displayed in the UI
        scoreText = GetComponent<Text>() as Text;
    }

    void Update()
    {
        seconds = (int)(Time.time);
        height = player.transform.position.y;
        score = height * seconds;
        scoreText.text = "Score:" + score;
    }
}
