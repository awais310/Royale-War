//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;
//using Firebase.Database;
//using Firebase.Auth;
//using UnityEngine.PlayerLoop;

//[Serializable]
//public class dataToSave
//{
//    //public string userName;
//    public int totalCoins;
//    public int crrLevel;
//   // public int highScore;//and many more

//}
//public class DataSaver : MonoBehaviour
//{
//    public dataToSave dts;
//    public string userEmail;
//    DatabaseReference dbRef;
//    //public FirebaseUser User;
//    private void Awake()
//    {
//        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
//    }

//    //public void SaveDataFn()
//    //{
//    //    string json = JsonUtility.ToJson(dts);
//    //    print("yesSaved");
//    //    string userId = userEmail.Replace(".", ",");
//    //    dbRef.Child("users").Child(userId).SetRawJsonValueAsync(json);
//    //}

//    public void LoadDataFn()
//    {
//        StartCoroutine(LoadDataEnum());
//    }
//    //public void FixedUpdate()
//    //{
//    //    userEmail
//    //}
//    IEnumerator LoadDataEnum()
//    {
//        string userId = userEmail.Replace(".", ",");
//        var serverData = dbRef.Child("users").Child(userId).GetValueAsync();
//        yield return new WaitUntil(predicate: () => serverData.IsCompleted);

//        print("process is complete");

//        DataSnapshot snapshot = serverData.Result;
//        string jsonData = snapshot.GetRawJsonValue();

//        if (jsonData != null)
//        {
//            print("server data found");

//            dts = JsonUtility.FromJson<dataToSave>(jsonData);
//        }
//        else
//        {
//            print("no data found");
//        }

//    }
//}