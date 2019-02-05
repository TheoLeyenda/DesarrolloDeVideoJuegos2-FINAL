using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoJugador : MonoBehaviour {

    // Use this for initialization
    public Camera refCamara;
    public GameObject refJugador;
    private Vector3 direcion;
    public float velocidadJugador;
    private float x;
    private float y;
	void Start () {
        x = refJugador.transform.position.x;
        y = refJugador.transform.position.y;
        //transform.Rotate(new Vector3(90, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow) && refCamara.WorldToScreenPoint(transform.position).y<refCamara.pixelHeight-20)
        {
            y = y + velocidadJugador;
            direcion = new Vector3(x, y, 0);
            refJugador.transform.position = direcion;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && refCamara.WorldToScreenPoint(transform.position).x>30)
        {
            x = x - velocidadJugador;
            direcion = new Vector3(x, y, 0);
            refJugador.transform.position = direcion;
        }
        if (Input.GetKey(KeyCode.RightArrow) && refCamara.WorldToScreenPoint(transform.position).x < refCamara.pixelWidth-30)
        {
            x = x + velocidadJugador;
            direcion = new Vector3(x, y, 0);
            refJugador.transform.position = direcion;
        }
        if (Input.GetKey(KeyCode.DownArrow) && refCamara.WorldToScreenPoint(transform.position).y > 20)
        {
            y = y - velocidadJugador;
            direcion = new Vector3(x, y, 0);
            refJugador.transform.position = direcion;
        }
       // direcion = new Vector3(x, 0, z);
        //refJugador.transform.position = direcion;
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FinNivel")
        {
            SceneManager.LoadScene("Texto_Nivel2");
        }
    }
}

