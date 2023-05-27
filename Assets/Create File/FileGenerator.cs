using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileGenerator : MonoBehaviour
{
    public string[] nd;
    public List<CharacterBOG> Bogs = new List<CharacterBOG>();
    private void Start()
    {
        //string[] split = data.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        //nd = split;

        /*string newpath = Application.dataPath + "/Metadata/";
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
        File.WriteAllText(newpath + "file1", toJson);*/

        string balanceData = Application.dataPath + "/Resources/BalanceData/balance data.txt";
        string fileData = File.ReadAllText(balanceData);
        nd = DataSplitter(fileData);
        
        string filePath = Application.dataPath + "/Resources/Files/";
        Bogs = GetListFile<CharacterBOG>(filePath, 276);
        
        StartCoroutine(DataValue(nd, Bogs));
    }

    private string[] DataSplitter(string data)
    {
        string[] tmp;

        tmp = data.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        
        return tmp;
    }

    private IEnumerator DataValue(string[] data, List<CharacterBOG> datas)
    {
        for (int i = 0; i < data.Length; i++)
        {
            int index = 0;
            CharacterBOG tmp = null;
            
            for (int j = 0; j < data[i].Length; j++)
            {
                if (int.TryParse(data[i][j].ToString(), out int v))
                {
                    tmp = EditAttributeBOG(datas[i], index, v);
                    index++;
                }
                
                yield return new WaitForSeconds(1f);
            }
            
            CreateNewFile(tmp, i + 1);
            Debug.Log($"Create No {i + 1}");
        }
    }

    CharacterBOG EditAttributeBOG(CharacterBOG bog, int index, int setValue)
    {
        bog.attributes[index].value = setValue.ToString();
        return bog;
    }

    private void CreateNewFile(CharacterBOG data, int fileIndex, string pathname = "/MetadataNew/")
    {
        string dir = Application.dataPath + pathname;
        string json = JsonUtility.ToJson(data);
        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
        
        File.WriteAllText(dir + fileIndex, json);
    }

    private T ReadRawFile<T>(string filePath)
    {
        string file = File.ReadAllText(filePath);
        T json = JsonUtility.FromJson<T>(file);
        
        return json;
    }

    private List<T> GetListFile<T>(string filePath, int dataAmount)
    {
        List<T> tmp = new List<T>();
        for (int i = 0; i < dataAmount; i++)
        {
            T newData = ReadRawFile<T>(filePath + (i + 1));
            tmp.Add(newData);
        }
        return tmp;
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




