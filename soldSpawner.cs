using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldSpawner : MonoBehaviour
{
    public GameObject soldObject,point,pointpos;
    public List<GameObject> AllPlayers = new List<GameObject>();
    public List<GameObject> spawnedObjects1 = new List<GameObject>();
    public GameObject[] soldSpawnPos; public RaycastHit hit;
    public bool check, playerboxCheck1;
    public bool one3;
    void Start()
    {
        check = true;
        one3 = true;
        if (check == true)
        {
            Instantiate(point, pointpos.transform.position, point.transform.rotation);
            check = false;
        }
    }

    public void SoldObjectss1()
    {
      
        for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
        {
            if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 2)
            {
                GameObject soldspawns = Instantiate(soldObject, soldSpawnPos[i].transform.position, soldObject.transform.rotation);
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
           
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
                if (hit.collider.CompareTag("Playerpoint"))
                {
                    playerboxCheck1 = true;


                    print("true");
                    // playerStand1 = false;


                }
                if (hit.collider != null && !hit.collider.CompareTag("Cannonpoint") && !hit.collider.CompareTag("jetpoint") && !hit.collider.CompareTag("tankpoint") && !hit.collider.CompareTag("Playerpoint") && !hit.collider.CompareTag("tankpoint") && !hit.collider.CompareTag("carpoint") && playerboxCheck1 == true)
                {
                    if (playerboxCheck1 == true)
                    {

                        //soldSpawner respawn = GameObject.FindObjectOfType<soldSpawner>();
                        for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
                        {
                            if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 2)
                            {
                                StartCoroutine(SpawnAndMoveRe());
                                //respawn.one3 = true;
                                break; // Assuming you want to break out of the loop once the condition is met for one element.
                            }
                        }



                    }


                }
                if (hit.collider != null && (hit.collider.CompareTag("tankpoint") || hit.collider.CompareTag("carpoint") || hit.collider.CompareTag("Cannonpoint") || hit.collider.CompareTag("jetpoint")))
                {
                    playerboxCheck1 = false;
                }
            }
        }
    }
    IEnumerator SpawnAndMoveRe()
    {
        
        yield return new WaitForSeconds(8f);
        one3 = true;
        spawnedObjects1.Clear();
    }
}
