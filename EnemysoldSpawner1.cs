using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysoldSpawner1 : MonoBehaviour
{
    public GameObject soldObject/*,point,pointpos*/;
    public List<GameObject> AllPlayers = new List<GameObject>();
    public List<GameObject> spawnedObjects1 = new List<GameObject>();
    public GameObject soldSpawnPos;
    public bool check;
    public bool one3, itCheck, newCheck;
    void Start()
    {
        
        one3 = true;
        //itCheck = true;
        //if (check == true)
        //{
        //    Instantiate(point, pointpos.transform.position, point.transform.rotation);
        //    check = false;
        //}
    }

    public void SoldObjectss1()
    {
      
        //for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
        {
           // if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 2)
            {
                GameObject soldspawns = Instantiate(soldObject, soldSpawnPos.transform.position, soldObject.transform.rotation);
                AllPlayers.Add(soldspawns);
                spawnedObjects1.Add(soldspawns);
            }
        }

       
        if (spawnedObjects1.Count == 3)
        {
            // CancelInvoke("TankObjectss1");
            one3 = false;


        }
    }

    private void Update()
    {

        if (one3 == true)
        {

            SoldObjectss1();
            itCheck = true;
            if(spawnedObjects1.Count == 3)
            {
                one3 = false;
            }
            
        }
        //if (newCheck == true)
        //{
        //    StartCoroutine(SpawnAndMoveRe());
        //    newCheck = false;
        //}
        //else
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

        yield return new WaitForSeconds(17f);
        itCheck = true;
        if (itCheck == true)
        {
            one3 = true;
            if (spawnedObjects1.Count == 3)
            {
                one3 = false;
                spawnedObjects1.Clear();



                AllPlayers.Clear();
                
            }
        }

    }
}
