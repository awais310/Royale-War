using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator animator;
    public float transitionTime = 2f;
    private void Awake()
    {
        //if (!PlayerPrefs.HasKey("SoundEnabled"))
        //{
        //    PlayerPrefs.SetInt("SoundEnabled", 1);
        //}
    }
    private void Start()
    {
        //if (PlayerPrefs.GetInt("SoundEnabled",1) == 1)
        //{
        //    if (AudioManager.instance)
        //    {
        //        AudioManager.instance.Play("MenuSound");
        //    }
        //}
        _LevelLoader();

    }
    public void _LevelLoader()
    {
        StartCoroutine(loadlevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator loadlevel(int index)
    {
        animator.SetTrigger("start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(index);
    }
}
