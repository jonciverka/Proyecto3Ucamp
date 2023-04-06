using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameObject gameObject;
    private GameController gameController;
    private void Start() {
        gameObject = GameObject.FindGameObjectsWithTag("GameController")[0];
        gameController = gameObject.GetComponent<GameController>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            gameController.setCheckPoint(transform.position);
        }
    }
}
