using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : Game
{
    private void Awake()
    {
        app.scenes = gameObject.GetComponent<Scenes>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
        SceneManager.LoadScene(app.saveSerial.curentLevel+2, LoadSceneMode.Additive);
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
    public void LevelsButton(int level)
    {
        app.saveSerial.curentLevel = level - 1;
        app.saveSerial.Save();
        app.scenes.LoadLevel();
    }

    public void Load1()
    {
        app.data.selectLevel = 1;
        LevelsButton(app.data.selectLevel);
    }
    public void Load2()
    {
        app.data.selectLevel = 2;
        LevelsButton(app.data.selectLevel);
    }
    public void Load3()
    {
        app.data.selectLevel = 3;
        LevelsButton(app.data.selectLevel);
    }
    public void Load4()
    {
        app.data.selectLevel = 4;
        LevelsButton(app.data.selectLevel);
    }
    public void Load5()
    {
        app.data.selectLevel = 5;
        LevelsButton(app.data.selectLevel);
    }
    public void Load6()
    {
        app.data.selectLevel = 6;
        LevelsButton(app.data.selectLevel);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
