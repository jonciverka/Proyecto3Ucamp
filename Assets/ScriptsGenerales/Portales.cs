using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portales : MonoBehaviour
{
    public string nombreNivel;
    public GameObject loading;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Player"){
            loading.SetActive(true);
            StartCoroutine(LoadYourAsyncScene());
        }
        IEnumerator LoadYourAsyncScene(){
            yield return new WaitForSeconds(5);
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nombreNivel);
            while (!asyncLoad.isDone){
                yield return null;
            }
        }
    }
}
