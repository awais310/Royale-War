using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerSelector : MonoBehaviour
{
    public static playerSelector inst;
    public GameObject[] Lock,black, selected,orignal, Fac1Select;
    public int[] price;
    public GameObject[] player;
    public GameObject[] changeboxes;
    public GameObject[] allitems,facSpawnPos,pointSpawnpos;
    public List<GameObject> AllPlayers = new List<GameObject>();
    public List<Transform> playerFactTran = new List<Transform>();
    public List<GameObject> spawnedFactorys = new List<GameObject>();
    public List<Transform> CloneplayerFactTran = new List<Transform>();
    public List<GameObject> ClonespawnedFactorys = new List<GameObject>();
    public List<Vector3> CloneplayerFactTrans = new List<Vector3>();
    //public Text /*cash,*/ level;
    public Text[] pricetext;
    public GameObject[] images1, images2, images3;
    public int itemNo1, itemNo2, saveitem1, saveitem2,newv1,newv2, newv3, saveitem3, itemNo3;
    public int one, two, three;
    public int Selectbox1, Selectbox2, Selectbox3, checckZero, checckOne, checckTwo;
    public GameObject spawnmang, gamemang, startbtn, panl,mainpanl, tankfac, tankpoint,Clones,restartbtn;
    public int plusCount, _itemsave1, _itemsave2, _itemsave3, cash;
    public bool save1, save2, save3, checktank;
    public GameObject[] Factory;
    public bool allFilled;
    public string userEmail;
    //public dataToSave1 dts;
    //public dataToSave dts;
    //DatabaseReference dbRef;
    //public FirebaseUser User;


    // Start is called before the first frame update
    private void Awake()
    {
        //cash = DataStore.inst.cash1;
        if (inst == null)
        {
            inst = this;
        }
        //dbRef = FirebaseDatabase.DefaultInstance.RootReference;
        
    }
    private void Start()
    {

        userEmail = Authmanager.inst.User.Email;
        checckZero = -1;
           itemNo1 = -1;
        save1 = true;
        save2 = true;
        save3 = true;
        checktank = true;
        pointSpawnpos[1].transform.position = new Vector3(0.062f, 0.182f, -2.147f);
        panl.SetActive(true);
        mainpanl.SetActive(true);
        spawnmang.SetActive(false);
        gamemang.SetActive(false);
        startbtn.SetActive(false);
        restartbtn.SetActive(false) ;
        allFilled = true;
        //if (!PlayerPrefs.HasKey("LevelsNo"))
        //{
        //    PlayerPrefs.SetInt("LevelsNo", 1);
        //}

        //if (!PlayerPrefs.HasKey("cashh"))
        //{
        //    PlayerPrefs.SetInt("cashh", 1000);
        //}


        //if (!PlayerPrefs.HasKey("CurrentPlayer"))
        //{
        //    PlayerPrefs.SetInt("CurrentPlayer", 0);
        //}
        if (!PlayerPrefs.HasKey("Player"))
        {
            PlayerPrefs.SetInt("Player", 0);
        }
        for (int i = 0; i < pricetext.Length; i++)
        {
            pricetext[i].text = price[i].ToString();
        }
        for (int i = 0; i < Lock.Length; i++)
        {
            if (!PlayerPrefs.HasKey(/*"Player" +*/ i + "IsPurchase"))
            {
                PlayerPrefs.SetInt(/*"Player" +*/ i + "IsPurchase", 0);
                if (i == 0)
                {
                    PlayerPrefs.SetInt(/*"Player" +*/ i + "IsPurchase", 1);
                }
            }
            if (PlayerPrefs.GetInt(/*"Player" +*/ i + "IsPurchase") == 1)
            {
                Lock[i].SetActive(false);
                pricetext[i].transform.parent.gameObject.SetActive(false);
            }
        }
        //selected[PlayerPrefs.GetInt("CurrentPlayer")].SetActive(true);
        // player[PlayerPrefs.GetInt("Player")].SetActive(true);
        Fac1Select[0].SetActive(true);
    }


    

    // Update is called once per frame
    private void Update()
    {
        cash = DataStore.inst.cash1;
        //cash.text = PlayerPrefs.GetInt("cashh").ToString();
        //level.text = "Level. " + PlayerPrefs.GetInt("LevelsNo");
        //level.text = "Level. " + DataStore.inst.dts.crrLevel;
        //if (i == 2)
        //{
        //    startbtn.SetActive(true);
        //}
        //else
        //{
        //    startbtn.SetActive(false);
        //}
        for (int i = 0; i < selectedweapon.Length; i++)
        {
            if (selectedweapon[i].GetComponent<upGridImg>().isfilled == false)
            {
                allFilled = false;
                break; // Exit the loop as soon as one element is found not filled
            }
            else
            {
                allFilled = true;
            }
        }
        if (allFilled == false)
        {
            startbtn.SetActive(false);
        }
        else if (allFilled == true)
        {
            startbtn.SetActive(true);
        }
    }
    public void purchaseItem(int item)
    {

        plusCount++;
        print("out");
        if (PlayerPrefs.GetInt(/*"Player" +*/ item + "IsPurchase") == 0)
        {

            if (price[item] <= cash /*PlayerPrefs.GetInt("cashh")*/)
            {
                print("in");
                PlayerPrefs.SetInt(/*"Player" +*/ item + "IsPurchase", 1);
                //PlayerPrefs.SetInt("CurrentPlayer", item);
                // PlayerPrefs.SetInt("cashh", PlayerPrefs.GetInt("cashh") - price[item]);
                DataStore.inst.dts.totalCoins -= price[item];
                print("CMinus");
               // selected[PlayerPrefs.GetInt("CurrentPlayer")].SetActive(true);
                //player[PlayerPrefs.GetInt("Player")].SetActive(true);
                Lock[item].SetActive(false);
                pricetext[item].transform.parent.gameObject.SetActive(false);

                for (int i = 0; i < selected.Length; i++)
                {
                    if (price[item] <= cash /*PlayerPrefs.GetInt("cashh")*/)
                    {
                        if (i == item)
                        {
                            if(saveitem1 == 1)
                            {
                                newv1 = i;
                            }
                            if (saveitem1 == 2)
                            {
                                newv1 = i;
                            }
                            if (saveitem1 == 3)
                            {
                                newv1 = i;
                            }
                            // newv2 = i;
                            // images1[item].SetActive(true);
                           // selected[i].SetActive(true);
                           
                            //player[i].SetActive(true);
                        }
                        else
                        {
                            //images1[item].SetActive(false);
                            //selected[i].SetActive(false);
                           // player[i].SetActive(false);
                        }
                       
                    }
                    ////if (saveitem1 == 0)
                    //{
                    //    print("item1");
                    //    Firstbox(i);
                    //}
                }
               

            }

        }
        else
        {

            PlayerPrefs.SetInt("CurrentSword", item);
            // PlayerPrefs.SetInt("Player", item); public GameObject[] images; public GameObject[] images;
            for (int i = 0; i < selected.Length; i++)
            {
                 if (price[item] <= cash/*PlayerPrefs.GetInt("cashh")*/)
                {
                    if (i == item)
                    {
                        selected[i].SetActive(true);
                       
                        // player[i].SetActive(true);
                    }
                    else
                    {
                        selected[i].SetActive(false);
                        //images[i].SetActive(false);
                        // player[i].SetActive(false);
                    }
                }

            }
            selected[PlayerPrefs.GetInt("CurrentSword")].SetActive(true);
            // player[PlayerPrefs.GetInt("Player")].SetActive(true);

        }
        //if( (item == 0 || item == 1 || item == 2) && Selectbox1 == 0)
        //{
        //    itemNo1 = item;
        //    Firstbox(itemNo1);
        //    Selectbox2 = 1;
        //    Selectbox1 = 1;
        //    //changeboxes[0]++;
        //}
        //if ((item == 0 || item == 1 || item == 2) && Selectbox2 == 1)
        //{
        //    itemNo1 = item;
        //    Secondbox(itemNo1);
        //    Selectbox3 = 2;
        //    Selectbox2 = 0;
        //}
        //if ((item == 0 || item == 1 || item == 2) && Selectbox3 == 2)
        //{
        //    itemNo1 = item;
        //    Thirdbox(itemNo1);
        //    Selectbox3 = 1;
        //}
        //if (plusCount == 3)
        //{
        //    itemNo1 = item;
        //    Thirdbox(itemNo1);
        //}
    //    if (saveitem1 == 1 && price[item] <= PlayerPrefs.GetInt("cashh"))
    //    {
    //        if(saveitem1 == 1 && save1 == true)
    //        {
    //            _itemsave1 = saveitem1;
    //            save1 = false;
    //        }
    //        itemNo1 = item;
    //       // print("item1");
    //        Firstbox(itemNo1);
    //        //Fac1Select[0].SetActive(true);
    //        if(itemNo1 == 0)
    //        {
    //            if(itemNo1 == 0)
    //            {
    //                checckZero = itemNo1;
    //            }
    //            black[0].SetActive(true);
    //           // selected[0].SetActive(false);
    //            //Fac1Select[0].SetActive(true);
    //            //Fac1Select[1].SetActive(false);
    //            //Fac1Select[2].SetActive(false);
    //            allitems[0].GetComponent<Button>().enabled = false;
    //            Lock[0].GetComponent<Button>().enabled = false;
    //            changeboxes[0].GetComponent<Button>().enabled = false;
    //            images1[0].GetComponent<Button>().enabled = false;
    //            images1[1].GetComponent<Button>().enabled = false;
    //            images1[2].GetComponent<Button>().enabled = false;
    //            itemNo1 = -1;
    //        }
    //        if (itemNo1 == 1)
    //        {
    //            if (itemNo1 == 1)
    //            {
    //                checckOne = itemNo1;
    //            }
    //            black[1].SetActive(true);
    //            selected[0].SetActive(false);
    //            allitems[1].GetComponent<Button>().enabled = false;
    //            Lock[1].GetComponent<Button>().enabled = false;
    //            changeboxes[0].GetComponent<Button>().enabled = false;
    //            images1[0].GetComponent<Button>().enabled = false;
    //            images1[1].GetComponent<Button>().enabled = false;
    //            images1[2].GetComponent<Button>().enabled = false;
    //            itemNo1 = -1;
    //        }
    //        if (itemNo1 == 2)
    //        {
    //            if (itemNo1 == 2)
    //            {
    //                checckTwo = itemNo1;
    //            }
    //            black[2].SetActive(true);
    //            selected[0].SetActive(false);
    //            allitems[2].GetComponent<Button>().enabled = false;
    //            Lock[2].GetComponent<Button>().enabled = false;
    //            changeboxes[0].GetComponent<Button>().enabled = false;
    //            images1[0].GetComponent<Button>().enabled = false;
    //            images1[1].GetComponent<Button>().enabled = false;
    //            images1[2].GetComponent<Button>().enabled = false;
    //            itemNo1 = -1;
    //        }
    //        //itemNo1 = -1;


    //    }
    //    if (saveitem1 == 2 && price[item] <= PlayerPrefs.GetInt("cashh"))
    //    {
    //        if (saveitem1 == 2 && save2 == true)
    //        {
    //            _itemsave2 = saveitem1;
    //            save2 = false;
    //        }
    //        itemNo1 = item;
    //       // print("item1");
    //        Secondbox(itemNo1);
    //        //Fac1Select[0].SetActive(true);
    //        if (itemNo1 == 0)
    //        {
    //            if (itemNo1 == 0)
    //            {
    //                checckZero = itemNo1;
    //            }
    //            selected[1].SetActive(false);
    //            black[0].SetActive(true);
    //            //Fac1Select[0].SetActive(true);
    //            //Fac1Select[1].SetActive(false);
    //            //Fac1Select[2].SetActive(false);
    //            allitems[0].GetComponent<Button>().enabled = false;
    //            Lock[0].GetComponent<Button>().enabled = false;
    //            changeboxes[1].GetComponent<Button>().enabled = false;
    //            images2[0].GetComponent<Button>().enabled = false;
    //            images2[1].GetComponent<Button>().enabled = false;
    //            images2[2].GetComponent<Button>().enabled = false;
    //            itemNo1 = -1;
    //        }
    //        if (itemNo1 == 1)
    //        {
    //            if (itemNo1 == 1)
    //            {
    //                checckOne = itemNo1;
    //            }
    //            selected[1].SetActive(false);
    //            black[1].SetActive(true);
    //            allitems[1].GetComponent<Button>().enabled = false;
    //            Lock[1].GetComponent<Button>().enabled = false;
    //            changeboxes[1].GetComponent<Button>().enabled = false;
    //            images2[0].GetComponent<Button>().enabled = false;
    //            images2[1].GetComponent<Button>().enabled = false;
    //            images2[2].GetComponent<Button>().enabled = false;
    //            itemNo1 = -1;
    //        }
    //        if (itemNo1 == 2)
    //        {
    //            if (itemNo1 == 2)
    //            {
    //                checckTwo = itemNo1;
    //            }
    //            selected[1].SetActive(false);
    //            black[2].SetActive(true);
    //            allitems[2].GetComponent<Button>().enabled = false;
    //            Lock[2].GetComponent<Button>().enabled = false;
    //            changeboxes[1].GetComponent<Button>().enabled = false;
    //            images2[0].GetComponent<Button>().enabled = false;
    //            images2[1].GetComponent<Button>().enabled = false;
    //            images2[2].GetComponent<Button>().enabled = false;
    //            itemNo1 = -1;
    //        }
    //        //itemNo1 = -1;
    //    }
    //    if (saveitem1 == 3 && price[item] <= PlayerPrefs.GetInt("cashh"))
    //    {
    //        if (saveitem1 == 3 && save3 == true)
    //        {
    //            _itemsave3 = saveitem1;
    //            save3 = false;
    //        }
    //        itemNo1 = item;
    //       // print("item1");
    //        Thirdbox(itemNo1);
    //        //Fac1Select[0].SetActive(true);
    //        if (itemNo1 == 0)
    //        {
    //            if (itemNo1 == 0)
    //            {
    //                checckZero = itemNo1;
    //            }
    //            black[0].SetActive(true);
    //            selected[2].SetActive(false);
    //            //Fac1Select[0].SetActive(true);
    //            //Fac1Select[1].SetActive(false);
    //            //Fac1Select[2].SetActive(false);
    //            allitems[0].GetComponent<Button>().enabled = false;
    //            Lock[0].GetComponent<Button>().enabled = false;
    //            changeboxes[2].GetComponent<Button>().enabled = false;
    //            images3[0].GetComponent<Button>().enabled = false;
    //            images3[1].GetComponent<Button>().enabled = false;
    //            images3[2].GetComponent<Button>().enabled = false;
    //            itemNo1 = -1;
    //        }
    //        if (itemNo1 == 1)
    //        {
    //            if (itemNo1 == 1)
    //            {
    //                checckOne = itemNo1;
    //            }
    //            selected[2].SetActive(false);
    //            black[1].SetActive(true);
    //            allitems[1].GetComponent<Button>().enabled = false;
    //            Lock[1].GetComponent<Button>().enabled = false;
    //            changeboxes[2].GetComponent<Button>().enabled = false;
    //            images3[0].GetComponent<Button>().enabled = false;
    //            images3[1].GetComponent<Button>().enabled = false;
    //            images3[2].GetComponent<Button>().enabled = false;
    //            itemNo1 = -1;
    //        }
    //        if (itemNo1 == 2)
    //        {
    //            if (itemNo1 == 2)
    //            {
    //                checckTwo = itemNo1;
    //            }
    //            selected[2].SetActive(false);
    //            black[2].SetActive(true);
    //            allitems[2].GetComponent<Button>().enabled = false;
    //            Lock[2].GetComponent<Button>().enabled = false;
    //            changeboxes[2].GetComponent<Button>().enabled = false;
    //            images3[0].GetComponent<Button>().enabled = false;
    //            images3[1].GetComponent<Button>().enabled = false;
    //            images3[2].GetComponent<Button>().enabled = false;
    //            itemNo1 = -1;
    //        }
           
    //    }
    //    //if (saveitem1 == 2 && price[item] <= PlayerPrefs.GetInt("cashh"))
    //    //{
    //    //    // print("itemno2");
    //    //    itemNo1 = item;
    //    //    Secondbox(itemNo1);
    //    //    Lock[1].SetActive(true);
    //    //    Fac1Select[1].SetActive(true);
    //    //    Fac1Select[0].SetActive(false);
    //    //    Fac1Select[2].SetActive(false);
    //    //    allitems[1].GetComponent<Button>().enabled = false;
    //    //    Lock[1].GetComponent<Button>().enabled = false;
    //    //}
    //    //if (saveitem1 == 3 && price[item] <= PlayerPrefs.GetInt("cashh"))
    //    //{
    //    //    // print("itemno3");
    //    //    itemNo1 = item;
    //    //    Thirdbox(itemNo1);
    //    //    Lock[2].SetActive(true);
    //    //    Fac1Select[2].SetActive(true);
    //    //    Fac1Select[0].SetActive(false);
    //    //    Fac1Select[1].SetActive(false);
    //    //    allitems[2].GetComponent<Button>().enabled = false;
    //    //    Lock[2].GetComponent<Button>().enabled = false;
    //    //}
    //}
    //public void Firstbox(int itemFirst)
    //{
    //    Selectbox1 = itemFirst;
    //    //if (plusCount == 1)
    //    //{
    //    //    saveitem1 = itemFirst;
    //    //    itemFirst = itemNo1;

    //    //}
    //    if (itemFirst == 1)
    //    {
    //        saveitem1 = itemFirst;
    //        itemFirst = itemNo1;

    //    }


    //    if (PlayerPrefs.GetInt(/*"Player" +*/ /*item +*/ "IsPurchase") == 0)
    //    {

    //       // if (price[item] <= PlayerPrefs.GetInt("cashh"))
    //        {
              
    //           // PlayerPrefs.SetInt(/*"Player" +*/ item + "IsPurchase", 1);
    //           // PlayerPrefs.SetInt("CurrentPlayer", item);
    //           // PlayerPrefs.SetInt("cashh", PlayerPrefs.GetInt("cashh") - price[item]);
    //            //selected[PlayerPrefs.GetInt("CurrentPlayer")].SetActive(true);
    //            //player[PlayerPrefs.GetInt("Player")].SetActive(true);
    //           // Lock[item].SetActive(false);
    //           // pricetext[item].transform.parent.gameObject.SetActive(false);

    //            for (int i = 0; i < selected.Length; i++)
    //            {
    //               // item = i;
    //                //if (price[item] <= PlayerPrefs.GetInt("cashh"))
    //                {
                        
    //                    if (i == itemFirst && saveitem1 == 1)
    //                    {
    //                        images1[i].SetActive(true);
    //                        //Fac1Select[0].SetActive(true);
    //                    }
    //                    else
    //                    {
    //                        images1[i].SetActive(false);
    //                        //Fac1Select[0].SetActive(false);
    //                    }
    //                }

    //            }
               
    //            {
                    
    //            }


    //        }

    //    }
    //    else
    //    {

    //       // PlayerPrefs.SetInt("CurrentSword", item);
    //        // PlayerPrefs.SetInt("Player", item); public GameObject[] images; public GameObject[] images;
    //        for (int i = 0; i < selected.Length; i++)
    //        {
    //            //item = i;
    //           // if (price[item] <= PlayerPrefs.GetInt("cashh"))
    //            {
    //                //if (i == i)
    //                //{
    //                //    selected[i].SetActive(true);
    //                //    images1[i].SetActive(true);
    //                //    // player[i].SetActive(true);
    //                //}
    //                //else
    //                //{
    //                //    selected[i].SetActive(false);
    //                //    images1[i].SetActive(false);
    //                //    // player[i].SetActive(false);
    //                //}
    //            }

    //        }
    //        selected[PlayerPrefs.GetInt("CurrentSword")].SetActive(true);
    //        // player[PlayerPrefs.GetInt("Player")].SetActive(true);

    //    }
        
    //}
    //public void Secondbox(int itemSecond)
    //{
    //    Selectbox2 = itemSecond;
    //    //if (plusCount == 2)
    //    //{

    //    //    saveitem1 = itemSecond;
    //    //    itemSecond = itemNo1;

    //    //}
    //    if (itemSecond == 2)
    //    {

    //        saveitem1 = itemSecond;
    //        itemSecond = itemNo1;

    //    }


    //    if (PlayerPrefs.GetInt(/*"Player" +*/ /*item +*/ "IsPurchase") == 0)
    //    {

    //        // if (price[item] <= PlayerPrefs.GetInt("cashh"))
    //        {

    //            // PlayerPrefs.SetInt(/*"Player" +*/ item + "IsPurchase", 1);
    //            // PlayerPrefs.SetInt("CurrentPlayer", item);
    //            // PlayerPrefs.SetInt("cashh", PlayerPrefs.GetInt("cashh") - price[item]);
    //            //selected[PlayerPrefs.GetInt("CurrentPlayer")].SetActive(true);
    //            //player[PlayerPrefs.GetInt("Player")].SetActive(true);
    //            // Lock[item].SetActive(false);
    //            // pricetext[item].transform.parent.gameObject.SetActive(false);

    //            for (int i = 0; i < selected.Length; i++)
    //            {
    //                // item = i;
    //                //if (price[item] <= PlayerPrefs.GetInt("cashh"))
    //                {

    //                    if (i == itemSecond && saveitem1 == 2)
    //                    {
    //                        images2[i].SetActive(true);
    //                        //[1].SetActive(true);
    //                    }
    //                    else
    //                    {
    //                        images2[i].SetActive(false);
    //                        //Fac1Select[1].SetActive(false);
    //                    }
    //                }

    //            }

    //            {

    //            }


    //        }

    //    }
    //    else
    //    {

    //        // PlayerPrefs.SetInt("CurrentSword", item);
    //        // PlayerPrefs.SetInt("Player", item); public GameObject[] images; public GameObject[] images;
    //        for (int i = 0; i < selected.Length; i++)
    //        {
    //            //item = i;
    //            // if (price[item] <= PlayerPrefs.GetInt("cashh"))
    //            {
    //                //if (i == i)
    //                //{
    //                //    selected[i].SetActive(true);
    //                //    images1[i].SetActive(true);
    //                //    // player[i].SetActive(true);
    //                //}
    //                //else
    //                //{
    //                //    selected[i].SetActive(false);
    //                //    images1[i].SetActive(false);
    //                //    // player[i].SetActive(false);
    //                //}
    //            }

    //        }
    //        selected[PlayerPrefs.GetInt("CurrentSword")].SetActive(true);
    //        // player[PlayerPrefs.GetInt("Player")].SetActive(true);

    //    }
    //}
    //public void Thirdbox(int itemThird)
    //{
    //    Selectbox3 = itemThird;
    //    //if (plusCount == 3)
    //    //{
    //    //    saveitem1 = itemThird;
    //    //    itemThird = itemNo1;

    //    //}
    //    if (itemThird == 3)
    //    {
    //        saveitem1 = itemThird;
    //        itemThird = itemNo1;

    //    }


    //    if (PlayerPrefs.GetInt(/*"Player" +*/ /*item +*/ "IsPurchase") == 0)
    //    {

    //        // if (price[item] <= PlayerPrefs.GetInt("cashh"))
    //        {

    //            // PlayerPrefs.SetInt(/*"Player" +*/ item + "IsPurchase", 1);
    //            // PlayerPrefs.SetInt("CurrentPlayer", item);
    //            // PlayerPrefs.SetInt("cashh", PlayerPrefs.GetInt("cashh") - price[item]);
    //            //selected[PlayerPrefs.GetInt("CurrentPlayer")].SetActive(true);
    //            //player[PlayerPrefs.GetInt("Player")].SetActive(true);
    //            // Lock[item].SetActive(false);
    //            // pricetext[item].transform.parent.gameObject.SetActive(false);

    //            for (int i = 0; i < selected.Length; i++)
    //            {
    //                // item = i;
    //                //if (price[item] <= PlayerPrefs.GetInt("cashh"))
    //                {

    //                    if (i == itemThird && saveitem1 == 3)
    //                    {
    //                        images3[i].SetActive(true);
    //                       // Fac1Select[2].SetActive(true);
    //                    }
    //                    else
    //                    {
    //                        images3[i].SetActive(false);
    //                       // Fac1Select[2].SetActive(false);
    //                    }
    //                }

    //            }

    //            {

    //            }


    //        }

    //    }
    //    else
    //    {

    //        // PlayerPrefs.SetInt("CurrentSword", item);
    //        // PlayerPrefs.SetInt("Player", item); public GameObject[] images; public GameObject[] images;
    //        for (int i = 0; i < selected.Length; i++)
    //        {
    //            //item = i;
    //            // if (price[item] <= PlayerPrefs.GetInt("cashh"))
    //            {
    //                //if (i == i)
    //                //{
    //                //    selected[i].SetActive(true);
    //                //    images1[i].SetActive(true);
    //                //    // player[i].SetActive(true);
    //                //}
    //                //else
    //                //{
    //                //    selected[i].SetActive(false);
    //                //    images1[i].SetActive(false);
    //                //    // player[i].SetActive(false);
    //                //}
    //            }

    //        }
    //        selected[PlayerPrefs.GetInt("CurrentSword")].SetActive(true);
    //        // player[PlayerPrefs.GetInt("Player")].SetActive(true);

    //    }
    }
    public void Startbutton()
    {

        panl.SetActive(false);
        mainpanl.SetActive(false);
        spawnmang.SetActive(true);
        gamemang.SetActive(true);
        allFilled = false;
        startbtn.SetActive(false);
       restartbtn.SetActive(true) ;
        for(int i = 0; i< facSpawnPos.Length; i++)
        {

           GameObject Cloness= Instantiate(Factory[selectedweapon[i].GetComponent<upGridImg>().currentIndex], facSpawnPos[i].transform.position,
                allitems[selectedweapon[i].GetComponent<upGridImg>().currentIndex].transform.rotation);
            spawnedFactorys.Add(Factory[selectedweapon[i].GetComponent<upGridImg>().currentIndex]);
            playerFactTran.Add(Factory[selectedweapon[i].GetComponent<upGridImg>().currentIndex].transform);
            CloneplayerFactTran.Add(Cloness.transform);
            CloneplayerFactTrans.Add(Cloness.transform.position);
            ClonespawnedFactorys.Add(Cloness);

        }
        selectedweapon[i].GetComponent<upGridImg>().isfilled = false;

    }
    public Image[] selectedweapon;
    public int i;
    public void selectweapon(int _index)
    {
        //print("yes in tank");
        for (i=0;i< selectedweapon.Length; i++)
        {
            if (AudioManager.instance)
            {
                AudioManager.instance.Play("Click");
            }
            //Iindex = i;
            if (selectedweapon[i].GetComponent<upGridImg>().isfilled == false)
            {
               
                selectedweapon[i].GetComponent<upGridImg>().currentIndex = _index;
                selectedweapon[i].sprite=allitems[_index].GetComponent<Image>().sprite;
                allitems[_index].GetComponent<Button>().interactable = false;
                selectedweapon[i].GetComponent<upGridImg>().isfilled = true;
                DataStore.inst.SaveDataFn();
                    break;
            }
           

        }
    }
    public void selectweaponOn(int _index)
    {
            allitems[_index].GetComponent<Button>().interactable = true;
     
    }
    //public void spawnFact()
    //{
    //    //sprint("yes in tank");
    //    for (i = 0; i < selectedweapon.Length; i++)
    //    {
    //       if( selectedweapon[0].GetComponent<upGridImg>().currentIndex == 0 && checktank == true)
    //        {
    //            /*GameObject tankspawns =*/
    //            Instantiate(tankfac, tankfac.transform.position, tankfac.transform.rotation);
    //            checktank = false;
    //        }
    //    }

    //}
} 
