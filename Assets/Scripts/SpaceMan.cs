using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMan : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float force = 1f;
    public Vector2 movement;
    public float speed;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;
    private Vector2 dir;
    private bool winning = false;



    public ParticleSystem TopBoost;
    public ParticleSystem BottomBoost;
    public ParticleSystem LeftBoost;
    public ParticleSystem RightBoost;
    public ParticleSystem LeftTopBoost;
    public ParticleSystem RightTopBoost;
    public ParticleSystem LeftBottomBoost;
    public ParticleSystem RightBottomBoost;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x , Input.mousePosition.y , Camera.main.transform.position.z));
            
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x , Input.mousePosition.y , Camera.main.transform.position.z));
            
        }
        else
        {
            touchStart = false;
            
        }
        pointA.y += 1f * Time.deltaTime;
       

    }

    private void FixedUpdate()
    {
        if (touchStart == true)
        {
            Vector2 offset = pointB - pointA ;
            Vector2 direction = Vector2.ClampMagnitude(offset, 2.0f);
            SpaceManMove(direction * -1);

            speed = rb.velocity.magnitude;
        }
      
        if(touchStart == false)
        {
            dir = new Vector2(0, 0);
        }

    }
    public void SpaceManMove(Vector2 direction)
    {
        
        rb.AddForce(direction  * force);

        dir = direction;

        Debug.Log(dir);

    }

    private void LateUpdate()
    {
        if (dir.y < 0 && dir.x > -0.5 && dir.x < 0.5)
        {
            TopBoost.Emit(1);
        }

        if (dir.y > 0 && dir.x > -0.5 && dir.x < 0.5)
        {
            BottomBoost.Emit(1);
        }

        if (dir.x > 0 && dir.y < 0.5 && dir.y > -0.5)
        {
            LeftBoost.Emit(1);
        }

        if (dir.x < 0 && dir.y < 0.5 && dir.y > -0.5)
        {
            RightBoost.Emit(1);
        }

        if (dir.x > 0 && dir.y < -0.5 && dir.y > -1.5)
        {
            LeftTopBoost.Emit(1);
        }

        if (dir.x < 0 && dir.y < -0.5 && dir.y > -1.5)
        {
            RightTopBoost.Emit(1);
        }

        if (dir.x > 0 && dir.y < 1.5 && dir.y > 0.5)
        {
            LeftBottomBoost.Emit(1);
        }

        if (dir.x < 0 && dir.y < 1.5 && dir.y > 0.5)
        {
            RightBottomBoost.Emit(1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.tag == "Enemy" && winning == false)
        {
            FindObjectOfType<GameManager>().EndGame();
            force = 0f;

        }

        if( collision.gameObject.tag == "Finish")
        {
            force = 0f;
            winning = true;
            FindObjectOfType<GameManager>().WinningGame();

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            force = 0f;
            winning = true;
            FindObjectOfType<GameManager>().WinningGame();

        }
    }
}
