using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankSpawner : MonoBehaviour
{
    public GameObject tankObject,point,pointpos;
    public List<GameObject> AllTank = new List<GameObject>();
    public List<GameObject> spawnedTank1 = new List<GameObject>();
    public List<GameObject> spawnedTank2 = new List<GameObject>();
    public List<GameObject> spawnedTank3 = new List<GameObject>();
    public GameObject[] tankSpawnPos;
    public tank _Tank; public RaycastHit hit;
    public bool check,TSpawn, itCheck, tankboxCheck1;
    public bool one1;
    void Start()
    {
        check = true;
           one1 = true;
        if (check == true)
        {
            Instantiate(point, pointpos.transform.position, point.transform.rotation);
            check = false;
        }
        itCheck = true;
    }

    public void TankObjectss1()
    {
      
        for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
        {
            if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 0)
            {
                GameObject tankspawns = Instantiate(tankObject, tankSpawnPos[i].transform.position, tankObject.transform.rotation);
                AllTank.Add(tankspawns);
                spawnedTank1.Add(tankspawns);
            }
        }

       
        if (spawnedTank1.Count == 1)
        {
            // CancelInvoke("TankObjectss1");
            one1 = false;


        }
    }

    private void Update()
    {

        if (one1 == true)
        {

            TankObjectss1();
            one1 = false;
        }



        //if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
                if (hit.collider.CompareTag("tankpoint"))
                {
                    tankboxCheck1 = true;


                    print("true");
                    // playerStand1 = false;


                }
                if (hit.collider != null && !hit.collider.CompareTag("Cannonpoint") && !hit.collider.CompareTag("jetpoint") && !hit.collider.CompareTag("tankpoint") && !hit.collider.CompareTag("Playerpoint") && !hit.collider.CompareTag("tankpoint") && !hit.collider.CompareTag("carpoint") && tankboxCheck1 == true)
                {
                    if (tankboxCheck1 == true)
                    {
                        //  TSpawner = true;
                        //tankSpawner respawn = GameObject.FindObjectOfType<tankSpawner>();
                        for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
                        {
                            if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 0)
                            {
                                StartCoroutine(SpawnAndMoveRe());
                                // respawn.one1 = true;
                                break; // Assuming you want to break out of the loop once the condition is met for one element.
                            }
                        }



                    }


                }
                if (hit.collider != null && (hit.collider.CompareTag("Playerpoint") || hit.collider.CompareTag("carpoint") || hit.collider.CompareTag("jetpoint") || hit.collider.CompareTag("Cannonpoint")))
                {
                    tankboxCheck1 = false;
                }
            }
        }
    }
    IEnumerator SpawnAndMoveRe()
    {
       // tankSpawner respawn = GameObject.FindObjectOfType<tankSpawner>();
        yield return new WaitForSeconds(8f);
       
        //if (itCheck == true)
        {
            one1 = true;
            spawnedTank1.Clear();
        }
        //one1 = true;
    }
}
