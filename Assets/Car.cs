using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class Car : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rigidbody;
    public bool ShouldDriveOff { get; private set; } = false;
    public bool DrivingIn { get; private set; } = true;
    [SerializeField]
    public Transform Target { get; set; }
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
   

    public void DriveOff()
    {
        ShouldDriveOff = true;

        Destroy(this,7000);
    }


    public float springStrength = 500f;
    public float damping = 10f;

    void FixedUpdate()
    {
        if (ShouldDriveOff)
        {
            rigidbody.AddRelativeForce(0, 0, 1000 * Time.deltaTime);
        }
        if (DrivingIn)
        {
            Vector3 direction = Target.position - rigidbody.position;
            Vector3 force = direction * springStrength - rigidbody.linearVelocity * damping;
            rigidbody.AddForce(force);
            if(direction.magnitude < 0.1)
            {
                rigidbody.linearVelocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;
            }
        }
        

        
    }
}
