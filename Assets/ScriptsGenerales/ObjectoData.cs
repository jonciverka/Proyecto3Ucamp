
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectoData", menuName = "Proyecto M3/ObjectoData", order = 1)]
public class ObjectoData : ScriptableObject {
    public int id;
    public string nombre;
    public GameObject prefab;
    public Sprite icon;
    
}
