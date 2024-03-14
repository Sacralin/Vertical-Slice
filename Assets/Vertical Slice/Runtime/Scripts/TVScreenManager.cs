using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVScreenManager : MonoBehaviour
{
    public GameObject screen0;
    public GameObject screen1; //has clock
    public GameObject screen2; //has clock
    public GameObject screen3;
    public GameObject screen4;
    List<GameObject> screens = new List<GameObject>();
    public int selectedScreen;
    


    // Start is called before the first frame update
    void Start()
    {
        screens.Add(screen0);
        screens.Add(screen1);
        screens.Add(screen2);
        screens.Add(screen3);
        screens.Add(screen4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectRandomScreen()
    {
        int random = GetRandom();//check this logic

        if (random == selectedScreen)//check this logic
        {
            GetRandom();//check this logic
        }
        else
        {
            selectedScreen = random;//check this logic
        }

        foreach (GameObject screen in screens)
        {
            screen.SetActive(false);
        }

        screens[selectedScreen].SetActive(true);

    }

    int GetRandom()
    {
        int random = Random.Range(0, 5);
        return random;
    }



}
