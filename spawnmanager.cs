using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    public GameObject target1, target2, target3, enemytarget, spawnedObject, spawnedObject1, spawnedObject2, spawnedObject4, spawnedObject5, spawnedObject6, spawnedObject7,
        enemyObject, spawnedObject3, enemyFect, target4, target5, target6;
    public float speed;
    public Transform enemy1;
    public GameObject firstObject, secondObject, thirdObject;
    public GameObject Firstelement, Secondelement, Thirdelement;
    public bool check, check1, check2, check3, playerboxCheck;
    public List<GameObject> spawnedObjects = new List<GameObject>();
    public List<GameObject> AllPlayers = new List<GameObject>();
    public Vector3 hitPoint;
    GameObject firstPlayer, SecondPlayer, thirdPlayer;
    //Start is called before the first frame update
void Start()
    {
        check = true;
        check1 = true;
        check2 = true;
        check3 = true;
    }

    //Update is called once per frame
void Update()
    {
        //if (check1 == true)
        //{
        //    StartCoroutine(DisableAnimationForSeconds1(10f));
        //    check1 = false;
        //}
        //if (spawnedObject3 != null)
        //{

        //    spawnedObject3.transform.position = Vector3.MoveTowards(spawnedObject3.transform.position, enemytarget.transform.position, speed);
        //}
        if (check == true && spawnedObjects.Count < 1 && AllPlayers.Count >= 0)
        {
            StartCoroutine(FirstplayerSpawn(2f));
            check = false;

        }
        //if (check2 == true && spawnedObjects.Count == 1 && AllPlayers.Count > 0)
        //{
        //    StartCoroutine(SecondplayerSpawn(2f));
        //    check2 = false;
        //}
        //if (check3 == true && spawnedObjects.Count == 2 && AllPlayers.Count > 0)
        //{
        //    StartCoroutine(ThirdplayerSpawn(2f));
        //    check3 = false;
        //}
        if (spawnedObjects.Count == 1 && AllPlayers.Count > 0)
        {
            // if (AllPlayers.Count == 1)
            {
                firstPlayer = AllPlayers[0];
                firstPlayer.transform.position = Vector3.MoveTowards(AllPlayers[0].transform.position, target1.transform.position, speed);

            }
            //else if (playerboxCheck == false)
            //{

            //    firstPlayer = AllPlayers[0];
            //    firstPlayer.transform.position = Vector3.MoveTowards(AllPlayers[0].transform.position, target1.transform.position, speed);
            //}
        }

        else if (spawnedObjects.Count == 2 && AllPlayers.Count > 0)
        {
            //if (AllPlayers.Count == 2)
            {

                SecondPlayer = AllPlayers[1];
                SecondPlayer.transform.position = Vector3.MoveTowards(AllPlayers[1].transform.position, target2.transform.position, speed);

            }
            //else if (playerboxCheck == false)
            //{

            //    SecondPlayer = AllPlayers[1];
            //    SecondPlayer.transform.position = Vector3.MoveTowards(AllPlayers[1].transform.position, target2.transform.position, speed);

            //}

        }

        else if (spawnedObjects.Count == 3 && check3 == false && AllPlayers.Count > 0)
        {
            //if (AllPlayers.Count == 3)
            {
                thirdPlayer = AllPlayers[2];
                thirdPlayer.transform.position = Vector3.MoveTowards(AllPlayers[2].transform.position, target3.transform.position, speed);

            }
            //else if (playerboxCheck == false)
            //{
            //    thirdPlayer = AllPlayers[2];
            //    thirdPlayer.transform.position = Vector3.MoveTowards(AllPlayers[2].transform.position, target3.transform.position, speed);

            //}

            //firstObject = spawnedObjects[0];
            //secondObject = spawnedObjects[1];
            //thirdObject = spawnedObjects[2];
        }
        //if (check == false && spawnedObjects.Count == 3 /*&& spawnedObject2 != null && spawnedObject4 != null*/)
        //{
        //    if (AllPlayers.Count > 3)
        //    {
        //        firstPlayer.transform.position = Vector3.MoveTowards(firstPlayer.transform.position, target1.transform.position, speed);

        //    }
        //    else if (playerboxCheck == false)
        //    {
        //        firstPlayer.transform.position = Vector3.MoveTowards(firstPlayer.transform.position, target1.transform.position, speed);

        //    }

        //}
        //if (check2 == false && spawnedObjects.Count == 3/* && spawnedObject1 != null && spawnedObject4 != null*/)
        //{
        //    SecondPlayer.transform.position = Vector3.MoveTowards(SecondPlayer.transform.position, target2.transform.position, speed);

        //}
        
    }
    private IEnumerator FirstplayerSpawn(float seconds)
    {

        yield return new WaitForSeconds(seconds);
        spawnedObject1 = Instantiate(spawnedObject, transform.position, Quaternion.identity);
        AllPlayers.Insert(0, spawnedObject1);
        //AllPlayers.Add(AllPlayers[0]);
        spawnedObjects.Insert(0, spawnedObject1);
    }
    //private IEnumerator SecondplayerSpawn(float seconds)
    //{

    //    yield return new WaitForSeconds(seconds);
    //    spawnedObject2 = Instantiate(spawnedObject, transform.position, Quaternion.identity);
    //    AllPlayers.Insert(1, spawnedObject2);
    //    //AllPlayers.Add(AllPlayers[0]);
    //    spawnedObjects.Insert(1, spawnedObject2);

    //}
    //private IEnumerator ThirdplayerSpawn(float seconds)
    //{

    //    yield return new WaitForSeconds(seconds);
    //    spawnedObject4 = Instantiate(spawnedObject, transform.position, Quaternion.identity);
    //    AllPlayers.Insert(2, spawnedObject4);
    //    //AllPlayers.Add(AllPlayers[0]);
    //    spawnedObjects.Insert(2, spawnedObject4);
    //}
    //private IEnumerator DisableAnimationForSeconds1(float seconds)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    spawnedObject3 = Instantiate(enemyObject, enemy1.position, Quaternion.identity);
    //}

}
