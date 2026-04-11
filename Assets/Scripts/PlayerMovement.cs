using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float forwardForce = 500f;
    public float targetSpeed = 10f;
    public float lateralForce = 30f;
    public float maxLateralPos = 4f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        ForwardMovement();
        LateralMovement();
    }

    void ForwardMovement()
    {
        float currentSpeed = rb.linearVelocity.z; //Rigidbody’s velocity is a Vector3

        // If below target speed → accelerate
        if (currentSpeed < targetSpeed)
        {
            rb.AddForce(Vector3.forward * forwardForce * Time.fixedDeltaTime, ForceMode.Force);
        }
        else
        {
            //ClampedVelocity is temporary variable
            Vector3 clampedVelocity = rb.linearVelocity;    //Get current velocity after exceed the targetSpeed (0, 0, 11)  
            clampedVelocity.z = targetSpeed;                //Change ONLY the forward speed z as 10 
            rb.linearVelocity = clampedVelocity;            //Apply it back (0, 0, 10)  
        }

        Debug.Log(targetSpeed + " -- " + currentSpeed.ToString("F2"));
    }

    void LateralMovement()
    {
        float direction = Input.GetAxis("Horizontal");

        Vector3 lateralVelocity = rb.linearVelocity;    
        lateralVelocity.x = direction * lateralForce; 
        rb.linearVelocity = lateralVelocity;

        //Clamp the player's x position within bounds
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -maxLateralPos, maxLateralPos);  //It restricts a value within a range -> Keep X between -maxLateralPos and +maxLateralPos
        transform.position = clampedPosition;
    }
}