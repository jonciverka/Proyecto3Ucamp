using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    [SerializeField] public GameObject[] limit;
    private float velocidad  = 2f; 
    private int indexActual = 0;

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(limit[indexActual].transform.position, transform.position)< .1f){
            indexActual ++;
            if(indexActual >= limit.Length){
                indexActual =0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, limit[indexActual].transform.position, Time.deltaTime * velocidad );
    }
}
