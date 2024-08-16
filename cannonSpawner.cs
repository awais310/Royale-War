using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonSpawner : MonoBehaviour
{
    public GameObject cannonObject,point,pointpos;
    public List<GameObject> AllCannon = new List<GameObject>();
    public List<GameObject> spawnedCannon1 = new List<GameObject>();
    public GameObject[] cannonSpawnPos;
    public bool check;
    public bool one4;
    void Start()
    {
        check = true;
           one4 = true;
        if (check == true)
        {
            Instantiate(point, pointpos.transform.position, point.transform.rotation);
            check = false;
        }
    }

    public void CannonObjectss1()
    {
      
        for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
        {
            if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 3)
            {
                GameObject cannonspawns = Instantiate(cannonObject, cannonSpawnPos[i].transform.position, cannonObject.transform.rotation);
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
            one4 = false;
        }
        //Cannon respawn = GameObject.FindObjectOfType<Cannon>();
        //for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
        //{
        //    if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 3 && respawn.cannonHealth <= 0)
        //    {
        //        one4 = true;
        //        break; // Assuming you want to break out of the loop once the condition is met for one element.
        //    }
        //}
    }
}
