using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenController : MonoBehaviour
{

    // Use this for initialization
    public GameObject logoEmpresa;
    public GameObject logoJuego;
    private float TransparenciaLogoEmpresa;
    private float TransparenciaLogoJuego;
    private bool entrarLogoEmpresa;
    private bool entrarLogoJuego;
    private bool soloUnaVez;
    private bool sumar;
    private bool restar;
    private float tiempo;
    private float diley;
    private float finalDileyLogoEmpresa = 2f;
    private float inicioTransparenciaLogoEmpresa = 1f;
    private float finalTransparenciaLogoEmpresa = 0;
    private float finalTiempo1 = 2;
    private float finalTiempo2 = 5;
    private float finalTiempo3 = 3.5f;
    private float finalTiempo4 = 5f;
    void Start()
    {
        TransparenciaLogoEmpresa = 0;
        TransparenciaLogoJuego = 0;
        entrarLogoEmpresa = false;
        entrarLogoJuego = false;
        sumar = true;
        restar = false;
        soloUnaVez = true;
        tiempo = 0;
        diley = 0;
        Material tempMatEmpresa = logoEmpresa.GetComponent<MeshRenderer>().sharedMaterial;
        tempMatEmpresa.color = new Color(tempMatEmpresa.color.r, tempMatEmpresa.color.g, tempMatEmpresa.color.b, TransparenciaLogoEmpresa);
        Material tempMatJuego = logoEmpresa.GetComponent<MeshRenderer>().sharedMaterial;
        tempMatJuego.color = new Color(tempMatJuego.color.r, tempMatJuego.color.g, tempMatJuego.color.b, TransparenciaLogoJuego);
        logoEmpresa.GetComponent<MeshRenderer>().sharedMaterial.color = tempMatEmpresa.color;
        logoJuego.GetComponent<MeshRenderer>().sharedMaterial.color = tempMatJuego.color;
        logoJuego.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        diley = diley + Time.deltaTime;
        if (diley >= finalDileyLogoEmpresa && soloUnaVez)
        {
            entrarLogoEmpresa = true;
            soloUnaVez = false;
            //diley = 0;
        }

        if (entrarLogoEmpresa)
        {
            if (logoEmpresa != null)
            {
                logoEmpresa.GetComponent<MeshRenderer>().material.color = new Color(logoEmpresa.GetComponent<MeshRenderer>().material.color.r, logoEmpresa.GetComponent<MeshRenderer>().material.color.g, logoEmpresa.GetComponent<MeshRenderer>().material.color.b, TransparenciaLogoEmpresa);
            }
            tiempo = tiempo + Time.deltaTime;
            if (TransparenciaLogoEmpresa < inicioTransparenciaLogoEmpresa && sumar)
            {
                TransparenciaLogoEmpresa = TransparenciaLogoEmpresa + Time.deltaTime;
            }
            if (tiempo >= finalTiempo1 && tiempo < finalTiempo2)
            {
                sumar = false;
                restar = true;
            }
            if (TransparenciaLogoEmpresa >= finalTransparenciaLogoEmpresa && restar)
            {
                TransparenciaLogoEmpresa = TransparenciaLogoEmpresa - Time.deltaTime;
            }
            if (tiempo >= finalTiempo3)
            {
                //Destroy(logoEmpresa);
                logoEmpresa.SetActive(false);
            }
            if (tiempo >= finalTiempo4)
            {
                entrarLogoEmpresa = false;
                entrarLogoJuego = true;
                sumar = true;
                restar = false;
                tiempo = 0;
            }
        }

        if (entrarLogoJuego)
        {
            logoJuego.SetActive(true);
            if (logoJuego != null)
            {
                logoJuego.GetComponent<MeshRenderer>().material.color = new Color(logoJuego.GetComponent<MeshRenderer>().material.color.r, logoJuego.GetComponent<MeshRenderer>().material.color.g, logoJuego.GetComponent<MeshRenderer>().material.color.b, TransparenciaLogoJuego);
            }
            tiempo = tiempo + Time.deltaTime;
            if (TransparenciaLogoJuego < inicioTransparenciaLogoEmpresa && sumar)
            {
                TransparenciaLogoJuego = TransparenciaLogoJuego + Time.deltaTime;
            }
            if (tiempo >= finalTiempo1 && tiempo < finalTiempo2)
            {
                sumar = false;
                restar = true;
            }
            if(TransparenciaLogoJuego >= finalTransparenciaLogoEmpresa && restar)
            {
                TransparenciaLogoJuego = TransparenciaLogoJuego - Time.deltaTime;
            }

            if (tiempo >= finalTiempo3)
            {   
                entrarLogoEmpresa = false;
                entrarLogoJuego = false;
                sumar = true;
                restar = false;
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
