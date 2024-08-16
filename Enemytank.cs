using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Enemytank : MonoBehaviour
{
    //public Vector3 hitPoint;
    public bool tankboxCheck, pos1, notEnemy;
   
    public float speed = 0.35f;
    //public tankSpawner Spawnlist; public List<GameObject> spawnlist_1;
    public playerSelector SpawnFactlist; public List<GameObject> spawnFactlist_1;
    public playerSelector TransFactlist; public List<Transform> TransFactlist_1;
    public factoryHealth health1; public float _health;
    public enemyhealth enemyHealth; public float _healthEnemy;
    public GameObject firstspawner, secondspawner, thirdspawner, enemy1, colliderSpawn;
    public Transform nearest;
    public Rigidbody rb;
    private bool shouldStop = false;
    public Vector3 newPosition;
    private Collider otherCollider, othercollider1;
    public float detectionRadius = 5f;
    public float viewRadius; public float distanceToEnemy;
    [Range(0, 360)]
    public float viewAngle;
    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();
    public LayerMask targetMask;
    // public List<Transform> Factenemies;
    public Transform nearestEnemyFact;
    public List<Transform> enemiesToRemove = new List<Transform>();
    public List<GameObject> playerMove = new List<GameObject>();
    public bool enemydestroy;
    public GameObject GollSpawn;
    public Transform GolSpawnPos;
    public float _enemyHealthh1, playerHealth;
    public enemyhealth enemyHealthComponent;
    public Vector3 targetPosition, targetPosition1;
    public Animator anim;
    public Collider[] nearbyColliders;
    public bool posi1, tankStand1, radiusCheck, newCheck;
    public RaycastHit hit;
    //public Rigidbody rb1;
    public bool carCheck1, playerCheck1;
    public car carCheck;
    public player playerCheck;
    public int item_1, saveitem_1;
    public bool respawn, Notinradius;
    public Transform centerPoint; public float radius;
    public Collider[] colliderrs;
   // public enemyhealth enemyHealthComponent;
    private void Start()
    {
        playerHealth = 100f;
        Notinradius = true;
        // StartCoroutine("FindTargetsWithDelay", .2f);
        //target1.transform.position = new Vector3(0.9459355f, 0.183f, -1.407188f);

        pos1 = true;
        radiusCheck = true;
        rb = GetComponent<Rigidbody>();
        //tankboxCheck = false;
        // tankStand1 = false;

    }



    private void FixedUpdate()
    {
        inRadius();
    }

    void Update()
    {
        //playerSelector itemno1 = GameObject.FindObjectOfType<playerSelector>();
        //item_1 = itemno1.itemNo1;
        //saveitem_1 = itemno1.saveitem1;
        //spawnmanager1 playerStand = gameObject.GetComponentInChildren<spawnmanager1>();
        //if (playerStand != null)
        //{
        //    tankStand1 = playerStand.checkTankMove;

        //}
        //playerSelector itemno1 = gameObject.GetComponent<playerSelector>();
        //if (itemno1 != null)
        //{
        //    _itemNO = itemno1.itemNo1;
        //    _saveItem = itemno1.saveitem1;
        //}
        
        //SpawnFactlist = GameObject.FindObjectOfType<spawnmanager1>();
        //spawnFactlist_1 = SpawnFactlist.spawnedFacts;
        //TransFactlist = Transform.FindObjectOfType<spawnmanager1>();
        //TransFactlist_1 = TransFactlist.Factenemies;
        SpawnFactlist = GameObject.FindObjectOfType<playerSelector>();
        spawnFactlist_1 = SpawnFactlist.ClonespawnedFactorys;
        TransFactlist = Transform.FindObjectOfType<playerSelector>();
        TransFactlist_1 = TransFactlist.CloneplayerFactTran;

        //if(spawnFactlist_1.Count == 0)
        //{
        //    if (anim != null)
        //    {
        //        anim.SetBool("idle", true);
        //        anim.SetBool("fire", false);
        //    }
        //}
        //if (playerHealth <= 0)
        //{
        //    Destroy(gameObject, 0.2f);
        //}
        health1 = GameObject.FindObjectOfType<factoryHealth>();
        if (health1 != null)
        {
            _health = health1.health;
        }

        //if (Input.GetMouseButtonDown(0) && newCheck != true)
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        //    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        //    {

        //        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        //        if (hit.collider.CompareTag("tankpoint"))
        //        {
        //            tankboxCheck = true;


        //            print("true");
        //            // playerStand1 = false;


        //        }
        //        if (hit.collider != null && !hit.collider.CompareTag("Cannonpoint") && !hit.collider.CompareTag("jetpoint") && !hit.collider.CompareTag("tankpoint") && !hit.collider.CompareTag("Playerpoint") && !hit.collider.CompareTag("tankpoint") && !hit.collider.CompareTag("carpoint") && tankboxCheck == true)
        //        {
        //            if (tankboxCheck == true)
        //            {
        //                //  TSpawner = true;
        //                //tankSpawner respawn = GameObject.FindObjectOfType<tankSpawner>();
        //                //for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
        //                //{
        //                //    if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 0)
        //                //    {
        //                //        StartCoroutine(SpawnAndMoveRe());
        //                //        // respawn.one1 = true;
        //                //        break; // Assuming you want to break out of the loop once the condition is met for one element.
        //                //    }
        //                //}


        //                tankStand1 = true;
        //            }
        //            for (int j = 0; j < playerSelector.inst.selectedweapon.Length; j++)
        //            {
        //                if (playerSelector.inst.selectedweapon[j].GetComponent<upGridImg>().currentIndex == 0)
        //                {
        //                    for (int i = 0; i < spawnlist_1.Count;)
        //                    {
        //                        if (tankboxCheck == true)
        //                        {
        //                            playerMove.Add(spawnlist_1[i]);
        //                            spawnlist_1.RemoveAt(i);
        //                        }
        //                        else
        //                        {
        //                            i++;
        //                        }
        //                    }
        //                }
        //            }


        //            if (hitPoint == Vector3.zero && tankboxCheck == true)
        //            {


        //                hitPoint = hit.point;
        //                // colliderSpawn = Instantiate(CollSpawn, hitPoint, CollSpawn.transform.rotation);
        //                // hitPoint = hitPoint + new Vector3(0, 0.11799997f, 0);
        //                //tankboxCheck = false;

        //                // move = true;

        //                if (hit.collider != null && !hit.collider.CompareTag("ground"))
        //                {
        //                    hitPoint = hitPoint - new Vector3(0, 0.65f, 0);
        //                }
        //                else
        //                {
        //                    hitPoint = hitPoint + new Vector3(0, 0.15f, 0);
        //                }
        //                newCheck = true;
        //            }



        //        }
        //        if (hit.collider != null && (hit.collider.CompareTag("Playerpoint") || hit.collider.CompareTag("carpoint") || hit.collider.CompareTag("jetpoint") || hit.collider.CompareTag("Cannonpoint")))
        //        {
        //            tankboxCheck = false;
        //        }
        //    }
        //}

        //if (tankStand1 == true && hit.collider != null && !hit.collider.CompareTag("tankpoint"))
        //{

        //    tankboxCheck = false;
        //    // print("hellooo");
        //    //foreach (GameObject obj in playerMove)
        //    //{
        //    //    obj.transform.position = Vector3.MoveTowards(obj.transform.position, hitPoint, speed * Time.deltaTime);
        //    //}
        //    Vector3 currentPosition1 = gameObject.transform.position;

        //    // Calculate the target position with the same y-coordinate as the current position
        //    targetPosition1 = new Vector3(hitPoint.x, currentPosition1.y, hitPoint.z);

        //    // Move the GameObject towards the target position
        //    gameObject.transform.position = Vector3.MoveTowards(currentPosition1, targetPosition1, speed * Time.deltaTime);
        //    // gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, hitPoint, speed);


        //    //transform.LookAt(targetPosition);
        //    if (hitPoint != null)
        //    {
        //        //foreach (var playerObject in playerMove)
        //        {
        //            // Use modulo to wrap around at the end

        //            //Vector3 directionToTarget = hitPoint - playerMove[nextIndex].transform.position;
        //            Vector3 directionToTarget = hitPoint - transform.position;
        //            directionToTarget.y = 0; // Ignore vertical (Y) component

        //            // Calculate the rotation needed to face the target
        //            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        //            // Apply the Y-axis rotation to preserve the initial -90 degree rotation
        //            targetRotation *= Quaternion.Euler(0, 90, 0);


        //            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2f * Time.deltaTime);
        //        }
        //        //for (int i = 0; i < playerMove.Count; i++)
        //        //{

        //        //    GameObject playerObject = playerMove[i];

        //        //    int nextIndex = (i + 1) % playerMove.Count; // Use modulo to wrap around at the end

        //        //    Vector3 directionToTarget = hitPoint - playerMove[nextIndex].transform.position;
        //        //    directionToTarget.y = 0; // Ignore vertical (Y) component

        //        //    // Calculate the rotation needed to face the target
        //        //    Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        //        //    // Apply the Y-axis rotation to preserve the initial -90 degree rotation
        //        //    targetRotation *= Quaternion.Euler(0, 90, 0);

        //        //    // Rotate the current object towards the target
        //        //    playerObject.transform.rotation = Quaternion.Slerp(playerObject.transform.rotation, targetRotation, 2f * Time.deltaTime);
        //        //}
        //        // Rotate the object towards the target
        //        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2f * Time.deltaTime);
        //    }
        //    // playerMove.Remove(gameObject);
        //}

        //if (Spawnlist.spawnedObjects.Count > 0)
        {
            //for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
            //{
            //    if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 0)
            //    {
            //        if (pos1 == true && spawnlist_1.Count > 0)
            //        {
            //            switch (i)
            //            {
            //                case 0:
            //                    spawnlist_1[0].transform.position = Vector3.MoveTowards(spawnlist_1[0].transform.position, target1.position, speed * Time.deltaTime);
            //                    break;
            //                case 1:
            //                    spawnlist_1[0].transform.position = Vector3.MoveTowards(spawnlist_1[0].transform.position, target2.position, speed * Time.deltaTime);
            //                    break;
            //                case 2:
            //                    spawnlist_1[0].transform.position = Vector3.MoveTowards(spawnlist_1[0].transform.position, target3.position, speed * Time.deltaTime);
            //                    break;
            //            }
            //        }
            //    }
            //}






        }


        if (gameObject.layer == LayerMask.NameToLayer("Enemmy"))
        {
            nearbyColliders = Physics.OverlapSphere(transform.position, 0.13f, LayerMask.GetMask("Enemmy"));

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

        //if ( otherCollider != null && otherCollider.gameObject.tag != "enemy")
        //{
        //    CancelInvoke("SpawnAndMove1");
        //}


        // if (Spawnlist != null)
        {

            //if (playerMove != null && playerMove.Count >= 3)



            if (Notinradius == true)
            {
                nearestEnemyFact = nearest;
                pos1 = true;
                //transform.LookAt(targetPosition);
                if (nearestEnemyFact != null /*&& otherCollider != null*//* && otherCollider.gameObject.tag != "playerr" || otherCollider.gameObject.tag != "tank"*/)
                {

                    Vector3 targetPosition = nearestEnemyFact.position;

                    //if ( playerMove.Count > 0)
                    {

                        if (targetPosition != null)
                        {
                            Vector3 directionToTarget = targetPosition - transform.position;
                            directionToTarget.y = 0; // Ignore vertical (Y) component

                            // Calculate the rotation needed to face the target
                            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

                            // Apply the Y-axis rotation to preserve the initial -90 degree rotation
                            targetRotation *= Quaternion.Euler(0, 90, 0);



                            // Rotate the object towards the target
                            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2f * Time.deltaTime);
                        }

                        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, speed * Time.deltaTime);


                    }
                }
            }

            if (colliderrs.Length > 0)
            {
                foreach (Collider col in colliderrs)
                {
                    // Check if the collider is attached to a GameObject
                    if (col != null && col.gameObject != null)
                    {
                        if (col.gameObject.layer == LayerMask.NameToLayer("playerNotMerge") || col.gameObject.layer == LayerMask.NameToLayer("playerFact"))

                        {
                            Notinradius = true;
                        }
                    }
                }
            }

            // if (otherCollider != null && otherCollider.gameObject.tag == "enemy")
            // {
            //transform.LookAt(otherCollider.transform.Find("enemy").position);
            // transform.LookAt(targetPosition);
            if (colliderrs.Length > 0)
            {
                foreach (Collider col in colliderrs)
                {
                    // Check if the collider is attached to a GameObject
                    if (col != null && col.gameObject != null)
                    {
                        if (col.gameObject.layer == LayerMask.NameToLayer("playerNotMerge") || col.gameObject.layer == LayerMask.NameToLayer("playerFact"))

                        {
                            Notinradius = false;
                            print("Enter2");
                            //transform.LookAt(otherCollider.transform.position);
                            if (col.gameObject.transform.position != null)
                            {
                                nearestEnemyFact = col.gameObject.transform;
                                Vector3 directionToTarget = col.gameObject.transform.position - transform.position;
                                directionToTarget.y = 0; // Ignore vertical (Y) component

                                // Calculate the rotation needed to face the target
                                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

                                // Apply the Y-axis rotation to preserve the initial -90 degree rotation
                                targetRotation *= Quaternion.Euler(0, 90, 0);




                                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2f * Time.deltaTime);
                            }

                            tankStand1 = false;
                            // tankboxCheck = false;
                            //tankStand1 = true; 
                            notEnemy = true;

                            distanceToEnemy = Vector3.Distance(transform.position, col.gameObject.gameObject.transform.position);


                            if (distanceToEnemy > 0.9f)
                            {
                                //print("Enter3");
                                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, col.gameObject.transform.position, speed * Time.deltaTime);


                            }

                            if (distanceToEnemy < 0.9f)
                            {


                                if (_enemyHealthh1 > 0)
                                {
                                    print("Enter1111");

                                    gameObject.transform.position = gameObject.transform.position;


                                }


                            }


                        }
                    }
                }
            }


            //enemy1 = otherCollider.gameObject;
            if (_enemyHealthh1 <= 0 && notEnemy == true /*&& otherCollider != null && otherCollider.gameObject != null && otherCollider.gameObject.tag != "enemy"*/)
            {
                tankboxCheck = false;
                //playerboxCheck = false;
                //pos1 = false;
                {
                    // print("Hello1111");
                    //transform.LookAt(targetPosition);
                    {
                        pos1 = true;

                        nearestEnemyFact = nearest;

                        // Move towards the nearest enemy if one is found
                        if (nearestEnemyFact != null)
                        {
                            //pos1 = true;
                            //print("Hello2");
                            targetPosition = nearestEnemyFact.position;
                            if (targetPosition != null)
                            {
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
                            //targetPosition = targetPosition + new Vector3(0, 0.436f, 0);
                            //if (pos1 == false && Spawnlist.spawnedObjects.Count > 0)
                            {
                                //transform.LookAt(targetPosition);
                                //print("Hello3");
                                //Spawnlist.spawnedObjects[0].transform.position = Vector3.MoveTowards(Spawnlist.spawnedObjects[0].transform.position, targetPosition, speed * Time.deltaTime);
                                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, speed * Time.deltaTime);



                            }
                        }
                    }
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


            }
        }




    }
    //IEnumerator SpawnAndMoveRe()
    //{
    //    tankSpawner respawn = GameObject.FindObjectOfType<tankSpawner>();
    //    yield return new WaitForSeconds(10f);
    //    respawn.one1 = true;
    //}
    void inRadius()
    {
        //print("1");
        if (centerPoint != null)
        {
            print("1");
            // Find all colliders within the specified radius of the centerPoint
            colliderrs = Physics.OverlapSphere(centerPoint.position, radius);
            print("2s");
            // Check if any colliders are found
            if (colliderrs.Length > 0)
            {
                print("3");
                foreach (Collider col in colliderrs)
                {
                    print("11");
                    // Check if the collider is attached to a GameObject
                    if (col.gameObject != null)
                    {
                        print("12");
                        if (col.gameObject.layer == LayerMask.NameToLayer("playerNotMerge") || col.gameObject.layer == LayerMask.NameToLayer("playerFact"))
                        {
                           
                            //tankStand1 = true;
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
                            enemyhealth enemyHealthComponent = col.gameObject.GetComponentInChildren<enemyhealth>();
                            if (enemyHealthComponent != null)
                            {
                                _enemyHealthh1 = enemyHealthComponent.health;

                            }
                            // You can perform any other actions here for "enemy" objects
                        }
                        else if (col.gameObject.layer != LayerMask.NameToLayer("playerNotMerge"))
                        {
                            
                            //radiusCheck = false;
                            // CancelInvoke("SpawnAndMove1");

                        }
                    }
                }
            }
        }
    }
    
    //private void OnTriggerEnter(Collider other)
    //{
    //    //pos1 = false;pos2 = false;pos3 = false;
    //    //this.otherCollider = other;
    //    //if (other.gameObject.tag == "tank")
    //    //{
    //    //    print(other.gameObject.name);
    //    //}
    //    //if (other.gameObject.tag == "enemy")
    //    //{
    //    //    //pos1 = false;
    //    //    ////pos1 = false;
    //    //    //print("UPP");
    //    //    //InvokeRepeating("SpawnAndMove1", 0f, 3f);
    //    //    //print("Down");
    //    //    //StartCoroutine(WaitForSeconds());
    //    //    // rb1 = gameObject.GetComponent<Rigidbody>();
    //    //    //else if (rb != null && rb.isKinematic == false)
    //    //    //{
    //    //    //    rb.isKinematic = true;
    //    //    //}
    //    //}
    //    //if (other.gameObject.tag == "tankcoll")
    //    //{

    //    //    //print("yes true");
    //    //    //pos1 = false;
    //    //    //if(anim != null)
    //    //    //{
    //    //    //   // print("yes true1");
    //    //    //    anim.SetBool("idle", true);
              
    //    //    //}
    //    //    posi1 = false;
            
    //    //}
       
    //    else if (other.gameObject.tag == "enemy")
    //    {
           
    //        //if (anim != null)
    //        //{
    //        //    anim.SetBool("fire", true);
    //        //}
    //    }
        

        
    //}
    //private IEnumerator WaitForSeconds()
    //{

    //    yield return new WaitForSeconds(2f);

    //    if (rb1 != null && rb1.isKinematic == true)
    //    {
    //        rb1.isKinematic = false;
    //    }
    //}
    private void OnTriggerExit(Collider other)
    {
        //if (rb1 != null && rb1.isKinematic == false)
        //{
        //    rb1.isKinematic = true;
        //}
        //if (other.gameObject.tag != "tankcoll")
        //{
        //   // pos1 = true;
        //    //if (anim != null)
        //    //{
        //    //    anim.SetBool("idle", false);
        //    //    //print("yes false");
        //    //}
        //    posi1 = true;

        //}
       
        //if (other.gameObject.tag != "enemy")
        //{
        //    //playerStand1 = false;
        //    // playerboxCheck = true;
        //    //pos1 = true;
        //    //if (anim != null)
        //    //{
        //    //    anim.SetBool("fire", false);
        //    //}
        //}
       
        //if (other.gameObject.tag != "enemy")
        //{
        //    //CancelInvoke("SpawnAndMove1");

        //}
    }
    private void OnTriggerStay(Collider other)
    {
        this.othercollider1 = other;
        //if (other.gameObject.tag == "enemy")
        //{

        //    //enemyhealth enemyHealthComponent = other.gameObject.GetComponentInChildren<enemyhealth>();
        //    //if (enemyHealthComponent != null)
        //    //{
        //    //    _enemyHealthh1 = enemyHealthComponent.health;

        //    //}

        //}
        /////////////////
       
    }
    //IEnumerator MyCoroutine()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    //InvokeRepeating("SpawnAndMove", 1f, 15f);
       
    //}
    private void SpawnAndMove1()
    {
        print("Functionnin");
        //StartCoroutine(MyCoroutine());
        if (GolSpawnPos != null && radiusCheck == true )
        {
            if (colliderrs.Length > 0)
            {
                foreach (Collider col in colliderrs)
                {
                    // Check if the collider is attached to a GameObject
                    if (col.gameObject != null && col.gameObject.layer == LayerMask.NameToLayer("playerNotMerge") || col.gameObject.layer == LayerMask.NameToLayer("playerFact"))
                    {
                        print("ifin");
                        GameObject builtSpawns = Instantiate(GollSpawn, GolSpawnPos.transform.position, GollSpawn.transform.rotation);
                        Rigidbody rb = builtSpawns.GetComponent<Rigidbody>();

                        Vector3 velocity = (col.gameObject.transform.position - GolSpawnPos.transform.position).normalized * 1.5f;
                        // builtSpawns.transform.LookAt(otherCollider.gameObject.transform.position);
                        rb.velocity = velocity;
                        radiusCheck = false;
                        StartCoroutine("SpawnAndMove");
                    }

                }
            }
        }
    }
    IEnumerator SpawnAndMove()
    {
        yield return new WaitForSeconds(0.7f);
        radiusCheck = true;
    }
}
