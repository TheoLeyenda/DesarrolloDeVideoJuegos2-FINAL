using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour {

    // Use this for initialization
    public TimeOnPlay timeOnPlay;
    public GameObject spriteFrodo;
    public MoveCamera movCamera;
    [HideInInspector]
    public bool FroggyInTheHouse;
    public float diley;
    private float auxDiley;
    [HideInInspector]
    public bool GG;

    private void Start()
    {
        auxDiley = diley;
        spriteFrodo.SetActive(false);
        FroggyInTheHouse = false;
        GG = false;
    }
    private void Update()
    {
        CheckDiley();  
    }
    public void CheckDiley()
    {
        if(diley > 0 && FroggyInTheHouse)
        {
            diley = diley - Time.deltaTime;
            timeOnPlay.seconds = timeOnPlay.seconds + Time.deltaTime;
        }
        if(diley <= 0)
        {
            diley = auxDiley;
            FroggyInTheHouse = false;
            movCamera.cam.transform.position = movCamera.startPosition;
            timeOnPlay.seconds = timeOnPlay.seconds + 30;
            if(timeOnPlay.seconds > 59)
            {
                timeOnPlay.seconds = timeOnPlay.seconds - 59;
                timeOnPlay.minutes++;
            }
            GG = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player.InstancePlayer.transform.position = Player.InstancePlayer.StartPosition;
            Player.InstancePlayer.PosRespawn = Player.InstancePlayer.StartPosition;
            Player.InstancePlayer.score = Player.InstancePlayer.score + 50;
            Player.InstancePlayer.heigActuality = Player.InstancePlayer.StartPosition.y;
            Player.InstancePlayer.maxHeight = Player.InstancePlayer.heigActuality;
            movCamera.boxCollider.isTrigger = true;
            movCamera.gameObject.tag = "PASAJE DE FASE";
            movCamera.activateMovementCamera = false;
            spriteFrodo.SetActive(true);
            FroggyInTheHouse = true;
        }
    }
}
