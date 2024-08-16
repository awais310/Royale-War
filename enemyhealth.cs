using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    public float health;
   
    public Image fillImage;
    // Start is called before the first frame update
    void Start()
    {
       
        
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if(fillImage != null)
        {
            fillImage.fillAmount = (float)health / 100;
        }
        
        if (health <= 0)
        {
            Destroy(gameObject, 0.2f);
            if (gameObject.transform.parent != null)
            {
                if(fillImage != null)
                {
                    Destroy(GetComponentInParent<Image>());
                }
               
                Destroy(gameObject.transform.parent.gameObject, 0.2f);
            }
        }
    }
}
