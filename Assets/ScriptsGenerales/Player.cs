using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float horizontal;
    private float velocidad = 5f;
    [SerializeField]  private float velocidadSalto = 10f;
    [SerializeField] private float velocidadSaltoMod = 3f;
    private bool saltar = true;
    public Animator animator;
    private Vector3 previus;

    private Rigidbody2D rigidbody2D;
    private GameObject gameObject;
    private GameController gameController;
    [SerializeField] private VidasController vidasController;
    [SerializeField] private Transform transformGolpe;
    [SerializeField] private float radioDeteccion;
    private bool derecha = true;
    private bool izquierda = false;
    private bool esGolpe = false;


    void Start()
    {
        //  PlayerPrefs.DeleteAll();
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        gameObject = GameObject.FindGameObjectsWithTag("GameController")[0];
        gameController = gameObject.GetComponent<GameController>();
        vidasController = GetComponent<VidasController>();
    }

    void Update(){
        horizontal = Input.GetAxisRaw("Horizontal");
        var saltoInput = Input.GetKeyDown(KeyCode.Space);
        var saltoInputReleased = Input.GetKeyUp(KeyCode.Space);
        rigidbody2D.velocity = new Vector2(horizontal*velocidad, rigidbody2D.velocity.y);
        if (saltoInput && saltar){
            saltar = false; 
            animator.SetBool("Saltando", true);
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,velocidadSalto);
        }
        if(saltoInputReleased && rigidbody2D.velocity.y >0){
            rigidbody2D.velocity  = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y/velocidadSaltoMod);
        }
        if(rigidbody2D.velocity.y < -1.0f){
            animator.SetBool("Callendo", true);
        }
        if(rigidbody2D.velocity.y==0){
            animator.SetBool("Callendo", false);
        }
        if(Input.GetMouseButtonDown(0)){
            animator.SetTrigger("Ataque");
        }
        golpe();

    }
    private void FixedUpdate() {
        movimiento();
    }
    private void movimiento(){
        if (horizontal > 0 & izquierda ){
            derecha = true;
            izquierda = false;
            transform.Rotate(new Vector3(0,180,0)); 
        }
        if (horizontal < 0 & derecha){
            
            derecha = false;
            izquierda = true;
            transform.Rotate(new Vector3(0,180,0)); 
        }
        if(horizontal!=0 ){
                animator.SetBool("Caminando", true);
        }else{
            animator.SetBool("Caminando", false);
        }
    }
    private void OnCollisionStay2D(Collision2D other) {
       comprobarEsPiso(other);
    }
    private void OnCollisionEnter2D(Collision2D other) {
      comprobarEsPiso(other);
    }
    private void OnCollisionExit2D(Collision2D other) {
         if (other.collider.CompareTag("Plataform")){
            saltar = false; 
            animator.SetBool("Saltando", true);
         }
    }
    void comprobarEsPiso(Collision2D other){
         if (other.collider.CompareTag("Plataform")){
            var aux = false;
            foreach (ContactPoint2D contact in other.contacts){
                if(Mathf.Round(contact.normal.x)==0){
                    aux = true;
                }
            }
            if(aux){
                animator.SetBool("Saltando", false);
                animator.SetBool("Callendo", false);
                saltar = true;
            }
        }
    }
    public void danio(int danio){
        transform.position = gameController.getCheckPoint();
        vidasController.restarVida(danio);
    }
  
    public Vector2 getVelocidad(){
        return rigidbody2D.velocity;
    }

    public void golpe(){
        if(esGolpe){
            Collider2D[] objetos = Physics2D.OverlapCircleAll(transformGolpe.position, radioDeteccion);
            foreach(Collider2D colisionador in objetos){
            if(colisionador.CompareTag("Enemigo")){
                    colisionador.GetComponent<Enemigo>().morir();
            }
            }
        }
    }
    public void setEsGolpe(){
        esGolpe = true;
    }
    public void setNoEsGolpe(){
        esGolpe = false;
    }
    
     private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transformGolpe.position, radioDeteccion);
    }
   
    


}