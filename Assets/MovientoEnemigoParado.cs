using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovientoEnemigoParado : MonoBehaviour
{
    private float velocidad  = 3f; 
    private SpriteRenderer sprite;
    [SerializeField] private float radioDeteccion;
    private bool esDentro = false;
    private Transform transformPlayer;
    private Animator animator;
    private Vector3 positionAux;


    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        positionAux = gameObject.transform.position;
    }
    void Update()
    {
        dectectPlayer();
        if(esDentro){
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transformPlayer.position.x,transform.position.y), Time.deltaTime * velocidad  );
            animator.SetBool("Caminando",true);
        }else{
           
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(positionAux.x,transform.position.y), Time.deltaTime * velocidad );
            if(transform.position.x == positionAux.x ){
                animator.SetBool("Caminando",false);
            }
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
           if (transform.position.x < positionAux.x){
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
