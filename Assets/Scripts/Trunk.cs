
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Trunk : MonoBehaviour
{

    InputAction interact;
    Animator animator;
   

    private void Awake()
    {
        interact = InputSystem.actions.FindAction("Interact");
        animator = GetComponentInParent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnEnable()
    {
        interact.started += context => ToggleTrunk();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ToggleTrunk()
    {
        animator.SetBool("TrunkOpen", !animator.GetBool("TrunkOpen"));
    }

}
