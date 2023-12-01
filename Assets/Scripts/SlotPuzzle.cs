using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotPuzzle : MonoBehaviour
{
    public GameObject travelButton;

	bool Key1 = false;
    bool Key2 = false;
    bool Key3 = false;
    bool Key4 = false;

    public GameObject yellowCube;
    public GameObject greenCube;
    public GameObject blueCube;

    // Start is called before the first frame update
    void Start()
    {
        print("'key1 virker");
    }

    // Update is called once per frame
    void Update()
    {
       if (Key4 == true && Key1 == true && Key2 == true && Key3 == true) //Du skal skrive: && Key2 == 1 til så mange keys du har brug for
		{
            // Lav din kode her
            travelButton.SetActive(true);
            print("de der floats og bools virker");
        }

       
    }
	// Should do something when colliding
	void OnTriggerEnter (Collider other) 
    {
        if(other.gameObject.CompareTag("PP1"))
        {
            blueCube.SetActive(true);
            print("'key1 virker");
        }
        if (other.gameObject.CompareTag("PP2"))
        {
            greenCube.SetActive(true);
            print("'key2 virker");
        }
        if (other.gameObject.CompareTag("PP3"))
        {
            yellowCube.SetActive(true);
            print("'key3 virker");
        }
        if (other.gameObject.CompareTag("PP4"))
        {
            travelButton.SetActive(true);

        }
    }

   



}
