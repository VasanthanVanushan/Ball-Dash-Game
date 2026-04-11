using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float forwardForce = 500f;
    public float targetSpeed = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float currentSpeed = rb.linearVelocity.z;

        // If below target speed → accelerate
        if (currentSpeed < targetSpeed)
        {
            rb.AddForce(Vector3.forward * forwardForce * Time.fixedDeltaTime, ForceMode.Force);
        }
        else
        {
            // Clamp speed
            Vector3 clampedVelocity = rb.linearVelocity;
            clampedVelocity.z = targetSpeed;
            rb.linearVelocity = clampedVelocity;
        }

        Debug.Log(targetSpeed + " -- " + currentSpeed.ToString("F2"));
    }
}