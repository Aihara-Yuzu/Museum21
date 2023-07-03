using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fiveroundManager : MonoBehaviour
{

    public static fiveroundManager instance;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public Dictionary<string, int> hashMapFiveManager = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        hashMapFiveManager.Add("fiveround_1", 0);
        hashMapFiveManager.Add("fiveround_2", 1);
        hashMapFiveManager.Add("fiveround_3", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
