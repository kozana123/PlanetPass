using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField] private Vector3 velocitySet;
    [SerializeField] private float rotetionSet = 1f;
    [SerializeField] private Rigidbody rb;
    

    [SerializeField]
    private float tumble;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        rb.velocity = velocitySet;
    }
}