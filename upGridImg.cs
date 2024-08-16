using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class upGridImg : MonoBehaviour
{
    public GameObject[] images;
    public int currentIndex;
    public Image greenImg;
    public bool isfilled;
    public GameObject selectedWeapon;
    // Start is called before the first frame update
    void Start()
    {
        isfilled = false;
       // GetComponent<Button>().onClick.AddListener(OnButtonWrapperClick);
        //playerSelector playerSelectorComponent = GetComponent<playerSelector>();

        //// Check if the component is not null
        //if (playerSelectorComponent != null)
        //{
        //    //print("Truee");
        //    // Set the currentIndex based on the value from playerSelector
        //    currentIndex = playerSelectorComponent.itemNo;
        //}
        // SetImageActive(currentIndex);


    }

  public void _click()
    {
        print(currentIndex);
        if (AudioManager.instance)
        {
            AudioManager.instance.Play("Click");
        }
        playerSelector.inst.selectweaponOn(currentIndex);
        GetComponent<Image>().sprite = greenImg.sprite;
        playerSelector.inst.i--;
        isfilled = false;

        //playerSelector.inst.selectedweapon[currentIndex].sprite.remove;
        //playerSelector.inst.selectedweapon[currentIndex].sprite = null;
        currentIndex = 0;
    }
    // Update is called once per frame
    //void Update()
    //{
    //    playerSelector playerSelectorComponent = GetComponent<playerSelector>();
    //    //if (playerSelectorComponent != null)
    //    {
    //        //print("Truee");
    //        // Set the currentIndex based on the value from playerSelector
    //        currentIndex = playerSelectorComponent.itemNo1;
    //    }
    //    if (currentIndex == 0)
    //    {
    //        // Previous image
    //       // currentIndex = (currentIndex - 1 + images.Length) % images.Length;
    //        SetImageActive(currentIndex);
    //    }
    //    if (currentIndex == 1)
    //    {
    //        // Next image

    //        SetImageActive(currentIndex);
    //    }
    //}
    //void SetImageActive(int index)
    //{
    //    // Deactivate all images
    //    foreach (var image in images)
    //    {
    //        image.SetActive(false);
    //    }

    //    // Activate the image based on the index
    //    images[index].SetActive(true);
    //}
}
