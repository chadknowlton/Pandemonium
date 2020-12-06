using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    public GameObject gm;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            TowerData.NextFloor();

            if(TowerData.CurrentFloor > TowerData.MaxFloor)
            {
                gm.GetComponent<LevelLoader>().LoadLevel("Final_Level");
            }
            else
            {
                gm.GetComponent<LevelLoader>().LoadLevel("Tyche_System");
            }
        }
    }
}
