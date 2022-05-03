using UnityEngine;
using System;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSerial : Game
{
    private void Awake()
    {
        app.saveSerial = gameObject.GetComponent<SaveSerial>();
        app.saveSerial.Load();
    }

    public SaveData saveData;

    //settings
    public bool buttonActive;
    public float buttonSize;

    //First
    public float[,] first = new float[2, 150];

    //Second
    public float[,] second = new float[2, 150];

    //Last
    public float[,] last = new float[2, 150];

    //Scenes
    public int curentLevel;
    public int lives;

    private void Start()
    {
        
        saveData = new SaveData();
        app.ui.controller.gameObject.SetActive(app.saveSerial.buttonActive);
        app.ui.controllerOn.gameObject.GetComponent<Toggle>().isOn = app.saveSerial.buttonActive;
        app.ui.controllerSize.gameObject.GetComponent<Slider>().value = app.saveSerial.buttonSize;
        Component[] buttons;

        buttons = app.ui.controller.gameObject.GetComponentsInChildren(typeof(RectTransform));
        float x = 100f + (150f * app.saveSerial.buttonSize);
        foreach (RectTransform button in buttons)
            button.sizeDelta = new Vector2(x, x);
    }

    public void Save()
    {
        //settings
        saveData.buttonActive = buttonActive;
        saveData.buttonSize = buttonSize;
        saveData.lives = lives;

        //first
        saveData.first = first;

        //Second
        saveData.second = second;

        //Last
        saveData.last = last;

        //Scenes
        saveData.curentLevel = curentLevel;

        if (!Directory.Exists(Application.persistentDataPath+"/Saves"))
        { 
            Directory.CreateDirectory(Application.persistentDataPath+"/Saves");
            Debug.Log("Create derictory /Saves");
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath+"/Saves/save.binary");
        bf.Serialize(file, saveData);
        file.Close();
        Debug.Log("Save file created");
    }

    public void Load()
    {
        try
        {
            if (File.Exists(Application.persistentDataPath + "/Saves/save.binary"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/Saves/save.binary", FileMode.Open);
                saveData = (SaveData)bf.Deserialize(file);
                file.Close();
                Debug.Log("Data loaded");

                //settings
                buttonActive = saveData.buttonActive;
                buttonSize = saveData.buttonSize;
                curentLevel = saveData.curentLevel;
                lives = saveData.lives;

                //first
                first = saveData.first;

                //Second
                second = saveData.second;

                //Last
                last = saveData.last;

                //Scenes
                Debug.Log("File Loaded!");
            }
            else
            {
                buttonActive = app.data.controllerOn;
                lives = 50;
                Debug.Log("File not exist. Please wait for Save new file!");
                Save();
            }
        }
        catch(FileNotFoundException e)
        {
            Debug.LogError(e + "\nFile not exist. Please wait for Save new file!");
        }
    }
    
    [Serializable]
    public class SaveData
    {
        //settings
        public bool buttonActive;
        public float buttonSize;
        
        //First
        public float[,] first = new float[2, 150];

        //Second
        public float[,] second = new float[2,150];

        //Last
        public float[,] last = new float[2,150];

        //Scenes
        public int curentLevel;
        public int lives;
    }
}
