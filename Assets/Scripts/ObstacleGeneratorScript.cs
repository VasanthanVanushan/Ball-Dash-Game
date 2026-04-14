using UnityEngine;

public class ObstacleGeneratorScript : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject[] coinPrefabs;
    public Transform player;
    public Vector3 spawnPosition;
    public float distanceBetweenObstacles = 40f;
    public float horizonPosition = 100f; // Distance threshold to decide when to spawn next obstacle
    public float coinChance = 0.3f;


    void Update()
    {
        float distance = Vector3.Distance(player.position, spawnPosition);  //Calculate distance between player and next spawn position

        if(distance < horizonPosition)  //“Only spawn a new obstacle when the player is close enough to the last spawn point”
        {
            int x = Random.Range(-4 , 4);

            spawnPosition = new Vector3(x , 0.5f , spawnPosition.z + distanceBetweenObstacles); 

            if(Random.value < coinChance )
            {
                spawnPosition.y = 0.4f;
                GameObject coinPrefab = coinPrefabs[Random.Range(0,coinPrefabs.Length)];

                Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0,obstaclePrefabs.Length)];

                Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);    // z = 40 -> 80 -> 120 -> 160 .....
            }
        }
    }

}
