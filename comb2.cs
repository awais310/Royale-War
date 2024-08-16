//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class comb2 : MonoBehaviour
//{
 
//    public spawnmanager targats, targetenemy;
//    public GameObject tar1, tar2, tar3;
//    public bool check;
//    // Start is called before the first frame update
//    void Start()
//    {
//        targats = GameObject.FindObjectOfType<spawnmanager>();

//    }

//    // Update is called once per frame
//    void Update()
//    {
       
//        //tar1 = targats.target1;
//        //tar2 = targats.target2;
//        //tar3 = targats.target3;
//        if (check == true)
//        {
//            targats.target1 = targats.spawnedObject3;
//            targats.target2 = targats.spawnedObject3;
//            targats.target3 = targats.spawnedObject3;
//            //targats.target1 = targats.firstObject;
//            //targats.target2 = targats.secondObject;
//            //targats.target3 = targats.thirdObject;
//            //targats.firstObject = targats.spawnedObject3;
//            //targats.secondObject = targats.spawnedObject3;
//            //targats.thirdObject = targats.spawnedObject3;
//        }

//    }
//    public void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.tag == "enemy")
//        {
//            print("Enemy HIT");
//            check = true;
           

//        }
//    }
//}
