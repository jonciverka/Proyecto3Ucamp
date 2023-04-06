    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogoRoca : MonoBehaviour
{
    
    public TextMeshProUGUI texto;
    public string[] dialogos;
    private float velicidad = 0.04f;
    private int index = 0;
   

    public void dialogosController(){
        texto.text = string.Empty;
        mostrarDialogo();

    }
   
    void Update() {
        if(Input.GetMouseButtonDown(0)){
            if(texto.text == dialogos[index]){
                NextLine();
            }else{
                StopAllCoroutines();
                texto.text = dialogos[index];
            }
        }
    }

    void mostrarDialogo(){
        
        StartCoroutine(LoadYourAsyncScene());
    }
    IEnumerator LoadYourAsyncScene(){
        foreach(char c in dialogos[index].ToCharArray()){
            texto.text  += c;
            yield return new WaitForSeconds(velicidad);
        }
    }
    void NextLine(){
        if(index < dialogos.Length - 1){
            index++;
            texto.text = string.Empty;
            StartCoroutine(LoadYourAsyncScene());
        }else{
            index = 0;
            gameObject.SetActive(false);
            StopAllCoroutines();
        }
    }
}







