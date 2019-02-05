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
        Raycast();
	}
    public void Raycast()
    {
        if (moveLeft)
        {
            hitPlayer = Physics2D.Raycast(transform.position, Vector2.left, distanceRaycast);
            if (hitPlayer.collider != null)
            {
                if (hitPlayer.collider.tag == "Player")
                {
                    Debug.Log("ENTRE");
                    Player.InstancePlayer.Death();
                }
            }
        }
        if(moveRight)
        {
            hitPlayer = Physics2D.Raycast(transform.position, Vector2.right, distanceRaycast);
            if (hitPlayer.collider != null)
            {
                if (hitPlayer.collider.tag == "Player")
                {
                    Player.InstancePlayer.Death();
                }
            }
        }
    }
    public void Movement()
    {
        if(moveRight)
        {
            transform.position = transform.position - transform.up * Time.deltaTime * speed;
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
        if(collision.tag == "Player")
        {
            Debug.Log(Player.InstancePlayer.GetLife());
            Player.InstancePlayer.Death();
        }
    }
}
