using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    // Use this for initialization
    public float speedMovementCamera;
    public GameObject cam;
    [HideInInspector]
    public BoxCollider2D boxCollider;
    public GameObject FinishPoint;
    [HideInInspector]
    public bool activateMovementCamera;
    [HideInInspector]
    public Vector3 startPosition;
    void Start ()
    {
        startPosition = cam.transform.position;
        activateMovementCamera = false;
        boxCollider = GetComponent<BoxCollider2D>();
	}
    private void Update()
    {
        if (activateMovementCamera)
        {
            MovementCamera();
        }
    }
    public void MovementCamera()
    {
        if (cam.transform.position.y < FinishPoint.transform.position.y)
        {
            cam.transform.position = cam.transform.position + cam.transform.up * Time.deltaTime * speedMovementCamera;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            activateMovementCamera = true;
            Player.InstancePlayer.transform.position = new Vector3(Player.InstancePlayer.transform.position.x, Player.InstancePlayer.transform.position.y + Player.InstancePlayer.speed, Player.InstancePlayer.transform.position.z);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            boxCollider.isTrigger = false;
            gameObject.tag = "NO PASABLE";
            Player.InstancePlayer.PosRespawn = new Vector3(0, Player.InstancePlayer.transform.position.y, Player.InstancePlayer.transform.position.z);
        }
    }
}
