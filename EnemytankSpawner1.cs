using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemytankSpawner1 : MonoBehaviour
{
    public GameObject tankObject/*,point,pointpos*/;
    public List<GameObject> AllTank = new List<GameObject>();
    public List<GameObject> spawnedTank1 = new List<GameObject>();
    //public List<GameObject> spawnedTank2 = new List<GameObject>();
    //public List<GameObject> spawnedTank3 = new List<GameObject>();
    public GameObject tankSpawnPos;
    //public bool check;
    public bool one1, itCheck, newCheck;
    void Start()
    {
        //check = true;
           one1 = true;
        //if (check == true)
        //{
        //    Instantiate(point, pointpos.transform.position, point.transform.rotation);
        //    check = false;
        //}
    }

    public void TankObjectss1()
    {
      
        //for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
        {
            //if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 0)
            {
                GameObject tankspawns = Instantiate(tankObject, tankSpawnPos.transform.position, tankObject.transform.rotation);
                AllTank.Add(tankspawns);
                spawnedTank1.Add(tankspawns);
            }
        }

       
        if (spawnedTank1.Count == 1)
        {
            // CancelInvoke("TankObjectss1");
            one1 = false;


        }
        {
            
            //  StartCoroutine(SpawnAndMoveRe1());
        }
    }

    private void Update()
    {

        if (one1 == true)
        {

            TankObjectss1();
            itCheck = true;
            one1 = false;
        }
        if (itCheck == true)
        {
            StartCoroutine(SpawnAndMoveRe1());
            itCheck = false;
        }
    }
    IEnumerator SpawnAndMoveRe1()
    {
        // EnemycarSpawner2 respawn = GameObject.FindObjectOfType<EnemycarSpawner2>();

        yield return new WaitForSeconds(18f);
        itCheck = true;
        if (itCheck == true)
        {
            one1 = true;
            spawnedTank1.Clear();
            itCheck = false;
        }

    }
}
