using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject panel;
    private float destroyTime = 2.0f;


    void Start()
    {
        Destroy(panel.gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
