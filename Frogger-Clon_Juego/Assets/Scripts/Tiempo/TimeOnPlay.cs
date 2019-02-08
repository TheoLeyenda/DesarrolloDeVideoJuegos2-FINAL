using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeOnPlay : MonoBehaviour {

    // Use this for initialization
    public Text time;
    public float minutes;
    public float seconds;
    private float auxMinutes;
    private float auxSeconds;
    private Player player;
    private bool timeOver = false;
	void Start () {
        if(Player.InstancePlayer != null)
        {
            player = Player.InstancePlayer;
        }
        auxMinutes = minutes;
        auxSeconds = seconds;
	}
	
	// Update is called once per frame
	void Update () {
        CheckTime();
	}
    public void CheckTime()
    {
        if (seconds <= 0 && minutes <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (player != null)
        {
            if (timeOver)
            {
                seconds = auxSeconds;
                minutes = auxMinutes;
                timeOver = false;
                if (seconds >= 10)
                {
                    time.text = "Tiempo: " + (int)minutes + ":" + (int)seconds;
                }
                if (seconds < 10)
                {
                    time.text = "Tiempo: " + (int)minutes + ":0" + (int)seconds;
                }
            }
        }
        if (seconds <= 0 && minutes > 0)
        {
            seconds = 59;
            minutes--;
        }
        if (seconds >= 10)
        {
            time.text = "Tiempo: "+ (int)minutes + ":" + (int)seconds;
        }
        if (seconds < 10)
        {
            time.text = "Tiempo: " + (int)minutes + ":0" + (int)seconds;
        }
        seconds = seconds - Time.deltaTime;
        if (DataStructure.auxiliaryDataStructure != null)
        {
            DataStructure.auxiliaryDataStructure.playerData.minutes = minutes;
            DataStructure.auxiliaryDataStructure.playerData.Seconds = seconds;
        }
    }
}