using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class player : MonoBehaviour
{
    public Vector3 hitPoint;
    public bool playerboxCheck, pos1, pos2, pos3, notEnemy;
    public Transform target1, target2, target3, target4, target5, target6, target7, target8, target9;
    public float speed = 0.05f;
    public soldSpawner Spawnlist; public List<GameObject> spawnlist_1;
    public TargetFacts SpawnFactlist; public List<GameObject> spawnFactlist_1;
    public TargetFacts TransFactlist; public List<Transform> TransFactlist_1;
    public factoryHealth health1; public float _health;
    public enemyhealth enemyHealth; public float _healthEnemy;
    public GameObject firstspawner, secondspawner, thirdspawner, enemy1, CollSpawn, colliderSpawn;
    public Transform nearest;
    public Rigidbody rb;
    private bool shouldStop = false;
    public Vector3 newPosition;
    private Collider otherCollider, othercollider1;
    public float detectionRadius = 5f;
    //public float viewRadius;
    public float distanceToEnemy;
    //[Range(0, 360)]
    //public float viewAngle;
    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();
    public LayerMask targetMask;
    // public List<Transform> Factenemies;
    public Transform nearestEnemyFact;
    public List<Transform> enemiesToRemove = new List<Transform>();
    public List<GameObject> playerMove = new List<GameObject>();
    public bool enemydestroy;
    public GameObject builtSpawn;
    public Transform builtSpawnPos;
    public float _enemyHealthh1, playerHealth;
    public enemyhealth enemyHealthComponent;
    public Vector3 targetPosition, targetPosition1;
    public Animator anim;
    public Collider[] nearbyColliders;
    public bool posi1, posi2, posi3, playerStand1, move;
    public RaycastHit hit;
    public Rigidbody rb1;
    public bool tankCheck1, carCheck1, firecheck, radiusCheck, newCheck, gotoFacts, gotoFact;
    public Collider[] colliders; public float radius; public Transform centerPoint;
    public int item_1, saveitem_1;
    private void Start()
    {
        playerHealth = 100f;
        // StartCoroutine("FindTargetsWithDelay", .2f);
        //target1.transform.position = new Vector3(0.9459355f, 0.183f, -1.757188f);
        //target2.transform.position = new Vector3(0.661f, 0.183f, -1.757188f);
        //target3.transform.position = new Vector3(1.196f, 0.183f, -1.757188f);
        pos1 = true;
        //pos2 = true;
        //pos3 = true;
        firecheck = true;
        radiusCheck = true;
        rb = GetComponent<Rigidbody>();
        // playerboxCheck = false;
        playerStand1 = false;

    }

    //public Vector3 DirFromAngle(float angleInDegrees)
    //{
    //    return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));

    //}
    private void FixedUpdate()
    {
        inRadius();
    }
    void Update()
    {
        //tank tankCheck = gameObject.GetComponent<tank>();
        //if (tankCheck != null)
        //{
        //    tankCheck1 = tankCheck.tankboxCheck;

        //}
        //car carCheck = gameObject.GetComponent<car>();
        //if (carCheck != null)
        //{
        //    carCheck1 = carCheck.carboxCheck;

        //}
        playerSelector itemno1 = GameObject.FindObjectOfType<playerSelector>();
        item_1 = itemno1.itemNo1;
        saveitem_1 = itemno1.saveitem1;
        spawnmanager1 playerStand = gameObject.GetComponentInChildren<spawnmanager1>();
        if (playerStand != null)
        {
            playerStand1 = playerStand.checkPlayerMove;

        }
        Spawnlist = GameObject.FindObjectOfType<soldSpawner>();
        if(Spawnlist!= null)
        {
            spawnlist_1 = Spawnlist.spawnedObjects1;
        }
        
        SpawnFactlist = GameObject.FindObjectOfType<TargetFacts>();
        spawnFactlist_1 = SpawnFactlist.spawnedFacts;
        TransFactlist = Transform.FindObjectOfType<TargetFacts>();
        TransFactlist_1 = TransFactlist.Factenemies;
        if (spawnFactlist_1.Count == 0)
        {
            if (anim != null)
            {
                anim.SetBool("idle", true);
                anim.SetBool("fire", false);
            }
        }

        // enemyhealth enemyHealth = gameObject.GetComponent<enemyhealth>();

        //if (otherCollider != null && otherCollider.gameObject != null)
        //{
        //    enemyhealth enemyHealthComponent = otherCollider.gameObject.GetComponentInChildren<enemyhealth>();
        //    if (enemyHealthComponent != null)
        //    {
        //        _enemyHealthh1 = enemyHealthComponent.health;

        //    }
        //}
        //if (otherCollider!= null && otherCollider.gameObject != null)
        //{
        //    _enemyHealth = otherCollider.gameObject.GetComponent<enemyhealth>().health;

        //}

        //enemyHealth = GameObject.FindObjectOfType<enemyhealth>();
        //if (enemyHealth != null)
        //{
        //    _healthEnemy = enemyHealth.health;
        //}
        health1 = GameObject.FindObjectOfType<factoryHealth>();
        if (health1 != null)
        {
            _health = health1.health;
        }

        if (Input.GetMouseButtonDown(0) && newCheck != true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Playerpoint"))
                {
                    playerboxCheck = true;
                    // carCheck.carboxCheck = false;
                    // tankCheck.tankboxCheck = false;
                    //print("true");
                    // playerStand1 = false;


                }
                if (hit.collider != null && !hit.collider.CompareTag("Cannonpoint") && !hit.collider.CompareTag("jetpoint") && !hit.collider.CompareTag("tankpoint") && !hit.collider.CompareTag("Playerpoint") && !hit.collider.CompareTag("tankpoint") && !hit.collider.CompareTag("carpoint") && playerboxCheck == true)
                {
                    if (playerboxCheck == true)
                    {
                        //soldSpawner respawn = GameObject.FindObjectOfType<soldSpawner>();
                        //for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
                        //{
                        //    if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 2)
                        //    {
                        //        StartCoroutine(SpawnAndMoveRe());
                        //        //respawn.one3 = true;
                        //        break; // Assuming you want to break out of the loop once the condition is met for one element.
                        //    }
                        //}
                        playerStand1 = true;
                    }
                    for (int j = 0; j < playerSelector.inst.selectedweapon.Length; j++)
                    {
                        if (playerSelector.inst.selectedweapon[j].GetComponent<upGridImg>().currentIndex == 2)
                        {
                            for (int i = 0; i < spawnlist_1.Count;)
                            {
                                if (playerboxCheck == true)
                                {
                                    playerMove.Add(spawnlist_1[i]);
                                    spawnlist_1.RemoveAt(i);
                                }
                                else
                                {
                                    i++;
                                }
                            }
                        }
                    }
                    //if (itemno1.checckTwo == 2 && itemno1._itemsave3 == 3)
                    //{
                    //    for (int i = 0; i < spawnlist_1.Count;)
                    //    {
                    //        if (playerboxCheck == true)
                    //        {

                    //            playerMove.Add(spawnlist_1[i]);
                    //            spawnlist_1.RemoveAt(i);
                    //        }
                    //        else
                    //        {
                    //            i++;
                    //        }

                    //    }
                    //}
                    //if (itemno1.checckTwo == 2 && itemno1._itemsave1 == 1)
                    //{
                    //    for (int i = 0; i < Spawnlist.spawnedObjects2.Count;)
                    //    {
                    //        if (playerboxCheck == true)
                    //        {

                    //            playerMove.Add(Spawnlist.spawnedObjects2[i]);
                    //            Spawnlist.spawnedObjects2.RemoveAt(i);
                    //        }
                    //        else
                    //        {
                    //            i++;
                    //        }

                    //    }
                    //}
                    //if (itemno1.checckTwo == 2 && itemno1._itemsave2 == 2)
                    //{
                    //    for (int i = 0; i < Spawnlist.spawnedObjects3.Count;)
                    //    {
                    //        if (playerboxCheck == true)
                    //        {

                    //            playerMove.Add(Spawnlist.spawnedObjects3[i]);
                    //            Spawnlist.spawnedObjects3.RemoveAt(i);
                    //        }
                    //        else
                    //        {
                    //            i++;
                    //        }

                    //    }
                    //}

                    if (hitPoint == Vector3.zero && playerboxCheck == true)
                    {
                        // print("Hellooo!");

                        hitPoint = hit.point;
                        // colliderSpawn = Instantiate(CollSpawn, hitPoint, CollSpawn.transform.rotation);
                        // hitPoint = hitPoint - new Vector3(0, 0.11799997f, 0);
                        if (hit.collider != null && !hit.collider.CompareTag("ground"))
                        {
                            hitPoint = hitPoint - new Vector3(0, 0.85f, 0);
                        }
                        else
                        {
                            hitPoint = hitPoint + new Vector3(0, 0.15f, 0);
                            // print("yesss");
                        }

                        playerboxCheck = false;

                        move = true;
                        newCheck = true;

                        //hitPoint = hitPoint + new Vector3(0, 0.11799997f, 0);
                    }
                    // foreach (GameObject obj in playerMove)
                    {
                        //if (obj != null && move == true)
                        //{
                        //    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, hitPoint, speed );
                        //}
                        // playerMove.Remove(obj);

                    }
                    //else if (!hit.collider.CompareTag("Playerpoint") && playerboxCheck == true)
                    //{
                    //    if (hitPoint == Vector3.zero)
                    //    {
                    //        hitPoint = hit.point ;
                    //        //playerboxCheck = false;
                    //        playerStand1 = true;
                    //        //hitPoint = hitPoint + new Vector3(0, 0.11799997f, 0);
                    //    }
                    //    gameObject.transform.position  = Vector3.MoveTowards(gameObject.transform.position, hitPoint, speed /** Time.deltaTime*/);
                    //    //    target1.position = hitPoint;
                    //    //target2.position = hitPoint;
                    //    //target3.position = hitPoint;

                    //    /*+ new Vector3(0, 0.11799997f, 0)*/

                    //    //target2.position = hitPoint /*+ new Vector3(0, 0.11799997f, 0)*/;
                    //    //target3.position = hitPoint /*+ new Vector3(0, 0.11799997f, 0)*/;
                    //    //playerboxCheck = false;

                    //}

                }
                if (hit.collider != null && (hit.collider.CompareTag("tankpoint") || hit.collider.CompareTag("carpoint") || hit.collider.CompareTag("Cannonpoint") || hit.collider.CompareTag("jetpoint")))
                {
                    playerboxCheck = false;
                }
            }
        }
        if (playerStand1 == true)
        {

            playerboxCheck = false;
            // print("hellooo");
            Vector3 currentPosition1 = gameObject.transform.position;

            // Calculate the target position with the same y-coordinate as the current position
            targetPosition1 = new Vector3(hitPoint.x, currentPosition1.y, hitPoint.z);

            // Move the GameObject towards the target position
            gameObject.transform.position = Vector3.MoveTowards(currentPosition1, targetPosition1, speed * Time.deltaTime);
            // gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, hitPoint, speed);

            if (hitPoint != null)
            {
                Vector3 directionToTarget = hitPoint - transform.position;
                directionToTarget.y = 0; // Ignore vertical (Y) component

                // Calculate the rotation needed to face the target
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);


                // Rotate the object towards the target
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2f * Time.deltaTime);
            }
            // playerMove.Remove(gameObject);
        }

        if (spawnFactlist_1.Count == 0)
        {
            if (anim != null)
            {
                anim.SetBool("fire", false);
                anim.SetBool("idle", true);
            }
        }
        // gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, hitPoint, speed );
        //    target1.position = hitPoint;
        //target2.position = hitPoint;
        //target3.position = hitPoint;

        /*+ new Vector3(0, 0.11799997f, 0)*/

        //target2.position = hitPoint /*+ new Vector3(0, 0.11799997f, 0)*/;
        //target3.position = hitPoint /*+ new Vector3(0, 0.11799997f, 0)*/;
        //playerboxCheck = false;

        //}
        //if(gameObject.layer == LayerMask.NameToLayer("playerNotMerge"))
        //    {

        //    }
        //if (Spawnlist.spawnedObjects.Count > 0)
        //{
        //    if (otherCollider != null && playerboxCheck == true && Spawnlist.spawnedObjects.Count == 0 && otherCollider.gameObject.tag != "Playerpoint")
        //    {
        //        Spawnlist.spawnedObjects[0].transform.position = Vector3.MoveTowards(Spawnlist.spawnedObjects[0].transform.position, hitPoint, speed /** Time.deltaTime*/);

        //        pos1 = false;
        //        //playerboxCheck = false;


        //    }
        //    if (otherCollider != null && playerboxCheck == true && Spawnlist.spawnedObjects.Count == 1 && otherCollider.gameObject.tag != "Playerpoint")
        //    {
        //        target2.position = hitPoint;
        //        //playerboxCheck = false;



        //    }
        //    if (otherCollider != null && playerboxCheck == true && Spawnlist.spawnedObjects.Count == 2)
        //    {
        //        target2.position = hitPoint;
        //        //playerboxCheck = false;


        //    }
        //}

        //if (Spawnlist.spawnedObjects.Count > 0)
        {

            if (playerSelector.inst.selectedweapon[2].GetComponent<upGridImg>().currentIndex == 2)
            {if(Spawnlist != null)
                {
                    if (Spawnlist.spawnedObjects1 != null && pos1 == true && Spawnlist.spawnedObjects1.Count > 0)
                    {
                        {
                            Spawnlist.spawnedObjects1[0].transform.position = Vector3.MoveTowards(Spawnlist.spawnedObjects1[0].transform.position, target1.position /*- new Vector3(0, 0.095f, 0)*/, speed * Time.deltaTime);
                        }
                        pos2 = true;
                    }
                    if (Spawnlist.spawnedObjects1 != null && pos2 == true && Spawnlist.spawnedObjects1.Count > 1)
                    {
                        Spawnlist.spawnedObjects1[1].transform.position = Vector3.MoveTowards(Spawnlist.spawnedObjects1[1].transform.position, target2.position /*- new Vector3(0, 0.095f, 0)*/, speed * Time.deltaTime);
                        pos3 = true;
                    }
                    if (Spawnlist.spawnedObjects1 != null && pos3 == true && Spawnlist.spawnedObjects1.Count > 2)
                    {
                        Spawnlist.spawnedObjects1[2].transform.position = Vector3.MoveTowards(Spawnlist.spawnedObjects1[2].transform.position, target3.position /*- new Vector3(0, 0.095f, 0)*/, speed * Time.deltaTime);
                    }
                }
               
            }
            if (playerSelector.inst.selectedweapon[0].GetComponent<upGridImg>().currentIndex == 2)
            {
                if(Spawnlist != null)
                {
                    if (Spawnlist.spawnedObjects1 != null && pos1 == true && Spawnlist.spawnedObjects1.Count > 0)
                    {
                        {
                            Spawnlist.spawnedObjects1[0].transform.position = Vector3.MoveTowards(Spawnlist.spawnedObjects1[0].transform.position, target4.position - new Vector3(0, 0.095f, 0), speed * Time.deltaTime);
                        }
                        pos2 = true;
                    }
                    if (Spawnlist.spawnedObjects1 != null && pos2 == true && Spawnlist.spawnedObjects1.Count > 1)
                    {
                        Spawnlist.spawnedObjects1[1].transform.position = Vector3.MoveTowards(Spawnlist.spawnedObjects1[1].transform.position, target5.position - new Vector3(0, 0.095f, 0), speed * Time.deltaTime);
                        pos3 = true;
                    }
                    if (Spawnlist.spawnedObjects1 != null && pos3 == true && Spawnlist.spawnedObjects1.Count > 2)
                    {
                        Spawnlist.spawnedObjects1[2].transform.position = Vector3.MoveTowards(Spawnlist.spawnedObjects1[2].transform.position, target6.position - new Vector3(0, 0.095f, 0), speed * Time.deltaTime);
                    }
                }
                
            }
            if (playerSelector.inst.selectedweapon[1].GetComponent<upGridImg>().currentIndex == 2)
            {
                if (Spawnlist != null)
                {
                    if (Spawnlist.spawnedObjects1 != null && pos1 == true && Spawnlist.spawnedObjects1.Count > 0)
                    {
                        {
                            Spawnlist.spawnedObjects1[0].transform.position = Vector3.MoveTowards(Spawnlist.spawnedObjects1[0].transform.position, target7.position - new Vector3(0, 0.095f, 0), speed * Time.deltaTime);
                        }
                        pos2 = true;
                    }
                    if (Spawnlist.spawnedObjects1 != null && pos2 == true && Spawnlist.spawnedObjects1.Count > 1)
                    {
                        Spawnlist.spawnedObjects1[1].transform.position = Vector3.MoveTowards(Spawnlist.spawnedObjects1[1].transform.position, target8.position - new Vector3(0, 0.095f, 0), speed * Time.deltaTime);
                        pos3 = true;
                    }
                    if (Spawnlist.spawnedObjects1 != null && pos3 == true && Spawnlist.spawnedObjects1.Count > 2)
                    {
                        Spawnlist.spawnedObjects1[2].transform.position = Vector3.MoveTowards(Spawnlist.spawnedObjects1[2].transform.position, target9.position - new Vector3(0, 0.095f, 0), speed * Time.deltaTime);
                    }
                }
                    
            }


        }


        if (gameObject.layer == LayerMask.NameToLayer("playerNotMerge"))
        {
            nearbyColliders = Physics.OverlapSphere(transform.position, 0.13f, LayerMask.GetMask("playerNotMerge"));

            // Store the current Y position
            float originalY = transform.position.y;

            // Iterate through nearby GameObjects and move away from them.
            foreach (Collider collider in nearbyColliders)
            {
                if (collider.gameObject != gameObject)
                {
                    Vector3 avoidanceDirection = transform.position - collider.transform.position;

                    // Keep the original Y position
                    avoidanceDirection.y = 0.0f;

                    newPosition = transform.position + avoidanceDirection.normalized * speed * Time.deltaTime;

                    // Restore the original Y position
                    newPosition.y = originalY;

                    transform.position = newPosition;
                }
            }
        }

        if (otherCollider != null && otherCollider.gameObject.tag != "enemy")
        {
            // CancelInvoke("SpawnAndMove");
        }


        if (Spawnlist != null)
        {

            //if (playerMove != null && playerMove.Count >= 3)
            {


                if (gameObject.transform.position == targetPosition1 || otherCollider != null && otherCollider.gameObject.tag == "hitpoint" /*|| Spawnlist.spawnedObjects[1].transform.position == hitPoint || Spawnlist.spawnedObjects[2].transform.position == hitPoint*/)
                {
                    //print(Spawnlist.spawnedObjects[0].transform.position);
                    notEnemy = true;
                    nearestEnemyFact = nearest;
                    pos1 = true; pos2 = true; pos3 = true;
                    if (nearestEnemyFact != null && otherCollider != null && otherCollider.gameObject.tag != "inenemy")
                    {
                        Vector3 targetPosition = nearestEnemyFact.position;
                        //targetPosition = targetPosition + new Vector3(0, 0.436f, 0);
                        //if ( playerMove.Count > 0)
                        {
                            // print("yegy");
                            transform.LookAt(targetPosition);

                            //Spawnlist.spawnedObjects[0].transform.position = Vector3.MoveTowards(Spawnlist.spawnedObjects[0].transform.position, targetPosition, speed * Time.deltaTime);
                            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, speed * Time.deltaTime);
                            Destroy(colliderSpawn, 2f);
                            playerStand1 = false;
                            //target1.position = targetPosition;
                            //target2.position = targetPosition;
                            //target3.position = targetPosition;
                        }
                    }

                }

            }

            //if (otherCollider != null && otherCollider.gameObject.tag == "enemy")
            {
                //if(firecheck == true)
                //{
                //    StartCoroutine(WaitfSeconds());
                //    firecheck = false;
                //}
                //InvokeRepeating("SpawnAndMove", 0f, 0f);
                // Destroy(colliderSpawn, 2f);
                if (colliders.Length > 0)
                {
                    foreach (Collider col in colliders)
                    {
                        // Check if the collider is attached to a GameObject
                        if (col != null && col.gameObject != null)
                        {
                            if (col.gameObject.layer == LayerMask.NameToLayer("Enemmy") || col.gameObject.layer == LayerMask.NameToLayer("EnemyFact"))

                            {
                                playerStand1 = false;
                                //playerboxCheck = false;
                                notEnemy = true;
                                //playerboxCheck = true;
                                //pos1 = false;
                                if (col.gameObject.transform.position != null)
                                {
                                    Vector3 directionToTarget = col.gameObject.transform.position - transform.position;
                                    directionToTarget.y = 0; // Ignore vertical (Y) component

                                    // Calculate the rotation needed to face the target
                                    Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

                                    // Apply the Y-axis rotation to preserve the initial -90 degree rotation
                                    targetRotation *= Quaternion.Euler(0, -90, 0);




                                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2f * Time.deltaTime);
                                }
                                distanceToEnemy = Vector3.Distance(transform.position, col.gameObject.transform.position);

                                //target1.position = otherCollider.transform.position;
                                //target2.position = otherCollider.transform.position;
                                //target3.position = otherCollider.transform.position;
                                // InvokeRepeating("SpawnAndMove", 6f, 0f);
                                if (distanceToEnemy > 0.7f)
                                {

                                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, col.transform.position, speed * Time.deltaTime);
                                    //InvokeRepeating("SpawnAndMove", 0f, 1f);
                                    //target1.position = otherCollider.transform.position;
                                    //target2.position = otherCollider.transform.position;
                                    //target3.position = otherCollider.transform.position;
                                    // transform.LookAt(target1.position);
                                    //if (anim != null)
                                    //{
                                    //    anim.SetBool("fire", false);
                                    //}
                                }

                                if (distanceToEnemy < 0.7f)
                                {
                                    //InvokeRepeating("SpawnAndMove", 10f, 8f);
                                    transform.LookAt(col.transform.position);
                                    // if (_enemyHealthh1 > 0)
                                    {
                                        // print("yesEnter");
                                        gameObject.transform.position = gameObject.transform.position;
                                        //InvokeRepeating("SpawnAndMove", 0f, 1f);
                                        if (anim != null)
                                        {
                                            anim.SetBool("fire", true);
                                        }
                                        //target1.position = otherCollider.transform.position - new Vector3(0.1f, 0f, 0.6f);
                                        //target2.position = otherCollider.transform.position - new Vector3(0.1f, 0f, 0.6f);
                                        //target3.position = otherCollider.transform.position - new Vector3(0.1f, 0f, 0.6f);
                                        //transform.LookAt(target1.position);
                                    }


                                    // Destroy(otherCollider.gameObject, 5f);

                                    enemydestroy = true;
                                }

                                //if (enemyHealth != null && enemyHealth.health == 0)
                                //{
                                //    Destroy(otherCollider.gameObject);
                                //}
                            }
                        }
                    }
                }
            }

            //enemy1 = otherCollider.gameObject;
            if (_enemyHealthh1 <= 0 && notEnemy == true /*&& otherCollider != null && otherCollider.gameObject != null && otherCollider.gameObject.tag != "enemy"*/)
            {
                playerboxCheck = false;
                //playerboxCheck = false;
                //pos1 = false;
                //rb1.isKinematic = false;
                {
                    if (anim != null)
                    {
                        anim.SetBool("fire", false);
                        // anim.SetBool("idle", true);
                    }
                    // print("Hello1111");

                    {
                        pos1 = true; pos2 = true; pos3 = true;

                        nearestEnemyFact = nearest;

                        // Move towards the nearest enemy if one is found
                        if (nearestEnemyFact != null)
                        {
                            //pos1 = true;
                            //print("Hello2");
                            targetPosition = nearestEnemyFact.position;
                            //targetPosition = targetPosition + new Vector3(0, 0.436f, 0);
                            //if (pos1 == false && Spawnlist.spawnedObjects.Count > 0)
                            {
                                transform.LookAt(targetPosition);
                                //print("Hello3");
                                //Spawnlist.spawnedObjects[0].transform.position = Vector3.MoveTowards(Spawnlist.spawnedObjects[0].transform.position, targetPosition, speed * Time.deltaTime);
                                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, speed * Time.deltaTime);

                                //target1.position = targetPosition;
                                //target2.position = targetPosition;
                                //target3.position = targetPosition;

                            }
                        }
                    }
                }


            }
        }

        //for (int i = 0; i < spawnFactlist_1.Count; i++)
        //{
        //    GameObject obj = spawnFactlist_1[i];
        //    // Assuming 'power' is a property or variable that represents the power of the GameObject.
        //    // Replace 'YourComponent' with the actual component name.

        //    if (_enemyHealthh1 < 0)
        //    {
        //        // If the power is less than 0, destroy the GameObject.
        //        Destroy(obj);

        //        // Remove the GameObject from the list.
        //        spawnFactlist_1.RemoveAt(i);

        //        // Decrement the loop counter to account for the removed element.
        //        i--;
        //    }
        //}

        if (gotoFacts == true)
        {
            print("goto1");
            playerStand1 = false;
            //print(Spawnlist.spawnedObjects[0].transform.position);
            notEnemy = true;
            nearestEnemyFact = nearest;
            pos1 = true;
            //transform.LookAt(targetPosition);
            if (nearestEnemyFact != null /*&& otherCollider != null && otherCollider.gameObject.tag != "inenemy"*/)
            {
                print("goto2");
                Vector3 targetPosition = nearestEnemyFact.position;
                //targetPosition = targetPosition + new Vector3(0, 0.436f, 0);
                //if ( playerMove.Count > 0)
                {
                    // print("yegy");
                    if (targetPosition != null)
                    {
                        print("goto3");
                        Vector3 directionToTarget = targetPosition - transform.position;
                        directionToTarget.y = 0; // Ignore vertical (Y) component

                        // Calculate the rotation needed to face the target
                        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

                        // Apply the Y-axis rotation to preserve the initial -90 degree rotation
                        targetRotation *= Quaternion.Euler(0, 90, 0);



                        // Rotate the object towards the target
                        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2f * Time.deltaTime);
                    }
                    //transform.LookAt(targetPosition);
                    //Spawnlist.spawnedObjects[0].transform.position = Vector3.MoveTowards(Spawnlist.spawnedObjects[0].transform.position, targetPosition, speed * Time.deltaTime);
                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, speed * Time.deltaTime);
                    // Destroy(colliderSpawn, 2f);
                    //tankStand1 = false;

                }

            }
        }

        nearest = null;
        float minDistance = Mathf.Infinity;

        foreach (Transform Factenemy in TransFactlist_1)
        {
            if (Factenemy == null)
            {
                continue;
            }
            float distance = Vector3.Distance(transform.position, Factenemy.position);

            if (TransFactlist_1 != null)
            {
                //if (_health == 0)
                //{

                //    Destroy(Factenemy.gameObject);
                //}
                if (playerHealth > 0)
                {
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearest = Factenemy;
                    }
                }

                //if (_health == 0 )
                //{

                //    Destroy(Factenemy.gameObject);
                //}
                //else if (_health > 0)
                //{
                //    if (distance < minDistance)
                //    {
                //        minDistance = distance;
                //        nearest = Factenemy;
                //    }
                //}
            }
        }

        //if (nearest != null&& Spawnlist.spawnedObjects[0].transform.position == hitPoint)
        //{
        //    Vector3 targetPosition = nearest.position;
        //    if (pos1 == false && Spawnlist.spawnedObjects.Count > 0)
        //    {
        //        target1.position = targetPosition;
        //        target2.position = targetPosition;
        //        target3.position = targetPosition;
        //    }
        //}


    }
    //Transform FindNearestEnemy()
    //{
    //    Transform nearest = null;
    //    float minDistance = Mathf.Infinity;

    //    foreach (Transform Factenemy in TransFactlist_1)
    //    {
    //        float distance = Vector3.Distance(transform.position, Factenemy.position);
    //        //factoryHealth enemyFactHealth = Factenemy.GetComponent<factoryHealth>();
    //        if (TransFactlist_1 != null /*|| health1 != null*/)
    //        {
    //            if (_health == 0)
    //            {

    //                // Mark this enemy for removal
    //                Destroy(Factenemy.gameObject);
    //                //enemiesToRemove.Add(Factenemy);
    //                //TransFactlist_1.Remove(Factenemy);

    //            }
    //            else if (_health > 0)
    //            {
    //                if (distance < minDistance )
    //                {
    //                    minDistance = distance;
    //                    nearest = Factenemy;
    //                }
    //            }
    //        }


    //    }
    //    //foreach (Transform enemyToRemove in enemiesToRemove)
    //    //{
    //    //    TransFactlist_1.Remove(enemyToRemove);
    //    //}
    //    //foreach (Transform enemyToRemove in enemiesToRemove)
    //    //{
    //    //    Destroy(enemyToRemove.gameObject);
    //    //    enemies.Remove(enemyToRemove);
    //    //}

    //    return nearest;
    //}
    //IEnumerator SpawnAndMoveRe()
    //{
    //    soldSpawner respawn = GameObject.FindObjectOfType<soldSpawner>();
    //    yield return new WaitForSeconds(8f);
    //    respawn.one3 = true;
    //}
    void inRadius()
    {
        if (centerPoint != null)
        {
            // Find all colliders within the specified radius of the centerPoint
            colliders = Physics.OverlapSphere(centerPoint.position, radius);

            // Check if any colliders are found
            if (colliders.Length > 0)
            {
                foreach (Collider col in colliders)
                {
                    // Check if the collider is attached to a GameObject
                    if (col.gameObject != null)
                    {
                        if (col.gameObject.layer == LayerMask.NameToLayer("Enemmy") || col.gameObject.layer == LayerMask.NameToLayer("EnemyFact"))
                        {

                            gotoFact = true;
                            //radiusCheck = true;
                            Debug.Log(col.gameObject.name + " is within the radius.");
                            pos1 = false;
                            //pos1 = false;
                            //StartCoroutine(SpawnAndMoveRepeatedly());
                            //if (radiusCheck == true)
                            //{
                            SpawnAndMove1();

                            //}

                            //InvokeRepeating("SpawnAndMove1", 0f, 1.8f);


                            //InvokeRepeating("SpawnAndMove1", 0f, 1.8f);
                            // print("Hit11");
                            enemyHealthComponent = col.gameObject.GetComponentInChildren<enemyhealth>();
                            if (enemyHealthComponent != null)
                            {
                                _enemyHealthh1 = enemyHealthComponent.health;

                            }
                            // You can perform any other actions here for "enemy" objects
                        }
                        else 
                        {

                            if (gotoFact == true)
                            {
                                if (col.gameObject.layer != LayerMask.NameToLayer("Enemmy") && enemyHealthComponent != null && enemyHealthComponent.health <= 0)
                                {
                                    print("gotof");
                                    gotoFacts = true;
                                    gotoFact = false;
                                }

                            }

                        }
                    }
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //pos1 = false;pos2 = false;pos3 = false;
        this.otherCollider = other;
        if (other.gameObject.tag == "inenemy")
        {
            pos1 = false; pos2 = false; pos3 = false;
            //pos1 = false;
            //if (rb1 != null && rb1.isKinematic == false)
            //{
            //    rb1.isKinematic = true;
            //    //StartCoroutine(kinFalse());
            //}
            // InvokeRepeating("SpawnAndMove", 0f, 1f);

            //StartCoroutine(WaitForSeconds());
            //StartCoroutine(WaitfSeconds());
            //rb1 = gameObject.GetComponent<Rigidbody>();
            //else if (rb != null && rb.isKinematic == false)
            //{
            //    rb.isKinematic = true;
            //}
        }
        if (other.gameObject.tag == "pos1")
        {



            //pos1 = false;
            if (anim != null)
            {
                // print("yes true1");
                anim.SetBool("idle", true);
                // anim.SetBool("fire", false);
            }
            posi1 = false;

        }
        else if (other.gameObject.tag == "pos2")
        {
            // print("yes true pos1");
            //rb1 = gameObject.GetComponent<Rigidbody>();
            //if (rb1 != null && rb1.isKinematic == false)
            //{
            //    rb1.isKinematic = true;
            //    StartCoroutine(kinFalse());
            //}
            //pos2 = false;
            if (anim != null)
            {
                anim.SetBool("idle", true);
            }
            posi2 = false;
        }
        else if (other.gameObject.tag == "pos3")
        {

            // pos3 = false;
            if (anim != null)
            {
                anim.SetBool("idle", true);
            }
            posi3 = false;
        }
        else if (other.gameObject.tag == "pos1")
        {
            // pos3 = false;
            if (anim != null)
            {
                anim.SetBool("idle", true);
            }
            posi1 = false;
        }
        //else if (other.gameObject.tag == "enemy")
        //{

        //    if (anim != null)
        //    {
        //        anim.SetBool("fire", true);
        //    }
        //}


        //if (other.gameObject.tag == "enemy")
        //{

        //    GameObject builtSpawns = Instantiate(builtSpawn, builtSpawnPos.transform.position, builtSpawn.transform.rotation);
        //    Rigidbody rb = builtSpawns.GetComponent<Rigidbody>();
        //    Vector3 velocity = (otherCollider.transform.position - builtSpawnPos.transform.position).normalized * 1.0f;
        //    rb.velocity = velocity;
        //}
        //else
        //{



        //}

    }
    //private IEnumerator WaitfSeconds()
    //{


    //    //if (rb1 != null && rb1.isKinematic == true )
    //    //{
    //    //    yield return new WaitForSeconds(5f);
    //    //    rb1.isKinematic = false;
    //    //}
    //    yield return new WaitForSeconds(2f);

    //    if (otherCollider != null && builtSpawnPos != null && spawnFactlist_1.Count != 0)
    //    {

    //        GameObject builtSpawns = Instantiate(builtSpawn, builtSpawnPos.transform.position, builtSpawn.transform.rotation);
    //        Rigidbody rb = builtSpawns.GetComponent<Rigidbody>();
    //        Vector3 velocity = (otherCollider.gameObject.transform.position - builtSpawnPos.transform.position).normalized * 2.0f;
    //        rb.velocity = velocity;
    //        // print("yesEnterto");
    //    }
    //    firecheck = true;
    //}
    private IEnumerator kinFalse()
    {
        yield return new WaitForSeconds(0.3f);
        //if (rb1 != null && rb1.isKinematic == true)
        //{

        //    rb1.isKinematic = false;
        //}
    }
    //private IEnumerator WaitForSeconds()
    //{

    //    yield return new WaitForSeconds(2f);

    //    if (rb1 != null && rb1.isKinematic == false)
    //    {

    //        rb1.isKinematic = true;
    //    }
    //}
    private void OnTriggerExit(Collider other)
    {
        //if (rb1 != null && rb1.isKinematic == false)
        //{
        //    rb1.isKinematic = false;
        //}
        if (other.gameObject.tag != "pos1")
        {
            // pos1 = true;
            if (anim != null)
            {
                anim.SetBool("idle", false);
                //print("yes false");
            }
            posi1 = true;

        }
        if (other.gameObject.tag != "pos2")
        {

            if (anim != null)
            {
                anim.SetBool("idle", false);

            }
            posi2 = true;

        }
        if (other.gameObject.tag != "pos3")
        {

            if (anim != null)
            {
                anim.SetBool("idle", false);

            }
            posi3 = true;
        }
        if (other.gameObject.tag != "inenemy")
        {
            //playerStand1 = false;
            // playerboxCheck = true;
            //pos1 = true;
            if (anim != null)
            {
                anim.SetBool("fire", false);
            }
        }

        if (other.gameObject.tag != "inenemy")
        {
            //CancelInvoke("SpawnAndMove");

        }
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    this.othercollider1 = other;
    //    if (other.gameObject.tag == "enemy")
    //    {
    //        enemyhealth enemyHealthComponent = other.gameObject.GetComponentInChildren<enemyhealth>();
    //        if (enemyHealthComponent != null)
    //        {
    //            _enemyHealthh1 = enemyHealthComponent.health;

    //        }

    //    }



    //}
    //IEnumerator MyCoroutine()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    //InvokeRepeating("SpawnAndMove", 1f, 15f);

    //}
    private void SpawnAndMove1()
    {
        //StartCoroutine(MyCoroutine());
        if (builtSpawnPos != null && radiusCheck == true && spawnFactlist_1.Count != 0)
        {
            if (colliders.Length > 0)
            {
                foreach (Collider col in colliders)
                {
                    // Check if the collider is attached to a GameObject
                    if (col.gameObject != null && col.gameObject.layer == LayerMask.NameToLayer("Enemmy") || col.gameObject.layer == LayerMask.NameToLayer("EnemyFact"))
                    {
                        GameObject builtSpawns = Instantiate(builtSpawn, builtSpawnPos.transform.position, builtSpawn.transform.rotation);
                        Rigidbody rb = builtSpawns.GetComponent<Rigidbody>();
                        Vector3 velocity = (col.gameObject.transform.position - builtSpawnPos.transform.position).normalized * 2.0f;
                        rb.velocity = velocity;
                        radiusCheck = false;
                        StartCoroutine("SpawnAndMove");
                        // print("yesEnterto");
                    }
                }
            }
        }
    }
    IEnumerator SpawnAndMove()
    {
        yield return new WaitForSeconds(0.3f);
        radiusCheck = true;
    }
}
