using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Pistolet : MonoBehaviour
{

    private XRGrabInteractable grabInteractable;
    private ParticleSystem gaz;
    private bool gazState = false;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        gaz = GetComponentInChildren<ParticleSystem>();
        grabInteractable.activated.AddListener(Activate);
    }

    void OnEnable()
    {
       
    }

    void OnDisable()
    {
       
    }

    public void Activate(ActivateEventArgs args)
    {
        print("Hello");
        ToggleGaz();
        //gaz.Play();
    }

    private void ToggleGaz()
    {
        if (gaz == null)
            return;

        if (gazState)
        {
            gaz.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            Debug.Log("Stop");
        }
        else
        {
            gaz.Play();
            Debug.Log("Play");
        }

        gazState = !gazState;
    }

    void Update()
    {

        
    }
}
