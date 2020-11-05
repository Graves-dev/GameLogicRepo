using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataPref : MonoBehaviour
{
   public static DataPref dataManagement;
   public int highScore;

//Awake happens before start
   void Awake ()    {
       if (dataManagement == null) {
           DontDestroyOnLoad (gameObject);
           dataManagement = this;
       } else if (dataManagement != this)   {
           Destroy (gameObject);
       }
   }
   public void SaveData()   {
    //Data is saved
    BinaryFormatter BinForm = new BinaryFormatter(); //creates a binary formatter
    FileStream file = File.Create(Application.persistentDataPath + "/ganeInfo.dat"); //creates file
    GameData data = new GameData(); //creates container for data
    data.highScore = highScore; //keeps track of score
    //same system is used to keep track of other things we'd like the game to remember like coins
    BinForm.Serialize (file, data); //serializes 
    file.Close();//closes file
   }
   public void LoadData()   {
    //Data is loaded
    if (File.Exists (Application.persistentDataPath + "/ganeInfo.dat"))   {
        BinaryFormatter BinForm = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/ganeInfo.dat", FileMode.Open);
        DataPref data = (DataPref)BinForm.Deserialize (file);
        file.Close();
        highScore = data.highScore;
    }
   }
}
//Specifies the class is serialized
[Serializable] 
class GameData {
    public int highScore;
}