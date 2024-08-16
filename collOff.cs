using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collOff : MonoBehaviour
{
    public player[] gameObjectsArray1;
    public tank[] gameObjectsArray2;
    public car[] gameObjectsArray3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void collOn1()
    {
        gameObjectsArray1 = FindObjectsOfType<player>();
        StartCoroutine(WaitForSeconds1());
    }
    public void collOn2()
    {
        gameObjectsArray2 = FindObjectsOfType<tank>();
        StartCoroutine(WaitForSeconds2());
    }

    public void collOn3()
    {
        gameObjectsArray3 = FindObjectsOfType<car>();
        StartCoroutine(WaitForSeconds3());
    }







    private IEnumerator WaitForSeconds1()
    {

        yield return new WaitForSeconds(0.1f);
        for (var i = 0; i < gameObjectsArray1.Length; i++)
        {
            gameObjectsArray1[i].gameObject.GetComponent<CapsuleCollider>().enabled = true;
            print("k");
        }
    }
    private IEnumerator WaitForSeconds2()
    {

        yield return new WaitForSeconds(0.1f);
        for (var i = 0; i < gameObjectsArray2.Length; i++)
        {
            // gameObjectsArray2[i].gameObject.GetComponent<CapsuleCollider>().enabled = true;
            print("k");
        }
    }
    private IEnumerator WaitForSeconds3()
    {

        yield return new WaitForSeconds(0.1f);
        for (var i = 0; i < gameObjectsArray3.Length; i++)
        {
            // gameObjectsArray3[i].gameObject.GetComponent<CapsuleCollider>().enabled = true;
            print("k");
        }
    }

}
