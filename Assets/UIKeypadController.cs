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
        if (inputPasswordList.Count >= 4)
            return;
        inputPasswordList.Add(SelectedNum);
        UpdateDisplay();

        if (inputPasswordList.Count >= 4)
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
            grantedAudio.Play();
        }
        else if(!allowMultipleActivations && !hasUsedCorrectCode)
        {
            onCorrectPassword.Invoke();
            hasUsedCorrectCode = true;
            codeDisplay.text = successText;
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

    //ToDo:
    //Audio på click og denied og granted,
    //muligvis rød farve på forkert,
    //ved korrekt kode, aktiver knap til at rejse til næste tidsperiode
}
