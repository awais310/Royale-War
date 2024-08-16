using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawner1 : MonoBehaviour
{
    public GameObject carObject,point,pointpos;
    public List<GameObject> spawnedCar1 = new List<GameObject>();
    public List<GameObject> AllCar = new List<GameObject>();
    public GameObject[] carSpawnPos;
    public bool check1; public RaycastHit hit;
    public bool one2, carboxCheck1;
    void Start()
    {
        check1 = true;
           one2 = true;
        if (check1 == true)
        {
            Instantiate(point, pointpos.transform.position, point.transform.rotation);
            check1 = false;
        }
    }

    public void CarObjectss1()
    {
      
        for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
        {
            if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 1)
            {
                GameObject carspawns = Instantiate(carObject, carSpawnPos[i].transform.position, carObject.transform.rotation);
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
            one2 = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
                if (hit.collider.CompareTag("carpoint"))
                {
                    carboxCheck1 = true;


                    print("true");
                    // playerStand1 = false;


                }
                if (hit.collider != null && !hit.collider.CompareTag("Cannonpoint") && !hit.collider.CompareTag("jetpoint") && !hit.collider.CompareTag("tankpoint") && !hit.collider.CompareTag("Playerpoint") && !hit.collider.CompareTag("tankpoint") && !hit.collider.CompareTag("carpoint") && carboxCheck1 == true)
                {
                    if (carboxCheck1 == true)
                    {

                        for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
                        {
                            if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 1)
                            {


                                StartCoroutine(SpawnAndMoveRe());
                                break; // Assuming you want to break out of the loop once the condition is met for one element.
                            }
                        }



                    }


                }
                if (hit.collider != null && (hit.collider.CompareTag("tankpoint") || hit.collider.CompareTag("Playerpoint") || hit.collider.CompareTag("jetpoint") || hit.collider.CompareTag("Cannonpoint")))
                {
                    carboxCheck1 = false;
                }
            }
        }
    }
    IEnumerator SpawnAndMoveRe()
    {
       
        yield return new WaitForSeconds(8f);
       one2 = true;
        spawnedCar1.Clear();
    }
}
