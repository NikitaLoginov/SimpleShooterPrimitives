﻿using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public GameBehaviour gameManager;
    

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehaviour>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Item collected!");
            gameManager.Items += 1;
        }
    }
}
