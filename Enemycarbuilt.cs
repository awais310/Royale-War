using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycarbuilt : MonoBehaviour
{
    public float _enemyHealth;
    private Collider otherCollider1;
    public playerSelector SpawnFactlist; public List<GameObject> spawnFactlist_1;
    public Rigidbody rb;
    public player playerScript;
    public bool find;
    //public player[] gameObjectsArray1;
    //public tank[] gameObjectsArray2;
    //public car[] gameObjectsArray3;
    public ParticleSystem particleSystem;
    public Rigidbody rb1;
    // public player[] gameObjectsArray;

    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        ////if (otherCollider1 != null)
        ////{
        ////    Vector3 directionToTarget = otherCollider1.gameObject.transform.position - transform.position;
        ////    //directionToTarget.y = 0; // Ignore vertical (Y) component

        ////    // the rotation needed to face the target
        ////    Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        ////   // Apply the Y - axis rotation to preserve the initial - 90 degree rotation
        ////    targetRotation *= Quaternion.Euler(-90, 0, 0);



        ////    //Rotate the object towards the target
        ////    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2f * Time.deltaTime);
        ////}
        ////if (otherCollider1 != null)
        ////{
        ////    transform.LookAt(otherCollider1.transform);
        ////}
           
        SpawnFactlist = GameObject.FindObjectOfType<playerSelector>();
        spawnFactlist_1 = SpawnFactlist.ClonespawnedFactorys;
        //if (_enemyHealth <= 0)
        //{
        //    playerScript = GetComponent<player>();

        //    if (playerScript != null)
        //    {
        //        if (playerScript.rb1 != null)
        //        {
        //            playerScript.rb1.isKinematic = false;
        //            print("rbb");
        //        }
                
        //    }
           
        //}

    }
    //private void FixedUpdate()
    //{
    //    if (otherCollider1 != null && /*otherCollider1.gameObject != null &&*/ otherCollider1.gameObject.CompareTag("inenemy"))
    //    {
    //        print("hello1");
    //        enemyHealth.health -= 50;
    //        if (enemyHealth.health == 0)
    //        {
    //            print("hello2");
    //            Destroy(otherCollider1.transform.parent.gameObject);
    //        }

    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        this.otherCollider1 = other;
       
        if (other.gameObject.CompareTag("playerr") || other.gameObject.CompareTag("tank"))
        {
            //if (rb1 != null && rb1.isKinematic == true)
            //{
            //    rb1.isKinematic = false;
            //}
            //particleSystem.transform.position = other.gameObject.transform.position;
            particleSystem.Play();
            // other.gameObject.GetComponent<enemyhealth>().health -=5;
            //  enemyhealth enemy = other.gameObject.GetComponent<enemyhealth>();
            enemyhealth enemy = other.gameObject.GetComponent<enemyhealth>();
            if (enemy != null)
            {
                // Now, you can safely access the enemy's health
                enemy.health -= 20;
                _enemyHealth = enemy.health;
            }
           // _enemyHealth = other.gameObject.GetComponent<enemyhealth>().health;
            //if(_enemyHealth <= 0)
            //{
            //    print("hello221");
            //    gameObjectsArray1 = FindObjectsOfType<player>();
            //    for(var i =0; i< gameObjectsArray1.Length; i++)
            //    {
            //        //gameObjectsArray1[i].gameObject.GetComponent<CapsuleCollider>().enabled = false;
            //        gameObjectsArray1[i].gameObject.GetComponent<collOff>().collOn1();
            //    }
            //    gameObjectsArray2 = FindObjectsOfType<tank>();
            //    for (var i = 0; i < gameObjectsArray2.Length; i++)
            //    {
            //        //gameObjectsArray2[i].gameObject.GetComponent<CapsuleCollider>().enabled = false;
            //        gameObjectsArray2[i].gameObject.GetComponent<collOff>().collOn2();
            //    }
            //    gameObjectsArray3 = FindObjectsOfType<car>();
            //    for (var i = 0; i < gameObjectsArray3.Length; i++)
            //    {
            //        //gameObjectsArray3[i].gameObject.GetComponent<CapsuleCollider>().enabled = false;
            //        gameObjectsArray3[i].gameObject.GetComponent<collOff>().collOn3();
            //    }
                
            //}

            Destroy(gameObject, 0.1f);
            //Destroy(other.gameObject);



            if (_enemyHealth <= 0)
            {
                find = false;
               
                //Destroy(other.gameObject.transform.parent.gameObject,0.8f);
                if(other.gameObject.transform.gameObject == null)
                {
                    find = false;
                }
                if (other.gameObject.CompareTag("playerr") && other.gameObject.layer == LayerMask.NameToLayer("playerFact"))
                {
                    spawnFactlist_1.Remove(other.gameObject.transform.parent.gameObject);
                }

            }
        }
        if(other.gameObject.CompareTag("ground"))
        {
            particleSystem.Play();
        }
        Destroy(gameObject, 5f);
    }
   
}
