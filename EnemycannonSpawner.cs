using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemycannonSpawner : MonoBehaviour
{
    public GameObject cannonObject,pointpos;
    public List<GameObject> AllCannon = new List<GameObject>();
    public List<GameObject> spawnedCannon1 = new List<GameObject>();
    public GameObject cannonSpawnPos;
    public bool check;
    public bool one4,itCheck;
    void Start()
    {
        
           one4 = true;
       
    }

    public void CannonObjectss1()
    {
      
       // for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
        {
           // if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 3)
            {
                GameObject cannonspawns = Instantiate(cannonObject, cannonSpawnPos.transform.position, cannonObject.transform.rotation);
                AllCannon.Add(cannonspawns);
                spawnedCannon1.Add(cannonspawns);
            }
        }

       
        if (spawnedCannon1.Count == 1)
        {
            // CancelInvoke("TankObjectss1");
            one4 = false;


        }
    }

    private void Update()
    {

        if (one4 == true)
        {

            CannonObjectss1();
            //itCheck = true;
            one4 = false;
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

        yield return new WaitForSeconds(20f);
        itCheck = true;
        if (itCheck == true)
        {
            one4 = true;
            itCheck = false;
            spawnedCannon1.Clear();
        }

    }
}
