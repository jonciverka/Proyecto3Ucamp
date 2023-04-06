using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loby : MonoBehaviour
{

    public GameObject loading;

    void Start()
    {
        //  PlayerPrefs.DeleteAll();
    }
    public void iniciarJuego(){
        loading.SetActive(true);
        StartCoroutine(LoadYourAsyncScene());
    }
    IEnumerator LoadYourAsyncScene(){
         StopAllCoroutines();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Nivel 0",LoadSceneMode.Single);
        while (!asyncLoad.isDone){
            yield return null;
        }
    }
}
