using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ButtonInteractable : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    bool isPressed;
    public AudioSource buttonSound;

    void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isPressed)
        {
            button.transform.localPosition = new Vector3(20.6427f, 14.72f, -29.31107f);
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
            buttonSound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            //SceneManager.LoadScene("Dinosaur");
            button.transform.localPosition = new Vector3(20.6427f, 14.72316f, -29.31107f);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void LoadDinosaur()
    {
        SceneManager.LoadScene("Dinosaur");
    }

    public void LoadEgypt()
    {
        SceneManager.LoadScene("Egypt");
    }

    public void LoadViking()
    {
        SceneManager.LoadScene("Viking");
    }

    public void LoadCompleted()
    {
        SceneManager.LoadScene("Completed Menu");
    }

}
