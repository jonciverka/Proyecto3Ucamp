using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovientoEnemigo : MonoBehaviour
{
    [SerializeField] public GameObject[] limit;
    private float velocidad  = 2f; 
    private int indexActual = 0;
    private SpriteRenderer sprite;
    [SerializeField] private float radioDeteccion;
    private bool esDentro = false;
    private Transform transformPlayer;
    


    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
        
    }
    void Update()
    {
        dectectPlayer();
        if(esDentro==false){
            if(Vector2.Distance(limit[indexActual].transform.position, transform.position)< .1f){
                indexActual ++;
                if(indexActual >= limit.Length){
                    indexActual =0;
                }
            }
        }
        if(esDentro){
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transformPlayer.position.x,transform.position.y), Time.deltaTime * velocidad  );
        }else{
            transform.position = Vector2.MoveTowards(transform.position, limit[indexActual].transform.position, Time.deltaTime * velocidad );
        }
        movimiento();
    }
    private void movimiento(){
        if(esDentro){
           if (transform.position.x < transformPlayer.position.x){
                sprite.flipX = true;

            }else {
                sprite.flipX = false;
            }
        }else{
            if (transform.position.x < limit[indexActual].transform.position.x){
                sprite.flipX = true;

            }else {
                sprite.flipX = false;
            }
        }
    }

    private void dectectPlayer(){
        var aux = false;
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radioDeteccion);
        foreach(Collider2D colisionador in objetos){
           if(colisionador.CompareTag("Player")){
                aux = true;
                transformPlayer = colisionador.transform;
           }
        }

        if(aux){
            esDentro = true;
            
        }else{
            esDentro = false;
        }
        aux = false;
        
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioDeteccion);
    }
    

}
