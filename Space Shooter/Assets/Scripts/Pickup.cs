﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.CompareTag("Enemy") || other.CompareTag("Pickup"))
        {
            return;
        }

        if (other.tag == "Player")

        {
            Destroy(gameObject);
        }
    }
}
