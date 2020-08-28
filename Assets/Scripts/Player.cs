﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : AbstactPlayer
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        PlayTurn();
    }

    protected override void PlayTurn()
    {
        if (nodoActual.getData() == endData)
        {

            Debug.Log("Fin");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Input.GetKeyDown("1") && nodoActual.adyacentes.Count > 0)
        {
            nodoActual = nodoActual.adyacentes[0];
            transform.position = new Vector3(nodoActual.gameObject.transform.position.x, nodoActual.gameObject.transform.position.y, -1);
            EndTurn();
        }
        if (Input.GetKeyDown("2") && nodoActual.adyacentes.Count > 1)
        {
            nodoActual = nodoActual.adyacentes[1];
            transform.position = new Vector3(nodoActual.gameObject.transform.position.x, nodoActual.gameObject.transform.position.y, -1);
            EndTurn();
        }
        if (Input.GetKeyDown("3") && nodoActual.adyacentes.Count > 2)
        {
            nodoActual = nodoActual.adyacentes[2];
            transform.position = new Vector3(nodoActual.gameObject.transform.position.x, nodoActual.gameObject.transform.position.y, -1);
            EndTurn();
        }
        if (Input.GetKeyDown("4") && nodoActual.adyacentes.Count > 3)
        {
            nodoActual = nodoActual.adyacentes[3];
            transform.position = new Vector3(nodoActual.gameObject.transform.position.x, nodoActual.gameObject.transform.position.y, -1);
            EndTurn();
        }
    }
}
