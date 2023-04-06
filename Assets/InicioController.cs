using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioController : MonoBehaviour
{
    public GameObject loading;
   
   public void iniciarJuego(){
        
        PlayerPrefs.DeleteAll();
        loading.SetActive(true);
        StartCoroutine(LoadYourAsyncScene());

    }
    IEnumerator LoadYourAsyncScene(){
        yield return new WaitForSeconds(5);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Nivel 0");
        while (!asyncLoad.isDone){
            yield return null;
        }
    }
}
