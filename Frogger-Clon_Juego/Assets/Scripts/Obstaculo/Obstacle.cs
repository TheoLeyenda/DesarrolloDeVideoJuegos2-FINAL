using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    // Use this for initialization
    public float speed;
    public Transform posStart;
    public Transform posFinish;
    public Transform originRayCast;
    private RaycastHit2D hitPlayer;
    public float distanceRaycast;
    [SerializeField]
    private bool moveLeft;
    [SerializeField]
    private bool moveRight;
    private Player player;
	void Start () {
        player = Player.InstancePlayer;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}
    public void Movement()
    {
        if(moveRight)
        {
            transform.position = transform.position + transform.up * Time.deltaTime * speed;
        }
        if(moveLeft)
        {
            transform.position = transform.position + transform.up * Time.deltaTime * speed;
        }
        if(transform.position.x <= posFinish.position.x && moveLeft)
        {
            transform.position = posStart.position;
        }
        if(transform.position.x >= posFinish.position.x && moveRight)
        {
            transform.position = posStart.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && gameObject.tag != "TRONCO")
        {
            Player.InstancePlayer.Death();
        }
    }
     private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && transform.tag == "TRONCO")
        {
            if (moveRight)
            {
                Player.InstancePlayer.transform.position = Player.InstancePlayer.transform.position + Player.InstancePlayer.transform.right * Time.deltaTime * speed;
            }
            else
            {
                Player.InstancePlayer.transform.position = Player.InstancePlayer.transform.position - Player.InstancePlayer.transform.right * Time.deltaTime * speed;
            }
        }
    }
}
