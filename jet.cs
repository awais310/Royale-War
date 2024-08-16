using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class jet : MonoBehaviour
{
    public Vector3 hitPoint;
    public bool jetboxCheck, pos1, notEnemy;
    public Transform target1, target2, target3;
    public float speed = 0.006f;
    public jetSpawner1 Spawnlist; public List<GameObject> spawnlist_1;
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
    public Vector3 targetPosition;
    public Animator anim;
    public Collider[] nearbyColliders;
    public bool posi1, jetStand1, radiusCheck;
    public RaycastHit hit;
    public Rigidbody rb1;
    public bool jetCheck1, playerCheck1, rec;
    public tank tankCheck;
    public player playerCheck;
    public Vector3 direction;
    public Collider[] colliders; public Transform centerPoint; public float radius;
    //public Vector3 direction1 = Vector3.forward; 
    private void Start()
    {
        playerHealth = 100f;
        // StartCoroutine("FindTargetsWithDelay", .2f);
        //target1.transform.position = new Vector3(0.9459355f, 0.183f, -1.407188f);
        rb = GetComponent<Rigidbody>();
        //rb.velocity = Vector3.forward * 5f;
        pos1 = true;
        rec = true;
        radiusCheck = true;
        // rb = GetComponent<Rigidbody>();
        //tankboxCheck = false;
        // tankStand1 = false;

    }



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


        spawnmanager1 playerStand = gameObject.GetComponentInChildren<spawnmanager1>();
        //if (playerStand != null)
        //{
        //    tankStand1 = playerStand.checkTankMove;

        //}
        //Spawnlist = GameObject.FindObjectOfType<jetSpawner1>();
        //spawnlist_1 = Spawnlist.spawnedJet1;
        Spawnlist = GameObject.FindObjectOfType<jetSpawner1>();
        if (Spawnlist != null)
        {
            spawnlist_1 = Spawnlist.spawnedJet1;
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
        if (rec == true)
        {
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



        health1 = GameObject.FindObjectOfType<factoryHealth>();
        if (health1 != null)
        {
            _health = health1.health;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
                if (hit.collider.CompareTag("jetpoint"))
                {
                    jetboxCheck = true;
                    jetCheck1 = true;
                    //jetSpawner1 respawn = GameObject.FindObjectOfType<jetSpawner1>();
                    //for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
                    //{
                    //    if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 4)
                    //    {
                    //        StartCoroutine(SpawnAndMoveRe());
                    //        break; // Assuming you want to break out of the loop once the condition is met for one element.
                    //    }
                    //}
                    nearestEnemyFact = nearest;
                    if (nearestEnemyFact != null)
                    {
                        targetPosition = nearestEnemyFact.position;
                    }

                    targetPosition += new Vector3(0, 1f, 0);
                    for (int i = 0; i < spawnlist_1.Count;)
                    {
                        if (jetboxCheck == true)
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
        }

        //for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
        //{
        //    if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 4)
        //    {
        //        print("jet not fly0");
        //        if (pos1 == true && spawnlist_1.Count > 0)
        //        {
        //            print("jet not fly");
        //            switch (i)
        //            {
        //                case 0:
        //                    print("jet not fly1");
        //                    spawnlist_1[0].transform.position = Vector3.MoveTowards(spawnlist_1[0].transform.position, target1.position, speed /** Time.deltaTime*/);
        //                    break;
        //                case 1:
        //                    print("jet not fly2");
        //                    spawnlist_1[0].transform.position = Vector3.MoveTowards(spawnlist_1[0].transform.position, target2.position, speed /** Time.deltaTime*/);
        //                    break;
        //                case 2:
        //                    print("jet not fly3");
        //                    spawnlist_1[0].transform.position = Vector3.MoveTowards(spawnlist_1[0].transform.position, target3.position, speed /** Time.deltaTime*/);
        //                    break;
        //            }
        //        }
        //    }
        //}

        if (jetboxCheck == true)
        {

            // carboxCheck = false;
            // print("hellooo");
            //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, hitPoint, speed);
            //transform.LookAt(targetPosition);
            // public Vector3 direction = Vector3.forward; public Vector3 direction = Vector3.forward;
            if (transform.position != targetPosition && rec == true)
            {
                //direction = (targetPosition - transform.position).normalized;
                //transform.position = (transform.position + direction * 1f * Time.deltaTime);
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, 1f * Time.deltaTime);
            }
            else
            {
                rec = false;
                gameObject.transform.Translate(Vector3.down * Time.deltaTime);

            }
            //if ((otherCollider != null && otherCollider.gameObject.tag == "inenemy"))
            if (colliders.Length > 0)
            {
                foreach (Collider col in colliders)
                {
                    // Check if the collider is attached to a GameObject
                    if (col != null && col.gameObject != null)
                    {
                        if (col.gameObject.layer == LayerMask.NameToLayer("Enemmy"))
                        {
                            print("enny");
                            targetPosition = col.gameObject.transform.position;
                            targetPosition += new Vector3(0, 1f, 0);
                            Destroy(gameObject, 5f);

                        }
                    }
                }
            }



            // playerMove.Remove(gameObject);
            if (targetPosition != null && transform.position != targetPosition && rec == true)
            {
                print("yesreach");
                Vector3 directionToTarget = targetPosition - transform.position;
                directionToTarget.y = 0; // Ignore vertical (Y) component

                // Calculate the rotation needed to face the target
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

                // Apply the Y-axis rotation to preserve the initial -90 degree rotation
                targetRotation *= Quaternion.Euler(-90, 0, 0);

                //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position+ direction, targetPosition, 1f * Time.deltaTime);


                // Rotate the object towards the target
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 4f * Time.deltaTime);
            }
        }

        //if (Spawnlist.spawnedObjects.Count > 0)
        {

            //if(pos1 == true && Spawnlist.spawnedJet1.Count > 0)
            //{
            //    Spawnlist.spawnedJet1[0].transform.position = Vector3.MoveTowards(Spawnlist.spawnedJet1[0].transform.position, target1.position, speed /** Time.deltaTime*/);


            //}
            for (int i = 0; i < playerSelector.inst.selectedweapon.Length; i++)
            {
                if (playerSelector.inst.selectedweapon[i].GetComponent<upGridImg>().currentIndex == 4)
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



           

        }

       
        

        //nearest = null;
        //float minDistance = Mathf.Infinity;

        //foreach (Transform Factenemy in TransFactlist_1)
        //{
        //    if (Factenemy == null)
        //    {
        //        continue;
        //    }
        //    float distance = Vector3.Distance(transform.position, Factenemy.position);

        //    if (TransFactlist_1 != null)
        //    {
               
        //        if (playerHealth > 0)
        //        {
        //            if (distance < minDistance)
        //            {
        //                minDistance = distance;
        //                nearest = Factenemy;
        //            }
        //        }

                
        //    }
        //}

       


    }
    //IEnumerator SpawnAndMoveRe()
    //{
    //    jetSpawner1 respawn = GameObject.FindObjectOfType<jetSpawner1>();
    //    yield return new WaitForSeconds(12f);
    //    respawn.one5 = true;
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
                            //radiusCheck = true;
                            Debug.Log(col.gameObject.name + " is within the radius.");
                            pos1 = false;
                            //pos1 = false;
                            //StartCoroutine(SpawnAndMoveRepeatedly());
                            if (radiusCheck == true)
                            {
                                SpawnAndMove1();

                            }

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
                        else if (col.gameObject.layer != LayerMask.NameToLayer("Enemmy"))
                        {
                            //radiusCheck = false;
                            // CancelInvoke("SpawnAndMove1");

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
        //if (other.gameObject.tag == "enemy")
        //{
        //    //rec = false;
        //    //pos1 = false;
        //    //pos1 = false;
        //    if (otherCollider != null && GolSpawnPos != null && jetCheck1 == true)
        //    {
        //        GameObject builtSpawns = Instantiate(GollSpawn, GolSpawnPos.transform.position, GollSpawn.transform.rotation);
        //        Rigidbody rb = builtSpawns.GetComponent<Rigidbody>();
        //        Vector3 velocity = (otherCollider.gameObject.transform.position - GolSpawnPos.transform.position).normalized * 1.5f;
        //        rb.velocity = velocity;
        //        jetCheck1 = false;
        //        // print("yesEnterto");
        //    }

        //    //StartCoroutine(WaitForSeconds());
        //    // rb1 = gameObject.GetComponent<Rigidbody>();
        //    //else if (rb != null && rb.isKinematic == false)
        //    //{
        //    //    rb.isKinematic = true;
        //    //}
        //}
        if (other.gameObject.tag == "jetcoll")
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
   
    private void OnTriggerExit(Collider other)
    {
        //if (rb1 != null && rb1.isKinematic == false)
        //{
        //    rb1.isKinematic = true;
        //}
        if (other.gameObject.tag != "jetcoll")
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
           // CancelInvoke("SpawnAndMove1");

        }
    }
    private void OnTriggerStay(Collider other)
    {
        this.othercollider1 = other;
        //if (other.gameObject.tag == "enemy")
        //{
        //    //InvokeRepeating("SpawnAndMove", 0f, 3f);
        //    enemyhealth enemyHealthComponent = other.gameObject.GetComponentInChildren<enemyhealth>();
        //    if (enemyHealthComponent != null)
        //    {
        //        _enemyHealthh1 = enemyHealthComponent.health;

        //    }
            
        //}
       


    }
    //IEnumerator MyCoroutine()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    //InvokeRepeating("SpawnAndMove", 1f, 15f);

    //}
    private void SpawnAndMove1()
    {
        //StartCoroutine(MyCoroutine());
        if ( GolSpawnPos != null)
        {
            if (colliders.Length > 0)
            {
                foreach (Collider col in colliders)
                {
                    // Check if the collider is attached to a GameObject
                    if (col.gameObject != null && col.gameObject.layer == LayerMask.NameToLayer("Enemmy") || col.gameObject.layer == LayerMask.NameToLayer("EnemyFact"))
                    {
                        GameObject builtSpawns = Instantiate(GollSpawn, GolSpawnPos.transform.position, GollSpawn.transform.rotation);
                        Rigidbody rb = builtSpawns.GetComponent<Rigidbody>();
                        Vector3 velocity = (col.gameObject.transform.position - GolSpawnPos.transform.position).normalized * 1.5f;
                        rb.velocity = velocity;
                        radiusCheck = false;
                        // print("yesEnterto");
                    }
                }
            }
        }
    }
}
