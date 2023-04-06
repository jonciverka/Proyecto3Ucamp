using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<ObjectoData, InventoryItem> dictionary;
    public List<GameObject> inventoryGUI;
    
    private void Awake() {
        dictionary = new Dictionary<ObjectoData, InventoryItem>();
        // clearInventory();
        if(PlayerPrefs.HasKey("save")){
            var text = PlayerPrefs.GetString("save");
            stringToInventory(text);
        }

    }
    public void Add(ObjectoData objectoData){
        if(dictionary.TryGetValue(objectoData, out InventoryItem value)){
            value.AddToStack();
            setInventarioUI();
            inentoryToString();
        }else{
            InventoryItem newItem = new InventoryItem(objectoData);
            dictionary.Add(objectoData, newItem);
            setInventarioUI();
            inentoryToString();
        }
    }
    public bool searchForObjectData(ObjectoData objectoData){
        if(dictionary==null){
           Awake(); 
        }
        if(dictionary.TryGetValue(objectoData, out InventoryItem value)){
            return true;
        }else{
            return false;
        }
    }
    public void clearInventory(){
        dictionary.Clear();
         if(dictionary.Count==0){
            for(int j = 0 ; j<inventoryGUI.Count; j++){
                inventoryGUI[j].gameObject.SetActive(false);
                inventoryGUI[j].gameObject.GetComponent<Image>().sprite = null;
            }
        }
        PlayerPrefs.DeleteKey("save");
        setInventarioUI();
    }
    public void Set(ObjectoData objectoData, int size){
        InventoryItem newItem = new InventoryItem(objectoData);
        newItem.setStack(size);
        dictionary.Add(objectoData, newItem);
    }
    public void Remove(ObjectoData objectoData){
        if(dictionary.TryGetValue(objectoData, out InventoryItem value)){
            value.RemoveToStack();
            if(value.stackSize==0){
                dictionary.Remove(objectoData);
            }
        }
    }
    public void setInventarioUI(){
        var i = 0;
        foreach (ObjectoData key in dictionary.Keys) {
            inventoryGUI[i].gameObject.SetActive(true);
            inventoryGUI[i].gameObject.GetComponent<Image>().sprite = dictionary[key].data.icon;
            i++;
        }
    }
    void guardarPrefs(string texto){
        PlayerPrefs.SetString("save",texto);
        PlayerPrefs.Save();
    }
    private void inentoryToString(){
        string objString = "";
        foreach (ObjectoData key in dictionary.Keys) {
            string json = JsonUtility.ToJson(dictionary[key]);
            objString = objString + json + "*";
        }
        guardarPrefs(objString);
    }
    private void stringToInventory(string text){
        var textSplit = text.Split('*');
        foreach (string key in textSplit) {
            if(key!=""){
                InventoryItem newItem = JsonUtility.FromJson<InventoryItem>(key);
                Set(newItem.data,newItem.stackSize);
            }
        }
         setInventarioUI();
    }
}





