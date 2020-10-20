using UnityEngine;
[CreateAssetMenu(fileName ="new item",menuName ="Inventory item")]
public class itemstat : ScriptableObject
{
    public string itemname = "new item";
    public Sprite icon = null;
    public int emo = 1;
    public int con = 1;
    public int ext = 1;
    public int ope = 1;
    public int hon = 1;
    public int agr = 1;
    public string info = "this is info";
}
