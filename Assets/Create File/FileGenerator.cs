using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileGenerator : MonoBehaviour
{
    public int[,] datas = new int[,] { };
    public string[] nd;
    private void Start()
    {
        string filePath = Application.dataPath + "/Resources/";       
        string file = "BalanceData/balance data.txt";
        string data = File.ReadAllText(filePath + file);

        string[] split = data.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        nd = split;

        string newpath = Application.dataPath + "/Metadata/";
        if (!Directory.Exists(newpath)) Directory.CreateDirectory(newpath);

        string fileJson = filePath + "/Files/" + 1;
        string json = File.ReadAllText(fileJson);
        CharacterBOG character = JsonUtility.FromJson<CharacterBOG>(json);
        Debug.Log(JsonUtility.ToJson(character));
        AttributeBOG newAtribut = new AttributeBOG
        {
            trait_type = "BOG",
            value = "Halloo"
        };
        
        character.attributes.Add(newAtribut);
        
        Debug.Log(JsonUtility.ToJson(character));

        string toJson = JsonUtility.ToJson(character);
        File.WriteAllText(newpath + "file1", toJson);
    }
    
}

[System.Serializable]
public class AttributeBOG
{
    public string trait_type;
    public string value;
}


[System.Serializable]
public class CharacterBOG
{
    public string name;
    public string description;
    public string image;
    public string turntable;
    public string promotionalImg;
    public string external_url;
    public List<AttributeBOG> attributes;
}




