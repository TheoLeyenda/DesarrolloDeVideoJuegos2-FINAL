using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    // Use this for initialization
    public Camera mainCamera;
    public float speed;
    public static Player InstancePlayer;

    private Vector3 StartPosition;
    private Animator animatorFrodo;
    private float x;
    private float y;
    private int life = 3;
    private bool moveForward;
    private bool moveBack;
    private bool moveRight;
    private bool moveLeft;
    private RaycastHit2D hitForward;
    private RaycastHit2D hitBack;
    private RaycastHit2D hitRight;
    private RaycastHit2D hitLeft;
    private float relativeOrigin = 0.1f;
    private float subtractH = 0.05f;
    [SerializeField]
    private float distaceRaycast;
    [SerializeField]
    private Transform originForward;
    [SerializeField]
    private Transform originBack;
    [SerializeField]
    private Transform originLeft;
    [SerializeField]
    private Transform originRight;

    void Start() {
        InstancePlayer = this;
        StartPosition = transform.position;
        moveForward = true;
        moveBack = true;
        moveRight = true;
        moveLeft = true;
        x = transform.position.x;
        y = transform.position.y;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        animatorFrodo = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        Movement();
        Raycasting();
    }
    public void Raycasting()
    {

        hitForward = Physics2D.Raycast(originForward.position, Vector2.up, distaceRaycast);
        if (hitForward.collider != null)
        {
            if (hitForward.collider.tag == "NO PASABLE")
            {
                moveForward = false;
            }
        }
        else if (hitForward.collider == null)
        {
            moveForward = true;
        }

        hitBack = Physics2D.Raycast(originBack.position, Vector2.down, distaceRaycast);
        if (hitBack.collider != null)
        {
            if (hitBack.collider.tag == "NO PASABLE")
            {
                moveBack = false;
            }
        }
        else if (hitBack.collider == null)
        {
            moveBack = true;
        }

        hitLeft = Physics2D.Raycast(originLeft.position, Vector2.left, distaceRaycast);
        if (hitLeft.collider != null)
        {
            if (hitLeft.collider.tag == "NO PASABLE")
            {
                moveLeft = false;
            }
        }
        else if (hitLeft.collider == null)
        {
            moveLeft = true;
        }

        hitRight = Physics2D.Raycast(originRight.position, Vector2.right,distaceRaycast);
        if (hitRight.collider != null)
        {
            if (hitRight.collider.tag == "NO PASABLE")
            {
                moveRight = false;
            }
        }
        else if (hitRight.collider == null)
        {
            moveRight = true;
        }
        //Debug.DrawLine(transform.position, Vector3.down);
    }
    public void Movement()
    {
        if (moveForward)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                animatorFrodo.SetBool("Adelante", true);
                animatorFrodo.SetBool("Atras", false);
                animatorFrodo.SetBool("Izquierda", false);
                animatorFrodo.SetBool("Derecha", false);
                y = y + speed;
                transform.position = new Vector3(transform.position.x, y, transform.position.z);
            }
        }
        if (moveBack)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                animatorFrodo.SetBool("Adelante", false);
                animatorFrodo.SetBool("Atras", true);
                animatorFrodo.SetBool("Izquierda", false);
                animatorFrodo.SetBool("Derecha", false);
                y = y - speed;
                transform.position = new Vector3(transform.position.x, y, transform.position.z);

            }
        }
        if (moveLeft)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

                animatorFrodo.SetBool("Adelante", false);
                animatorFrodo.SetBool("Atras", false);
                animatorFrodo.SetBool("Izquierda", true);
                animatorFrodo.SetBool("Derecha", false);
                x = x - speed;
                transform.position = new Vector3(x, transform.position.y, transform.position.z);
            }
        }
        if (moveRight)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                animatorFrodo.SetBool("Adelante", false);
                animatorFrodo.SetBool("Atras", false);
                animatorFrodo.SetBool("Izquierda", false);
                animatorFrodo.SetBool("Derecha", true);
                x = x + speed;
                transform.position = new Vector3(x, transform.position.y, transform.position.z);
            }
        }
    }
    public void SetLife(int _life)
    {
        life = _life;
    }
    public void Death()
    {
        SubstractLife();
        transform.position = StartPosition;
        x = transform.position.x;
        y = transform.position.y;
        if(life < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public int GetLife()
    {
        return life;
    }
    public void SubstractLife()
    {
        life = life - 1;
    }
    public void AddLife()
    {
        life = life + 1;
    }
    
}
