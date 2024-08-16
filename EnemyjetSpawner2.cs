using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyjetSpawner2 : MonoBehaviour
{
    public GameObject jetObject/*,point,pointpos*/;
    public List<GameObject> Alljet = new List<GameObject>();
    public List<GameObject> spawnedJet1 = new List<GameObject>();
    //public GameObject[] jetSpawnPos; public RaycastHit hit;
    public GameObject jetSpawnPos;
    //public bool check;
    public bool one5, itCheck, newCheck;
    //public bool check, jetboxCheck1;
    //public bool one5;
    void Start()
    {
       
           one5 = true;
      

        //if (check == true)
        //{
        //    //point.transform.position = new Vector3(point.transform.position.x, 0.183f, point.transform.position.z);
        //    Instantiate(point, pointpos.transform.position, point.transform.rotation);
        //    check = false;
        //}
    }

    public void JetObjectss1()
    {
      
       // for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
        {
            //if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 4)
            {
                GameObject jetspawns = Instantiate(jetObject, jetSpawnPos.transform.position, jetObject.transform.rotation);
               
                Alljet.Add(jetspawns);
                spawnedJet1.Add(jetspawns);
            }
        }

       
        if (spawnedJet1.Count == 1)
        {
            // CancelInvoke("TankObjectss1");
            one5 = false;


        }
    }

    private void Update()
    {

        if (one5 == true)
        {

            JetObjectss1();
            itCheck = true;
            one5 = false;
        }
        
        if (itCheck == true)
        {
            StartCoroutine(SpawnAndMoveRe());
            itCheck = false;
        }
    }
    IEnumerator SpawnAndMoveRe()
    {

        yield return new WaitForSeconds(20f);
        itCheck = true;
        if (itCheck == true)
        {
            one5 = true;
            spawnedJet1.Clear();
            itCheck = false;
        }
    }
}
