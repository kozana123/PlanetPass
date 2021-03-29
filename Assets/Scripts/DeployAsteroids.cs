using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployAsteroids : MonoBehaviour
{

    public GameObject[] asteroidLeftPrefabs;
    public GameObject[] asteroidRightPrefabs;
    public float respawnTime = 1.5f;
    private Vector2 screenBounds;

    int randomInt;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AsteroidWave());
    }

    // Update is called once per frame
    void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); 

    }

    private void spawnAsteroidsRight()
    {
        randomInt = Random.Range(0, asteroidRightPrefabs.Length);
        GameObject a = Instantiate(asteroidRightPrefabs[randomInt]);
        a.transform.position = new Vector2(screenBounds.x * -2, Random.Range(screenBounds.y + 15f, screenBounds.y + 40f));
        

    }

    private void spawnAsteroidsLeft()
    {
        randomInt = Random.Range(0, asteroidLeftPrefabs.Length);
        GameObject a = Instantiate(asteroidLeftPrefabs[randomInt]);
        a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(screenBounds.y + 15f, screenBounds.y + 25f));
        

    }

    IEnumerator AsteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);

            var spawnPosition = Random.Range(0f, 1f);

            if(spawnPosition <= 0.5f)
            {
                spawnAsteroidsRight();
            }

            else
            {
                spawnAsteroidsLeft();
            }
            
        }
        
    }
}
