using UnityEngine;

public class ObstacleDeletionScript : MonoBehaviour
{
    public GameObject player;
    public Vector3 offSet = new Vector3(0, 0, -30);

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

        // Destroy if obstacle goes behind player
        if (transform.position.z < player.transform.position.z + offSet.z)
        {
            Destroy(gameObject);
        }
    }
}