using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Auth;
using Google.MiniJSON;
using UnityEngine.UI;
using UnityEngine.UIElements;

[Serializable]
public class dataToSave1
{
    //public string userName;
    public int totalCoins;
    
     public int crrLevel;
    // public int highScore;//and many more
   
}
public class DataStore : MonoBehaviour
{
    //public dataToSave1 instance;
    public dataToSave1 dts;
    public string userEmail;
    DatabaseReference dbRef;
    public static DataStore inst;
    public Text cash;
    public int cash1;
    public Text level;
    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
       
       // instance.totalCoins = 990;
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
        userEmail = Authmanager.inst.User.Email;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //DataStore.inst.dts.crrLevel;
        //dts.totalCoins = 900;
        //level
        StartCoroutine(LoadDataEnum());
    }

    // Update is called once per frame
    void Update()
    {
        
        cash1 = dts.totalCoins;
        cash.text = dts.totalCoins.ToString();
        level.text = "Level. " + DataStore.inst.dts.crrLevel;
    }
    public void SaveDataFn()
    {
    string json = JsonUtility.ToJson(dts);
    print("yesSaved");
    string userId = userEmail.Replace(".", ",");
    dbRef.Child("users").Child(userId).SetRawJsonValueAsync(json);
    }
    IEnumerator LoadDataEnum()
    {
        string userId = userEmail.Replace(".", ",");
        var serverData = dbRef.Child("users").Child(userId).GetValueAsync();
        yield return new WaitUntil(predicate: () => serverData.IsCompleted);

        print("process is complete");

        DataSnapshot snapshot = serverData.Result;
        string jsonData = snapshot.GetRawJsonValue();

        if (jsonData != null)
        {
            print("server data found");

            dts = JsonUtility.FromJson<dataToSave1>(jsonData);
        }
        else
        {
            print("no data found");
        }

    }
}
