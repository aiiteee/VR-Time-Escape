using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown_Timer : MonoBehaviour
{
       void Awake()
    {
       DontDestroyOnLoad( transform.root.gameObject);
    }

	float currentTimeSeconds =0;
	float startingTimeSeconds =59;
	
	float currentTimeMinutes =0;
	float startingMinutes =44;
	
	[SerializeField]
	Text countdownTextSeconds;
	[SerializeField]
	Text countdownMinutes;
	
   // Start is called before the first frame update
    void Start()
    {
        currentTimeSeconds = startingTimeSeconds;
		currentTimeMinutes = startingMinutes;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimeSeconds > 0)
		{
		currentTimeSeconds -= 1 * Time.deltaTime;
		}
		
	else
	{
			currentTimeMinutes -= 1;
			currentTimeSeconds = startingTimeSeconds;
	}
	countdownTextSeconds.text = currentTimeSeconds.ToString("0");
	countdownMinutes.text = currentTimeMinutes.ToString("0");
    }
}
