using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Cannon : MonoBehaviour
{
    public Vector3 hitPoint;
    public bool cannonboxCheck,pos1,notEnemy;
    public Transform target1, target2, target3;
    public float speed = 0.006f;
    public cannonSpawner Spawnlist; public List<GameObject> spawnlist_1;
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
    public float _enemyHealthh1,cannonHealth;
    public enemyhealth enemyHealthComponent;
    public Vector3 targetPosition;
    public Animator anim;
    public Collider[] nearbyColliders;
    public bool posi1, CannonStand1;
    public RaycastHit hit;
    public Rigidbody rb1;
    public bool carCheck1, playerCheck1, radiusCheck;
    public car carCheck;
    public player playerCheck;
    public bool isMoving;
    public GameObject newProjectile;
    
    private void Start()
    {
        cannonHealth = 100f;
        // StartCoroutine("FindTargetsWithDelay", .2f);
        //target1.transform.position = new Vector3(0.9459355f, 0.183f, -1.407188f);
      
        pos1 = true;
        radiusCheck = true;
        rb = GetComponent<Rigidbody>();
        //tankboxCheck = false;
       // tankStand1 = false;

    }
   

 
    public Vector3 DirFromAngle(float angleInDegrees)
    {
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    
    }
    //private void FixedUpdate()
    //{
    //    inRadius();
    //}
    void Update()
    {
        spawnmanager1 playerStand = gameObject.GetComponentInChildren<spawnmanager1>();
        //if (playerStand != null)
        //{
        //    tankStand1 = playerStand.checkTankMove;

        //}
        Spawnlist = GameObject.FindObjectOfType<cannonSpawner>();
        spawnlist_1 = Spawnlist.spawnedCannon1;
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
        if(health1 != null)
        {
            _health = health1.health;
        }
       
        if (Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

           
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
                if (hit.collider.CompareTag("Cannonpoint"))
                {
                    cannonboxCheck = true;
                    hitPoint = Vector3.zero;

                    print("true");
                   // playerStand1 = false;


                }
                if (hit.collider != null && !hit.collider.CompareTag("Cannonpoint") && !hit.collider.CompareTag("jetpoint") && !hit.collider.CompareTag("tankpoint") && !hit.collider.CompareTag("Playerpoint") && !hit.collider.CompareTag("tankpoint") && !hit.collider.CompareTag("carpoint") && cannonboxCheck == true)
                {

                    if (cannonboxCheck == true)
                    {

                        //for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
                        //{
                        //    if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 1)
                        //    {


                        //        StartCoroutine(SpawnAndMoveRe());
                        //        break; // Assuming you want to break out of the loop once the condition is met for one element.
                        //    }
                        //}
                        CannonStand1 = true;
                        print("yessss");
                    }
                    //for (int j = 0; j < playerSelector.inst.selectedweapon.Length; j++)
                    //{
                    //    if (playerSelector.inst.selectedweapon[j].GetComponent<upGridImg>().currentIndex == 3)
                    //    {
                    //        for (int i = 0; i < spawnlist_1.Count;)
                    //        {
                    //            if (cannonboxCheck == true)
                    //            {
                    //                playerMove.Add(spawnlist_1[i]);
                    //                spawnlist_1.RemoveAt(i);
                    //            }
                    //            else
                    //            {
                    //                i++;
                    //            }
                    //        }
                    //    }
                    //}
                    //for (int i = 0; i < spawnlist_1.Count;)
                    //{
                    //    if (tankboxCheck == true)
                    //    {

                    //        playerMove.Add(spawnlist_1[i]);
                    //        spawnlist_1.RemoveAt(i);
                    //    }
                    //    else
                    //    {
                    //        i++;
                    //    }

                    //}
                    if (hitPoint == Vector3.zero && cannonboxCheck == true)
                    {

                        print("whit");
                        hitPoint = hit.point;
                       // colliderSpawn = Instantiate(CollSpawn, hitPoint, CollSpawn.transform.rotation);
                       // hitPoint = hitPoint + new Vector3(0, 0.11799997f, 0);
                        //tankboxCheck = false;
                        
                       // move = true;
                       
                      if(hit.collider != null && !hit.collider.CompareTag("ground"))
                        {
                           // hitPoint = hitPoint - new Vector3(0, 0.65f, 0);
                        }
                        else
                        {
                            //hitPoint = hitPoint + new Vector3(0, 0.15f, 0);
                        }
                        
                    }
                                        
                  

                }
                if (hit.collider != null && (hit.collider.CompareTag("Playerpoint") || hit.collider.CompareTag("jetpoint") || hit.collider.CompareTag("tankpoint") || hit.collider.CompareTag("carpoint")))
                {
                    cannonboxCheck = false;
                }
            }
        }
       
        if (CannonStand1 == true )
        {
           // if ( GolSpawnPos != null)
            {
                
                Vector3 directionToTarget = (hitPoint - GolSpawnPos.transform.position);

                // Instantiate the projectile
                GameObject newProjectile = Instantiate(GollSpawn, GolSpawnPos.transform.position, GollSpawn.transform.rotation);
                Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
                //Vector3 velocity = directionToTarget * speed;
                // Set the velocity based on the direction to the target
                if (hit.collider != null && hit.collider.CompareTag("ground"))
                {

                rb.velocity = new Vector3(directionToTarget.x, 5, directionToTarget.z);
                }
                else
                {
                    rb.velocity = new Vector3(directionToTarget.x, 5, (directionToTarget.z+0.3f));

                }



             

                CannonStand1 = false;
                cannonboxCheck = false;
                // print("yesEnterto");
            }
           
        }
           
        //if (Spawnlist.spawnedObjects.Count > 0)
        {
            
            //if(pos1 == true && Spawnlist.spawnedCannon1.Count > 0)
            //{
            //    Spawnlist.spawnedCannon1[0].transform.position = Vector3.MoveTowards(Spawnlist.spawnedCannon1[0].transform.position, target1.position, speed /** Time.deltaTime*/);
                

            //}
            for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
            {
                if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 3)
                {
                    if (pos1 == true && spawnlist_1.Count > 0)
                    {
                        switch (i)
                        {
                            case 0:
                                spawnlist_1[0].transform.position = Vector3.MoveTowards(spawnlist_1[0].transform.position, target1.position, speed /** Time.deltaTime*/);
                                break;
                            case 1:
                                spawnlist_1[0].transform.position = Vector3.MoveTowards(spawnlist_1[0].transform.position, target2.position, speed /** Time.deltaTime*/);
                                break;
                            case 2:
                                spawnlist_1[0].transform.position = Vector3.MoveTowards(spawnlist_1[0].transform.position, target3.position, speed /** Time.deltaTime*/);
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
           
            //if (playerMove != null && playerMove.Count >= 3)
            


              

            

            if (otherCollider != null && otherCollider.gameObject.tag == "inenemy")
            {
                //transform.LookAt(otherCollider.transform.Find("enemy").position);
               // transform.LookAt(targetPosition);
                print("Enter2");
                //if (otherCollider.transform.position != null)
                //{
                //    Vector3 directionToTarget = otherCollider.transform.position - transform.position;
                //    directionToTarget.y = 0; // Ignore vertical (Y) component

                //    // Calculate the rotation needed to face the target
                //    Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

                //    // Apply the Y-axis rotation to preserve the initial -90 degree rotation
                //    targetRotation *= Quaternion.Euler(0, 90, 0);



                //    // Rotate the object towards the target
                //    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2f * Time.deltaTime);
                //}
                //transform.LookAt(otherCollider.transform.position);
                //Destroy(colliderSpawn, 2f);
                CannonStand1 = false;
                // tankboxCheck = false;
                //tankStand1 = true; 
                notEnemy = true;
                //playerboxCheck = true;
                //pos1 = false;
                //distanceToEnemy = Vector3.Distance(transform.position, otherCollider.gameObject.transform.position);
               
               
                //if (distanceToEnemy > 0.9f)
                //{
                //    print("Enter3");
                //    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, otherCollider.transform.position, speed );
                //   // transform.LookAt(otherCollider.transform.Find("enemy").position);

                //}

                //if (distanceToEnemy < 0.9f)
                //{
                //    print("Enter1");
                //   // transform.LookAt(otherCollider.transform.position);
                //    if (_enemyHealthh1 > 0)
                //    {
                //        // print("yesEnter");
                //        gameObject.transform.position =gameObject.transform.position;

                //        //transform.LookAt(target1.position);
                //    }


                //    // Destroy(otherCollider.gameObject, 5f);

                //    //enemydestroy = true;
                //}


            }

            //enemy1 = otherCollider.gameObject;
            //if ( _enemyHealthh1 <= 0 && notEnemy == true /*&& otherCollider != null && otherCollider.gameObject != null && otherCollider.gameObject.tag != "enemy"*/)
            //{
            //    tankboxCheck = false;
            //    //playerboxCheck = false;
            //    //pos1 = false;
            //    {
            //        // print("Hello1111");
            //        //transform.LookAt(targetPosition);
            //        {
            //            pos1 = true; 

            //            nearestEnemyFact = nearest;

            //            // Move towards the nearest enemy if one is found
            //            if (nearestEnemyFact != null)
            //            {
            //                //pos1 = true;
            //                //print("Hello2");
            //                targetPosition = nearestEnemyFact.position;
            //                if (targetPosition != null)
            //                {
            //                    Vector3 directionToTarget = targetPosition - transform.position;
            //                    directionToTarget.y = 0; // Ignore vertical (Y) component

            //                    // Calculate the rotation needed to face the target
            //                    Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            //                    // Apply the Y-axis rotation to preserve the initial -90 degree rotation
            //                    targetRotation *= Quaternion.Euler(0, 90, 0);



            //                    // Rotate the object towards the target
            //                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2f * Time.deltaTime);
            //                }
            //                //transform.LookAt(targetPosition);
            //                //targetPosition = targetPosition + new Vector3(0, 0.436f, 0);
            //                //if (pos1 == false && Spawnlist.spawnedObjects.Count > 0)
            //                {
            //                    //transform.LookAt(targetPosition);
            //                    //print("Hello3");
            //                    //Spawnlist.spawnedObjects[0].transform.position = Vector3.MoveTowards(Spawnlist.spawnedObjects[0].transform.position, targetPosition, speed * Time.deltaTime);
            //                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, speed);

                                

            //                }
            //            }
            //        }
            //    }


            //}
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
                if (cannonHealth > 0)
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
    //    cannonSpawner respawn = GameObject.FindObjectOfType<cannonSpawner>();
    //    yield return new WaitForSeconds(2f);
    //    respawn.one4 = true;
    //}
    //void inRadius()
    //{
    //    if (centerPoint != null)
    //    {
    //        // Find all colliders within the specified radius of the centerPoint
    //        colliders = Physics.OverlapSphere(centerPoint.position, radius);

    //        // Check if any colliders are found
    //        if (colliders.Length > 0)
    //        {
    //            foreach (Collider col in colliders)
    //            {
    //                // Check if the collider is attached to a GameObject
    //                if (col.gameObject != null)
    //                {
    //                    if (col.gameObject.layer == LayerMask.NameToLayer("Enemmy"))
    //                    {
    //                        //radiusCheck = true;
    //                        Debug.Log(col.gameObject.name + " is within the radius.");
    //                        pos1 = false;
    //                        //pos1 = false;
    //                        //StartCoroutine(SpawnAndMoveRepeatedly());
    //                        //if (radiusCheck == true)
    //                        //{
    //                        SpawnAndMove1();

    //                        //}

    //                        //InvokeRepeating("SpawnAndMove1", 0f, 1.8f);


    //                        //InvokeRepeating("SpawnAndMove1", 0f, 1.8f);
    //                        // print("Hit11");
    //                        enemyhealth enemyHealthComponent = col.gameObject.GetComponentInChildren<enemyhealth>();
    //                        if (enemyHealthComponent != null)
    //                        {
    //                            _enemyHealthh1 = enemyHealthComponent.health;

    //                        }
    //                        // You can perform any other actions here for "enemy" objects
    //                    }
    //                    else if (col.gameObject.layer != LayerMask.NameToLayer("Enemmy"))
    //                    {
    //                        //radiusCheck = false;
    //                        // CancelInvoke("SpawnAndMove1");

    //                    }
    //                }
    //            }
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        //pos1 = false;pos2 = false;pos3 = false;
        this.otherCollider = other;
        if (other.gameObject.tag == "enemy")
        {
            pos1 = false;
            //pos1 = false;
           // InvokeRepeating("SpawnAndMove1", 0f, 1f);
            
            //StartCoroutine(WaitForSeconds());
            // rb1 = gameObject.GetComponent<Rigidbody>();
            //else if (rb != null && rb.isKinematic == false)
            //{
            //    rb.isKinematic = true;
            //}
        }
        if (other.gameObject.tag == "cannoncoll")
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

        //if (rb1 != null && rb1.isKinematic == true)
        //{
        //    rb1.isKinematic = false;
        //}
    }
    private void OnTriggerExit(Collider other)
    {
        //if (rb1 != null && rb1.isKinematic == false)
        //{
        //    rb1.isKinematic = true;
        //}
        if (other.gameObject.tag != "cannoncoll")
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
       
        if (other.gameObject.tag != "enemy")
        {
          //  CancelInvoke("SpawnAndMove1");

        }
    }
    private void OnTriggerStay(Collider other)
    {
        this.othercollider1 = other;
        if (other.gameObject.tag == "enemy")
        {
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
    void FireProjectile()
    {
        // Calculate the direction vector to the target
        Vector3 directionToTarget = hitPoint - GolSpawnPos.position;

        // Instantiate the projectile
        newProjectile = Instantiate(GollSpawn, GolSpawnPos.position, GollSpawn.transform.rotation);

        // Set the projectile's position to the cannon's position
        newProjectile.transform.position = GolSpawnPos.position;

        // Start moving the projectile
        isMoving = true;
    }
}
