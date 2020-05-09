using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarP : MonoBehaviour
{

    private GameObject[] cambiarPersonaje;
    private int index;

    // Start is called before the first frame update
    void Start()
    {

        index = PlayerPrefs.GetInt("Characters");


        cambiarPersonaje = new GameObject[transform.childCount];


        for (int i = 0; i < transform.childCount; i++)
            cambiarPersonaje[i] = transform.GetChild(i).gameObject;

        foreach (GameObject objX in cambiarPersonaje)
            objX.SetActive(false);

        if (cambiarPersonaje[index])
            cambiarPersonaje[index].SetActive(true);
    }

    public void btnLeft()
    {
        cambiarPersonaje[index].SetActive(false);
        index--;
        if (index < 0)
            index = cambiarPersonaje.Length - 1;
        cambiarPersonaje[index].SetActive(true);
    }

    public void btnRight()
    {
        cambiarPersonaje[index].SetActive(false);
        index++;
        if (index == cambiarPersonaje.Length)
            index = 0;
        cambiarPersonaje[index].SetActive(true);
    }

    public void EscenaN()
    {
        PlayerPrefs.SetInt("Characters", index);
        SceneManager.LoadScene(1);

    }

    
    

}
