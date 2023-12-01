using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class UIKeypadController : MonoBehaviour
{
    public List<int> correctPassword = new List<int>();
    private List<int> inputPasswordList = new List<int>();

    [SerializeField] private TMP_Text codeDisplay;
    [SerializeField] private float resetTime = 2f;
    [SerializeField] private string successText;
    [SerializeField] private GameObject travelButton;
    [SerializeField] private GameObject soduko;
    [SerializeField] private GameObject doorShelf;
    [SerializeField] private GameObject firstKeypad;
    [SerializeField] private GameObject secondKeypad;
    public float keycodeDigits;

    [Space(5f)]
    [Header("Keypad Entry Events")]
    public UnityEvent onCorrectPassword;
    public UnityEvent onIncorrectPassword;
    public bool allowMultipleActivations = false;
    private bool hasUsedCorrectCode = false;
    public bool HasUsedCorrectCode { get { return hasUsedCorrectCode; } }

    public AudioSource deniedAudio;
    public AudioSource grantedAudio;


    public void UserNumberEntry(int SelectedNum)
    {
        if (inputPasswordList.Count >= keycodeDigits)
            return;
        inputPasswordList.Add(SelectedNum);
        UpdateDisplay();

        if (inputPasswordList.Count >= keycodeDigits)
            CheckPassword();
    }

    private void CheckPassword()
    {
        for(int i = 0; i < correctPassword.Count; i++)
        {
            if(inputPasswordList[i] != correctPassword[i])
            {
                IncorrectPassword();
                return;
            }
            correctPasswordGiven();
        }
    }

    private void correctPasswordGiven()
    {
        if(allowMultipleActivations)
        {
            onCorrectPassword.Invoke();
            StartCoroutine(ResetKeycode());
            //grantedAudio.Play();
        }
        else if(!allowMultipleActivations && !hasUsedCorrectCode)
        {
            onCorrectPassword.Invoke();
            hasUsedCorrectCode = true;
            codeDisplay.text = successText;
            //firstKeypad.SetActive(false);
            //secondKeypad.SetActive(true);
            //travelButton.SetActive(true);
        }
    }

    private void IncorrectPassword()
    {
        onIncorrectPassword.Invoke();
        StartCoroutine(ResetKeycode());
        deniedAudio.Play();

    }

    private void UpdateDisplay()
    {
        codeDisplay.text = null;
        for(int i=0; i<inputPasswordList.Count; i++)
        {
            codeDisplay.text += inputPasswordList[i];
        }
    }

    IEnumerator ResetKeycode()
    {
        yield return new WaitForSeconds(resetTime);

        inputPasswordList.Clear();
        codeDisplay.text = "ABCD";
    }

    public void StartTimerKeypad()
    {
        StartCoroutine(ResetKeypad());
    }
    
    
    IEnumerator ResetKeypad()
    {
        yield return new WaitForSeconds(resetTime);

        firstKeypad.SetActive(false);
        secondKeypad.SetActive(true);
    }

    public void setActiveTravelButton()
    {
        travelButton.SetActive(true);

    }

    public void setActiveSoduko()
    {
        soduko.SetActive(true);

    }
    public void setActiveDoor()
    {
        doorShelf.SetActive(false);
        print("Dør virker");

    }


    //ToDo:
    //Audio på click og denied og granted,
    //muligvis rød farve på forkert,
    //ved korrekt kode, aktiver knap til at rejse til næste tidsperiode
}
