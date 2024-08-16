using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jetSpawner1 : MonoBehaviour
{
    public GameObject jetObject,point,pointpos;
    public List<GameObject> Alljet = new List<GameObject>();
    public List<GameObject> spawnedJet1 = new List<GameObject>();
    public GameObject[] jetSpawnPos; public RaycastHit hit;
    public bool check, jetboxCheck1;
    public bool one5;
    void Start()
    {
        check = true;
           one5 = true;
      

        if (check == true)
        {
            //point.transform.position = new Vector3(point.transform.position.x, 0.183f, point.transform.position.z);
            Instantiate(point, pointpos.transform.position, point.transform.rotation);
            check = false;
        }
    }

    public void JetObjectss1()
    {
      
        for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
        {
            if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 4)
            {
                GameObject jetspawns = Instantiate(jetObject, jetSpawnPos[i].transform.position, jetObject.transform.rotation);
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
            one5 = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
                if (hit.collider.CompareTag("jetpoint"))
                {
                    jetboxCheck1 = true;
                    for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
                    {
                        if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 4)
                        {
                            StartCoroutine(SpawnAndMoveRe());
                            break; // Assuming you want to break out of the loop once the condition is met for one element.
                        }
                    }

                    print("true");
                    // playerStand1 = false;


                }
                //if (hit.collider != null && !hit.collider.CompareTag("Cannonpoint") && !hit.collider.CompareTag("jetpoint") && !hit.collider.CompareTag("tankpoint") && !hit.collider.CompareTag("Playerpoint") && !hit.collider.CompareTag("tankpoint") && !hit.collider.CompareTag("carpoint") && jetboxCheck1 == true)
                //{
                //    if (jetboxCheck1 == true)
                //    {

                //        for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
                //        {
                //            if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 4)
                //            {


                //                StartCoroutine(SpawnAndMoveRe());
                //                break; // Assuming you want to break out of the loop once the condition is met for one element.
                //            }
                //        }



                //    }


                //}
                //if (hit.collider != null && (hit.collider.CompareTag("tankpoint") || hit.collider.CompareTag("Playerpoint") || hit.collider.CompareTag("jetpoint") || hit.collider.CompareTag("Cannonpoint")))
                //{
                //    jetboxCheck1 = false;
                //}


            }
        }
    }
    IEnumerator SpawnAndMoveRe()
    {
        
        yield return new WaitForSeconds(7f);
        one5 = true;
        spawnedJet1.Clear();
    }
}
