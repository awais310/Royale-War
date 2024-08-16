using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetFacts : MonoBehaviour
{
    public Text lvtext;
    public GameObject winpanel,failPanel;
    public List<GameObject> spawnedFacts = new List<GameObject>();
    public List<Transform> Factenemies = new List<Transform>();
    //public List<GameObject> playerFacts = new List<GameObject>();
    //public List<Transform> PlayerFactenemies = new List<Transform>();
    public playerSelector SpawnFactlist; public List<GameObject> spawnFactlist_1;
    public playerSelector TransFactlist; public List<Transform> TransFactlist_1;
    // Start is called before the first frame update
    void Start()
    {
        winpanel.SetActive(false);
        failPanel.SetActive(false);
        SpawnFactlist = GameObject.FindObjectOfType<playerSelector>();
        spawnFactlist_1 = SpawnFactlist.ClonespawnedFactorys;
        TransFactlist = Transform.FindObjectOfType<playerSelector>();
        TransFactlist_1 = TransFactlist.CloneplayerFactTran;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedFacts.Count == 0 || Factenemies.Count ==0)
        {
            lvtext.gameObject.SetActive(false);
            winpanel.SetActive(true);
            playerSelector.inst.restartbtn.SetActive(false);
        }
        for (int i = Factenemies.Count - 1; i >= 0; i--)
        {
            if (IsGameObjectMissing(Factenemies[i]))
            {
                // Remove the missing GameObject from the list
                Factenemies.RemoveAt(i);
            }
        }
        if (spawnFactlist_1.Count == 0 || TransFactlist_1.Count == 0)
        {
            lvtext.gameObject.SetActive(false);
            failPanel.SetActive(true);
            playerSelector.inst.restartbtn.SetActive(false);
        }
        for (int i = TransFactlist_1.Count - 1; i >= 0; i--)
        {
            if (IsGameObjectMissing(TransFactlist_1[i]))
            {
                // Remove the missing GameObject from the list
                TransFactlist_1.RemoveAt(i);
            }
        }
    }
    private bool IsGameObjectMissing(Transform obj)
    {
        return obj == null;
    }
    // OnDestroy is called when the GameObject is being destroyed
   
}
