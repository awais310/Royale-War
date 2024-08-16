using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class gamemanager: MonoBehaviour
{
   
   
    //public GameObject SpawnFacts4, SpawnFacts5, SpawnFacts6;
    public GameObject[] Levels;
    //public Text leveltext;
    //public Text level;
    public GameObject PausePanel;
   
    // Start is called before the first frame update
    void Start()
    {
       PausePanel.SetActive(false);
        //if (!PlayerPrefs.HasKey("Levels"))
        //{
        //    PlayerPrefs.SetInt("Levels", 0);
        //}
        //if (!PlayerPrefs.HasKey("LevelsNo"))
        //{
        //    PlayerPrefs.SetInt("LevelsNo", 1);
        //}
        //Levels[PlayerPrefs.GetInt("Levels")].SetActive(true);
        if(DataStore.inst.dts.crrLevel < Levels.Length - 1)
        {
            Levels[DataStore.inst.dts.crrLevel].SetActive(true);
        }
        else
        {
            int randomIndex = UnityEngine.Random.Range(0, Levels.Length);

            // Set all elements' active property to false first
            for (int i = 0; i < Levels.Length; i++)
            {
                print("hello");
                Levels[i].active = false;
            }

            // Set the active property of the randomly selected element to true
            Levels[randomIndex].active = true;
        }
        

        //GameObject spawnFact4 = Instantiate(SpawnFacts4, SpawnFacts4.transform.position, Quaternion.identity);
        //GameObject spawnFact5 = Instantiate(SpawnFacts5, SpawnFacts5.transform.position, Quaternion.identity);
        //GameObject spawnFact6 = Instantiate(SpawnFacts6, SpawnFacts6.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //level.text = "Level. " + PlayerPrefs.GetInt("LevelsNo");
       
    }
    public void closeP()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void play()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void NextLevel()
    {
        if (/*PlayerPrefs.GetInt("Levels")*/DataStore.inst.dts.crrLevel < Levels.Length - 1)
        {
            // PlayerPrefs.SetInt("Levels", PlayerPrefs.GetInt("Levels") + 1);
            //PlayerPrefs.SetInt("LevelsNo", PlayerPrefs.GetInt("LevelsNo") + 1);
            // PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("cashh") + 50);
            DataStore.inst.dts.totalCoins += 50;
            //PlayerPrefs.SetInt("Coin", Random.Range(39, 51));
            DataStore.inst.dts.crrLevel += 1;
            DataStore.inst.SaveDataFn();
            
        }
        else
        {

            int randomIndex = UnityEngine.Random.Range(0, Levels.Length);

            // Set all elements' active property to false first
            for (int i = 0; i < Levels.Length; i++)
            {
                print("hello");
                Levels[i].active = false;
            }

            // Set the active property of the randomly selected element to true
            Levels[randomIndex].active = true;
            //print("hello");
            //Levels[Random.Range(0, 4)].SetActive(true);
            //  PlayerPrefs.SetInt("LevelsNo", Random.Range(0, 5));
            //PlayerPrefs.SetInt("LevelsNo", PlayerPrefs.GetInt("LevelsNo") + 1);
            //PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("cashh") + 10);
            //DataStore.inst.dts.crrLevel += 1;
            DataStore.inst.dts.totalCoins += 50;
            DataStore.inst.SaveDataFn();
        }
        //if (PlayerPrefs.GetInt("Levels") < players.Length - 1)
        //{
        //    PlayerPrefs.SetInt("Levels", PlayerPrefs.GetInt("Levels") + 1);
        //}
        //else
        //{
        //    PlayerPrefs.SetInt("Levels", Random.Range(0, 5));
        //}
        Application.LoadLevel(2);

    }
    public void logout()
    {

        Application.LoadLevel(1);
        Time.timeScale = 1f;
    }
    public void restart()
    {
        //print("restart");
        PlayerPrefs.SetInt("Levels", PlayerPrefs.GetInt("Levels"));
        PlayerPrefs.SetInt("LevelsNo", PlayerPrefs.GetInt("LevelsNo"));
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        //InterstitialAdController.instance.ShowAd();
        Application.LoadLevel(2);
    }
    public void restart1()
    {
        //print("restart");
        PlayerPrefs.SetInt("Levels", PlayerPrefs.GetInt("Levels"));
        PlayerPrefs.SetInt("LevelsNo", PlayerPrefs.GetInt("LevelsNo"));
        DataStore.inst.dts.totalCoins += 10;
        DataStore.inst.SaveDataFn();

        //InterstitialAdController.instance.ShowAd();
        Application.LoadLevel(2);
    }

}
