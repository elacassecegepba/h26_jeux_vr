using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class Car : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rigidbody;
    [SerializeField]
    public bool DrivingOff = false;
    [SerializeField]
    public bool DrivingIn  = true;
    [SerializeField]
    public Transform Target { get; set; }

    public float springStrength = 50f;
    public float damping = 10f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
   

    public void DriveOff()
    {
        DrivingOff = true;

        Destroy(this,7000);
    }


    

    void FixedUpdate()
    {
        if (DrivingOff)
        {
            rigidbody.AddRelativeForce(0, 0, 3000 * Time.deltaTime);
        }
        if (DrivingIn)
        {
            Vector3 direction = Target.position - rigidbody.position;
            Vector3 force = direction * springStrength - rigidbody.linearVelocity * damping;
            rigidbody.AddForce(force);
            if(direction.magnitude < 1)
            {
                rigidbody.linearVelocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;
                DrivingIn = false;
            }
        }
        

        
    }
}
