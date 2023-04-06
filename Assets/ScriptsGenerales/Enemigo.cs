using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour{
    public int danio;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Player"){
            other.gameObject.GetComponent<Player>().danio(danio);
        }
    }
    public void morir(){
        Destroy(gameObject);
    }


}
