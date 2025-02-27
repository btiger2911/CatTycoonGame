using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
     float nextSpawnTime;
    [SerializeField] private float timeBetweenSpawns;


    [SerializeField] private float minX, minY, maxX, maxY;

    
   
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + timeBetweenSpawns;
            Vector3 randomPosition = GetValidRandomPosition();

            if (randomPosition != Vector3.zero)
            {
                
                Instantiate(enemy, randomPosition, Quaternion.identity);
            }
        }
    }

    public Vector3 GetValidRandomPosition()
    {
        for (int i = 0; i < 10; i++)  
        {
            Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
            Collider2D overlap = Physics2D.OverlapBox(randomPosition, new Vector2(1, 1), 0f);

            if (overlap == null)  
            {
                return randomPosition;
            }
        }

        return Vector3.zero;  
    }
}
