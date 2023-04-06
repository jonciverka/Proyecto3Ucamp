using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class InventoryItem 
{
    public ObjectoData data ;
    public int stackSize;

    public InventoryItem(ObjectoData source){
        data = source;
        AddToStack();
    }
    public void AddToStack(){
        stackSize++;
    }
    public void RemoveToStack(){
        stackSize--;
    }
    public void setStack(int total ){
        stackSize = total;
    }
}



