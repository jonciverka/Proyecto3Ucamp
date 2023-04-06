using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private Vector3 checkPoint;

    public GameObject menuPause;
    public GameObject loading;
    private void Start() {

    }


    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)){
            pauseGame();
        }
    }
    public void setCheckPoint(Vector3 checkPointVector){
        checkPoint = checkPointVector;
    }
    public Vector3 getCheckPoint(){
        return checkPoint;
    }
    public void pauseGame (){
        Time.timeScale = 0;
        menuPause.SetActive(true);
    }
    public void resumeGame (){
        
        Time.timeScale = 1;
        menuPause.SetActive(false);
    }
    public void reiniciarJuego(){
        loading.SetActive(true);
        menuPause.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(LoadYourAsyncScene());
    }
    IEnumerator LoadYourAsyncScene(){
        yield return new WaitForSeconds(2);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Inicio");
        while (!asyncLoad.isDone){
            yield return null;
        }
    }


    


}
