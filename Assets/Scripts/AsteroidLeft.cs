using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidLeft : MonoBehaviour
{
    [SerializeField] private Vector3 velocitySet;
    [SerializeField] private float rotetionSet = 1f;
    [SerializeField] private Rigidbody rb;
    private Vector2 screenBounds;
    

    [SerializeField]
    private float tumble;

    void Start()
    {
        tumble = Random.Range(0.2f, 1.5f);
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        rb = GetComponent<Rigidbody>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        velocitySet = new Vector3(Random.Range(velocitySet.x + 2, velocitySet.x + 5), Random.Range(velocitySet.y - 1, velocitySet.y + 1), velocitySet.z);
    }

    void Update()
    {
        rb.velocity = velocitySet;

        if(transform.position.x > screenBounds.x * -2)
        {
            Destroy(this.gameObject);
        }

    }
}