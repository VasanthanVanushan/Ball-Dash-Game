using UnityEngine;

public class ObstacleGeneratorScript : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform player;
    public Vector3 spawnPosition;
    public float distanceBetweenObstacles = 40f;
    public float horizonPosition = 100f; // Distance threshold to decide when to spawn next obstacle


    void Update()
    {
        float distance = Vector3.Distance(player.position, spawnPosition);  //Calculate distance between player and next spawn position

        if(distance < horizonPosition)  //“Only spawn a new obstacle when the player is close enough to the last spawn point”
        {
            int x = Random.Range(-4 , 4);

            spawnPosition = new Vector3(x , 0.5f , spawnPosition.z + distanceBetweenObstacles); 
        
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);    // z = 40 -> 80 -> 120 -> 160 .....
        }
    }

}
