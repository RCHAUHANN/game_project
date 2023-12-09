using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] Asteroid asteroidPrefab;
    [SerializeField] GameObject plaayerPickupPrefab;
    [SerializeField] int numberOfAsteroidOnAxis = 10;
    [SerializeField] int gridspacing = 100;
    List<Asteroid> asteroids = new List<Asteroid>();    


    void Start()
    {
      //  placeAsteroids();
    }
    void OnEnable()
    {
        EventManager.onStartGame += placeAsteroids;
        EventManager.onPlayerDeath += DestroyAsteroids;
        EventManager.onRespawnPickup += PlacePickup;

    }
    void OnDisable()
    {

        EventManager.onStartGame -= placeAsteroids;
        EventManager.onPlayerDeath -= DestroyAsteroids;
        EventManager.onRespawnPickup -= PlacePickup;
    }
    void DestroyAsteroids()
    {
        foreach(Asteroid ast in asteroids)
        {
            ast.SelfDestruct();
        }
        asteroids.Clear();
    }

    void placeAsteroids()
    {
        for (int x = 0; x < numberOfAsteroidOnAxis; x++)
        {
            for (int y = 0; y < numberOfAsteroidOnAxis; y++)
            {
                for (int z = 0; z < numberOfAsteroidOnAxis; z++)
                {
                    instantiateAsteroid(x, y, z);
                }

            }
        }
        PlacePickup();
    }

    void instantiateAsteroid(int x, int y, int z)
    {
        Asteroid temp =  Instantiate(asteroidPrefab, 
            new Vector3(transform.position.x + (x * gridspacing) + AsteroidOffset(),
            transform.position.y + (y * gridspacing)+ AsteroidOffset(),
            transform.position.z + (z * gridspacing) + AsteroidOffset()),
            Quaternion.identity, transform) as Asteroid;
        asteroids.Add(temp);
    }

    void PlacePickup()
    {
        int rnd= Random.Range(0,asteroids.Count);
        Instantiate(plaayerPickupPrefab, asteroids[rnd].transform.position, Quaternion.identity);
        Destroy(asteroids[rnd].gameObject);
        asteroids.RemoveAt(rnd);  
        
    }

    float AsteroidOffset()
    {
        return Random.Range(-gridspacing / 2f, gridspacing / 2f);
    }

    
}
