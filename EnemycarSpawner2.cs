using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemycarSpawner2 : MonoBehaviour
{
    public GameObject carObject/*,point,pointpos*/;
    public List<GameObject> spawnedCar1 = new List<GameObject>();
    public List<GameObject> AllCar = new List<GameObject>();
    public GameObject carSpawnPos;
    //public bool check1;
    public bool one2,itCheck,newCheck;
    void Start()
    {
       // check1 = true;
           one2 = true;
        //itCheck = true;
        //if (check1 == true)
        //{
        //    Instantiate(point, pointpos.transform.position, point.transform.rotation);
        //    check1 = false;
        //}
    }

    public void CarObjectss1()
    {
      
       // for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
        {
            //if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 1)
            {
                GameObject carspawns = Instantiate(carObject, carSpawnPos.transform.position, carObject.transform.rotation);
                AllCar.Add(carspawns);
                spawnedCar1.Add(carspawns);
            }
        }

       
        if (spawnedCar1.Count == 1)
        {
            // CancelInvoke("TankObjectss1");
            one2 = false;


        }
    }

    private void Update()
    {

        if (one2 == true)
        {

            CarObjectss1();
            itCheck = true;
            one2 = false;
        }
        //if (newCheck == true)
        //{
        //    StartCoroutine(SpawnAndMoveRe());
        //    newCheck = false;
        //}
        
        {
            if (itCheck == true)
            {
                StartCoroutine(SpawnAndMoveRe1());
                itCheck = false;
            }
            //  StartCoroutine(SpawnAndMoveRe1());
        }
    }
  
    IEnumerator SpawnAndMoveRe1()
    {
       // EnemycarSpawner2 respawn = GameObject.FindObjectOfType<EnemycarSpawner2>();

        yield return new WaitForSeconds(20f);
        itCheck = true;
        if (itCheck == true)
        {
            one2 = true;
            itCheck = false;
            spawnedCar1.Clear();
        }

    }
}
