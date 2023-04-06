using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidasController : MonoBehaviour
{
    private int vidas = 3;
    public List<GameObject> vidaGUI;
    public GameObject gameOver;
    private void Start() {
        
        if(PlayerPrefs.HasKey("vida")){
            vidas = PlayerPrefs.GetInt("vida",vidas);
        }
        print(vidas);
        setInventarioUI();
    }
     public void setInventarioUI(){
        guardarPrefs();
        for(int i = 0; i<3; i++){
            vidaGUI[i].gameObject.SetActive(false);
        }
        for(int i = 0; i<vidas; i++){
            vidaGUI[i].gameObject.SetActive(true);
        }
    }
    public void restarVida(int danio){
        vidas = vidas - danio;
        if(vidas <=0){
            StartCoroutine(LoadYourAsyncScene());
            gameOver.SetActive(true);
        }
        setInventarioUI();
    }
    IEnumerator LoadYourAsyncScene(){
        yield return new WaitForSeconds(3);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Inicio");
        while (!asyncLoad.isDone){
            yield return null;
        }
    }
    public void sumarVida(){
        if(vidas<3){
            vidas ++;
        }
        setInventarioUI();
    }
    void guardarPrefs(){
        PlayerPrefs.SetInt("vida",vidas);
        PlayerPrefs.Save();
    }

}
