using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspeccionar : MonoBehaviour
{
    public GameObject mensaje;
    private bool esDentro = false;
    public GameObject gameObjectaActivar;
    public GameObject panelDialogo;
    public InventorySystem  inventorySystem;
    public ObjectoData reference;
    public DialogoMago dialogoMago;
    

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            mensaje.gameObject.GetComponent<Animator>().SetBool("Mostrar",true);
            esDentro = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            mensaje.gameObject.GetComponent<Animator>().SetBool("Mostrar",false);
            esDentro = false;
        }
    }
    private void Update() {
        if( Input.GetKeyDown(KeyCode.E) && esDentro){
           if(gameObject.tag=="ObjetoMision"){
                gameObjectaActivar.SetActive(true);
                panelDialogo.SetActive(true);
                panelDialogo.GetComponent<DialogoRoca>().dialogosController();
                inventorySystem.Add(reference);
                Destroy(gameObject);
           }
           if(gameObject.tag=="ObjetoFinal"){
                gameObjectaActivar.SetActive(true);
                inventorySystem.Add(reference);
                Destroy(gameObject);
           }
           if(gameObject.name=="InspeccionarFinal"){
                var totems = GameObject.FindGameObjectsWithTag("Totems");
                foreach(GameObject totem in totems){
                    totem.GetComponent<Animator>().SetBool("Reviviendo", true);
                    totem.GetComponent<Animator>().SetBool("Vivo", true);
                    PlayerPrefs.SetInt("dialogoMagoNivel0", 4);
                    dialogoMago.dialogosController();
                }
           }
           if(gameObject.name=="Vida"){
                GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<VidasController>().sumarVida();
                Destroy(gameObject);

           }
        }
    }



}



