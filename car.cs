using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class car : MonoBehaviour
{
    public Vector3 hitPoint;
    public bool carboxCheck, pos1, notEnemy;
    public Transform target1, target2, target3;
    public float speed = 0.35f;
    public carSpawner1 Spawnlist; public List<GameObject> spawnlist_1;
    public TargetFacts SpawnFactlist; public List<GameObject> spawnFactlist_1;
    public TargetFacts TransFactlist; public List<Transform> TransFactlist_1;
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
    public Vector3 targetPosition,  targetPosition1;
    public Animator anim;
    public Collider[] nearbyColliders;
    public bool posi1, carStand1;
    public RaycastHit hit;
    public Rigidbody rb1;
    public bool tankCheck1, playerCheck1, radiusCheck, newCheck, gotoFacts, gotoFact;
    public tank tankCheck;
    public player playerCheck;
    public int item_1, saveitem_1;
    public Transform centerPoint; // The point from which to check the radius
    public float radius; bool isSpawning = false;
    public Collider[] colliders;
    private void Start()
    {
        playerHealth = 100f;
        // StartCoroutine("FindTargetsWithDelay", .2f);
        //target1.transform.position = new Vector3(0.9459355f, 0.183f, -1.407188f);
        //InvokeRepeating("inRadius", 0f, 0f);
        //StartCoroutine(RunInRadiusRepeatedly());
        pos1 = true;
        radiusCheck = true;
        rb = GetComponent<Rigidbody>();
        //tankboxCheck = false;
        // tankStand1 = false;
        DirFromAngle(0.9f);
    }
    //IEnumerator RunInRadiusRepeatedly()
    //{
    //    //while (true)
    //    {
    //        inRadius(); // Call your function

    //        yield return new WaitForSeconds(0f); // Wait for 1.8 seconds before the next iteration
    //    }
    //}


    public Vector3 DirFromAngle(float angleInDegrees)
    {
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));

    }
    private void FixedUpdate()
    {
        inRadius();
    }
    void Update()
    {


        playerSelector itemno1 = GameObject.FindObjectOfType<playerSelector>();
        item_1 = itemno1.itemNo1;
        saveitem_1 = itemno1.saveitem1;
        spawnmanager1 playerStand = gameObject.GetComponentInChildren<spawnmanager1>();
        //if (playerStand != null)
        //{
        //    tankStand1 = playerStand.checkTankMove;

        //}
        Spawnlist = GameObject.FindObjectOfType<carSpawner1>();
        if(Spawnlist !=null)
        {
            spawnlist_1 = Spawnlist.spawnedCar1;
        }
       
        SpawnFactlist = GameObject.FindObjectOfType<TargetFacts>();
        spawnFactlist_1 = SpawnFactlist.spawnedFacts;
        TransFactlist = Transform.FindObjectOfType<TargetFacts>();
        TransFactlist_1 = TransFactlist.Factenemies;
        //if(spawnFactlist_1.Count == 0)
        //{
        //    if (anim != null)
        //    {
        //        anim.SetBool("idle", true);
        //        anim.SetBool("fire", false);
        //    }
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

                Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
                if (hit.collider.CompareTag("carpoint"))
                {
                    carboxCheck = true;



                }
                if (hit.collider != null && !hit.collider.CompareTag("Cannonpoint") && !hit.collider.CompareTag("jetpoint") && !hit.collider.CompareTag("tankpoint") && !hit.collider.CompareTag("Playerpoint") && !hit.collider.CompareTag("tankpoint") && !hit.collider.CompareTag("carpoint") && carboxCheck == true)
                {
                    if (carboxCheck == true)
                    {



                        //for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
                        //{
                        //    if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 1)
                        //    {


                        //        StartCoroutine(SpawnAndMoveRe());
                        //        break; // Assuming you want to break out of the loop once the condition is met for one element.
                        //    }
                        //}
                        carStand1 = true;
                    }
                    for (int j = 0; j < playerSelector.inst.selectedweapon.Length; j++)
                    {
                        if (playerSelector.inst.selectedweapon[j].GetComponent<upGridImg>().currentIndex == 1)
                        {
                            for (int i = 0; i < spawnlist_1.Count;)
                            {
                                if (carboxCheck == true)
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

                    if (hitPoint == Vector3.zero && carboxCheck == true)
                    {
                        carboxCheck = false;

                        hitPoint = hit.point;
                        // colliderSpawn = Instantiate(CollSpawn, hitPoint, CollSpawn.transform.rotation);
                        // hitPoint = hitPoint + new Vector3(0, 0.11799997f, 0);
                        //tankboxCheck = false;

                        // move = true;

                        if (hit.collider != null && !hit.collider.CompareTag("ground"))
                        {
                            hitPoint = hitPoint - new Vector3(0, 0.65f, 0);
                        }
                        else
                        {
                            hitPoint = hitPoint + new Vector3(0, 0.15f, 0);
                        }
                        newCheck = true;
                    }



                }
                if (hit.collider != null && (hit.collider.CompareTag("tankpoint") || hit.collider.CompareTag("Playerpoint") || hit.collider.CompareTag("jetpoint") || hit.collider.CompareTag("Cannonpoint")))
                {
                    carboxCheck = false;
                }
            }
            
        }

        if (carStand1 == true && hit.collider != null && !hit.collider.CompareTag("carpoint"))
        {

            carboxCheck = false;
            // print("hellooo");
            Vector3 currentPosition1 = gameObject.transform.position;

            // Calculate the target position with the same y-coordinate as the current position
             targetPosition1 = new Vector3(hitPoint.x, currentPosition1.y, hitPoint.z);

            // Move the GameObject towards the target position
            gameObject.transform.position = Vector3.MoveTowards(currentPosition1, targetPosition1, speed * Time.deltaTime);
           // gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, hitPoint, speed);
            //transform.LookAt(targetPosition);

            // playerMove.Remove(gameObject);
            if (hitPoint != null)
            {
                Vector3 directionToTarget = hitPoint - transform.position;
                directionToTarget.y = 0; // Ignore vertical (Y) component

                // Calculate the rotation needed to face the target
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

                // Apply the Y-axis rotation to preserve the initial -90 degree rotation
                targetRotation *= Quaternion.Euler(0, -90, 0);



                // Rotate the object towards the target
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2f * Time.deltaTime);
            }
        }

        //if (Spawnlist.spawnedObjects.Count > 0)
        {
            for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
            {
                if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 1)
                {
                    if (pos1 == true && spawnlist_1.Count > 0)
                    {
                        switch (i)
                        {
                            case 0:
                                spawnlist_1[0].transform.position = Vector3.MoveTowards(spawnlist_1[0].transform.position, target1.position, speed * Time.deltaTime);
                                break;
                            case 1:
                                spawnlist_1[0].transform.position = Vector3.MoveTowards(spawnlist_1[0].transform.position, target2.position, speed * Time.deltaTime);
                                break;
                            case 2:
                                spawnlist_1[0].transform.position = Vector3.MoveTowards(spawnlist_1[0].transform.position, target3.position, speed * Time.deltaTime);
                                break;
                        }
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

                    newPosition = transform.position + avoidanceDirection.normalized * speed;

                    // Restore the original Y position
                    newPosition.y = originalY;

                    transform.position = newPosition;
                }
            }
        }




        // if (Spawnlist != null)
        {
            if (gameObject.transform.position == targetPosition1)
            {
                print("Hellooo!");
                carStand1 = false;

                notEnemy = true;
                nearestEnemyFact = nearest;
                pos1 = true;

                //transform.LookAt(targetPosition);
                if (nearestEnemyFact != null && otherCollider != null && otherCollider.gameObject.tag != "inenemy")
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
                            targetRotation *= Quaternion.Euler(0, -90, 0);



                            // Rotate the object towards the target
                            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2f * Time.deltaTime);
                        }

                        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, speed*Time.deltaTime);


                    }
                }

            }


            if (otherCollider != null && otherCollider.gameObject.tag != "enemy")
            {
                //CancelInvoke("SpawnAndMove1");
            }

           // if (otherCollider != null && otherCollider.gameObject.tag == "inenemy")
                if (colliders.Length > 0)
                {
                    foreach (Collider col in colliders)
                    {
                        // Check if the collider is attached to a GameObject
                        if (col != null && col.gameObject != null)
                        {
                            if (col.gameObject.layer == LayerMask.NameToLayer("Enemmy") || col.gameObject.layer == LayerMask.NameToLayer("EnemyFact"))

                            {

                                print("Enter2");
                                //transform.LookAt(otherCollider.transform.position);
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

                                carStand1 = false;
                                // tankboxCheck = false;
                                //tankStand1 = true; 
                                notEnemy = true;

                                distanceToEnemy = Vector3.Distance(transform.position, col.gameObject.gameObject.transform.position);


                                if (distanceToEnemy > 0.8f)
                                {
                                    //print("Enter3");
                                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, col.gameObject.transform.position, speed*Time.deltaTime);


                                }

                                if (distanceToEnemy < 0.8f)
                                {
                                   // print("Enter1");

                                    if (_enemyHealthh1 > 0)
                                    {

                                        gameObject.transform.position = gameObject.transform.position;


                                    }


                                }


                            }
                        }
                    }
                }

            if ( _enemyHealthh1 <= 0 && notEnemy == true)
            {
                carboxCheck = false;
                
                {
                   
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
                                targetRotation *= Quaternion.Euler(0, -90, 0);



                                // Rotate the object towards the target
                                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2f * Time.deltaTime);
                            }
                           
                            {
                                
                                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, speed*Time.deltaTime);

                                

                            }
                        }
                    }
                }


            }
        }

        if (gotoFacts == true)
        {
            print("goto1");
            carStand1 = false;
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
    //    carSpawner1 respawn = GameObject.FindObjectOfType<carSpawner1>();
    //    yield return new WaitForSeconds(8f);
    //    respawn.one2 = true;
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
                            carStand1 = true;
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
                            enemyhealth enemyHealthComponent = col.gameObject.GetComponentInChildren<enemyhealth>();
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
    IEnumerator SpawnAndMoveRepeatedly()
    {
        //while (true) // Infinite loop to keep the function running
        {
            yield return new WaitForSeconds(3f);
           // radiusCheck = true;

            SpawnAndMove1(); // Call your function

            // Wait for 1.8 seconds before the next iteration
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //pos1 = false;pos2 = false;pos3 = false;
        this.otherCollider = other;
        if (other.gameObject.tag == "enemy")
        {
            
            //pos1 = false;
            ////pos1 = false;
            //InvokeRepeating("SpawnAndMove1", 0f, 1.8f);

            //StartCoroutine(WaitForSeconds());
            // rb1 = gameObject.GetComponent<Rigidbody>();
            //else if (rb != null && rb.isKinematic == false)
            //{
            //    rb.isKinematic = true;
            //}
        }
        if (other.gameObject.tag == "carcoll")
        {

            //print("yes true");
            //pos1 = false;
            //if(anim != null)
            //{
            //   // print("yes true1");
            //    anim.SetBool("idle", true);
              
            //}
            posi1 = false;
            
        }
       
        else if (other.gameObject.tag == "enemy")
        {
           
            //if (anim != null)
            //{
            //    anim.SetBool("fire", true);
            //}
        }
        

        
    }
    private IEnumerator WaitForSeconds()
    {

        yield return new WaitForSeconds(2f);

        if (rb1 != null && rb1.isKinematic == true)
        {
            rb1.isKinematic = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //if (rb1 != null && rb1.isKinematic == false)
        //{
        //    rb1.isKinematic = true;
        //}
        if (other.gameObject.tag != "carcoll")
        {
           // pos1 = true;
            //if (anim != null)
            //{
            //    anim.SetBool("idle", false);
            //    //print("yes false");
            //}
            posi1 = true;

        }
       
        if (other.gameObject.tag != "enemy")
        {
            //playerStand1 = false;
            // playerboxCheck = true;
            //pos1 = true;
            //if (anim != null)
            //{
            //    anim.SetBool("fire", false);
            //}
        }
       
        //if (other.gameObject.tag != "enemy")
        //{
        //    CancelInvoke("SpawnAndMove1");

        //}
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "enemy")
    //    {
    //        inRadius();
    //    }
    //}
    private void OnTriggerStay(Collider other)
    {
        this.othercollider1 = other;
        if (other.gameObject.tag == "enemy")
        {
            //inRadius();
            //InvokeRepeating("SpawnAndMove", 0f, 3f);
            //enemyhealth enemyHealthComponent = other.gameObject.GetComponentInChildren<enemyhealth>();
            //if (enemyHealthComponent != null)
            //{
            //    _enemyHealthh1 = enemyHealthComponent.health;

            //}

        }
       


    }
    //IEnumerator MyCoroutine()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    //InvokeRepeating("SpawnAndMove", 1f, 15f);
       
    //}
     void SpawnAndMove1()
    {
        //print("Hit12");
        //StartCoroutine(MyCoroutine());
        if (/*otherCollider != null  &&*/ GolSpawnPos != null && radiusCheck == true)
        {
            if (colliders.Length > 0)
            {
                foreach (Collider col in colliders)
                {
                    // Check if the collider is attached to a GameObject
                    if (col.gameObject != null && col.gameObject.layer == LayerMask.NameToLayer("Enemmy") || col.gameObject.layer == LayerMask.NameToLayer("EnemyFact")) 
                    {
                       // print("Hit13");
                        GameObject builtSpawns = Instantiate(GollSpawn, GolSpawnPos.transform.position, GollSpawn.transform.rotation);
                        Rigidbody rb = builtSpawns.GetComponent<Rigidbody>();
                        Vector3 velocity = (col.gameObject.transform.position - GolSpawnPos.transform.position).normalized * 1.5f;
                        rb.velocity = velocity;
                        radiusCheck = false;
                        StartCoroutine("SpawnAndMove");
                    }
                } 
            }
           
            //radiusCheck = false;
            // print("yesEnterto");
        }
        
    }
    IEnumerator SpawnAndMove()
    {
        yield return new WaitForSeconds(2f);
        radiusCheck = true;
    }
}
