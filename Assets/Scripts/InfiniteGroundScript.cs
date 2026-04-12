using UnityEngine;

public class InfiniteGroundScript : MonoBehaviour
{
    public float groundLength = 1000f;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))  //Player touched the object (Checks if that object’s tag is "Player")
        {
            transform.parent.position = transform.parent.position + new Vector3(0,0,groundLength *2);
        }
    }
}
