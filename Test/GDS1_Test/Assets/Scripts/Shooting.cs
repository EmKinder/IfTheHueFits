using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject paintball;
    public Transform paintPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CanShootPaint()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(paintball, paintPos.position + 1.0f * transform.forward, transform.rotation);
    }

    public void ShootPaint()
    {
        //  Instantiate(paintball, transform.position, Quaternion.identity);
        //  paintball.transform.forward = transform.forward;
        StartCoroutine(CanShootPaint());
        
    }
}
