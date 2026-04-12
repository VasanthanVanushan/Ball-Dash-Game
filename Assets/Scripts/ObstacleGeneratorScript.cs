using UnityEngine;

public class ObstacleGeneratorScript : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform player;
    public Vector3 spawnPosition;
    public float distanceBetweenObstacles = 40f;
    public float horizonPosition = 100f;


    void Update()
    {
        float distance = Vector3.Distance(player.position, spawnPosition);

        if(distance < horizonPosition)
        {
            int x = Random.Range(-4 , 4);

            spawnPosition = new Vector3(x , 0.5f , spawnPosition.z + distanceBetweenObstacles);
        
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        }
    }

}
