using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocaTemblorina : MonoBehaviour
{
    public GameObject caja;
    private Vector3 position;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Player"){
            position = gameObject.transform.position;
            caja.GetComponent<Animator>().SetBool("esTemblor", true);
            StartCoroutine(esperar(1));
        }
        
    }
    IEnumerator esperar(int secs){
        yield return new WaitForSeconds(secs);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name=="Enemigo"){
            caja.GetComponent<Animator>().SetBool("esTemblor", false);
            // Destroy(gameObject);
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            gameObject.transform.position = position;
        }
    }
}
