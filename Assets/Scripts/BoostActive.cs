using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostActive : MonoBehaviour
{

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            TopBoost.Emit(1);
        }

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            BottomBoost.Emit(1);
        }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            LeftBoost.Emit(1);
        }

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            RightBoost.Emit(1);
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            LeftTopBoost.Emit(1);
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            RightTopBoost.Emit(1);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            LeftBottomBoost.Emit(1);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            RightBottomBoost.Emit(1);
        }


    }
}
