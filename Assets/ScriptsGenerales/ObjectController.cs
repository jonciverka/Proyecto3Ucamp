using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private GameObject[] objetosMision;
    private ObjectoData[] ObjectoDatas;
    public InventorySystem inventorySystem;
    public GameObject portalSalida;
    void Start(){
        objetosMision = GameObject.FindGameObjectsWithTag("ObjetoMision");
        foreach (GameObject objetoMision in objetosMision){
           if(inventorySystem.searchForObjectData(objetoMision.GetComponent<Inspeccionar>().reference)){
                Destroy(objetoMision);
                portalSalida.SetActive(true);
           }
        }
        
    }

   
}
