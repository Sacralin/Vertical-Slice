using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormanSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int screen = PlayerPrefs.GetInt("screen");
        if ( screen == 1 || screen == 2)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
