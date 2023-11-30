using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotPuzzle : MonoBehaviour
{
	
	float Key1 =0;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Key1 == 1) //Du skal skrive: && Key2 == 1 til så mange keys du har brug for
		{
		// Lav din kode her
		}
    }
	// Should do something when colliding
	void OnCollisionEnter (Collision targetObj) {
if(targetObj.gameObject.tag == "PP1")
  {
        Key1 = 1;
  }
}
}
