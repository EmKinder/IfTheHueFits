using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement2 : MonoBehaviour
{
    public Rigidbody car;
    public float carSpeed;
    public MeshRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        car = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (rend.isVisible)
        {
            car.velocity = gameObject.transform.forward * carSpeed;
            Debug.Log("carVisible");
        }
    }
}
