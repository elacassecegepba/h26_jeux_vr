using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GazTank : MonoBehaviour
{
    float maxGaz = 25;
    float currentGaz = 5;
    private XRSocketInteractor socketInteractor;
    private AudioSource audioSource;
    AudioClip gazFilling;
    AudioClip alarm;
    private bool isFilling = false;
    private bool isOverflowing = false;
    

  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        gazFilling = Resources.Load<AudioClip>("Audio/GazFilling");
        alarm = Resources.Load<AudioClip>("Audio/Alarm");
    }

    void Start()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
        socketInteractor.selectEntered.AddListener(Activate);
        socketInteractor.selectExited.AddListener(Deactivate);

        audioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        if (isFilling)
        {
            currentGaz += Time.deltaTime * 2f;
            print(currentGaz);
            if(currentGaz > maxGaz)
            {
                Overflow();
            }
        }
    }

    private void Overflow()
    {
        if(!isOverflowing)
        {
            audioSource.clip = alarm;
            audioSource.Play();


            isOverflowing = true;
        }
    }

    private void StopOverflow()
    {
        isOverflowing = false;
    }

    public void Activate(SelectEnterEventArgs args)
    {

        Pistolet pistolet = args.interactableObject.transform.GetComponent<Pistolet>();
        if (pistolet == null)
        {
            return;

        }
        if (pistolet.GazState == true)
        {
            isFilling = true;
            print(gazFilling.length);
            audioSource.clip = gazFilling;
            audioSource.Play();
        }

    }

    public void Deactivate(SelectExitEventArgs args)
    {
        audioSource.Stop();
        isFilling = false;
        StopOverflow();

    }
}
