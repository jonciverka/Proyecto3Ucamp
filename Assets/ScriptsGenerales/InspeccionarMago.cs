using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspeccionarMago : MonoBehaviour
{
    public GameObject mensaje;
    private bool esDentro = false;
    public GameObject gameObjectaActivar;
    public InventorySystem  inventorySystem;
    public ObjectoData piedraAzil;
    public ObjectoData priedraRoja;
    public ObjectoData piedraMorada;
    public ObjectoData piedraPrincipal;
    public GameObject gameObjectaActivarFinal;

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
            if(inventorySystem.searchForObjectData(piedraAzil) && inventorySystem.searchForObjectData(priedraRoja) && inventorySystem.searchForObjectData(piedraMorada)){
                PlayerPrefs.SetInt("dialogoMagoNivel0", 2);
                gameObjectaActivar.GetComponent<DialogoMago>().pasaAlaSiguienteFase = true;
                gameObjectaActivar.GetComponent<DialogoMago>().dialogosController();
                gameObjectaActivar.SetActive(true);
                // inventorySystem.clearInventory();
            }else{
                gameObjectaActivar.SetActive(true);
                gameObjectaActivar.GetComponent<DialogoMago>().pasaAlaSiguienteFase = false;
                gameObjectaActivar.GetComponent<DialogoMago>().dialogosController();
            }

        }
    }

    public void soltarObjectoPrincipal(){
        piedraPrincipal.prefab.gameObject.GetComponent<Inspeccionar>().inventorySystem = inventorySystem;
        piedraPrincipal.prefab.gameObject.GetComponent<Inspeccionar>().gameObjectaActivar = gameObjectaActivarFinal;
        Instantiate(piedraPrincipal.prefab, new Vector3(73.5f,4.56f,0),gameObject.transform.rotation); 
    }



}
