using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditScrollScript : MonoBehaviour
{
    public float force;

    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * force * Time.deltaTime);
    }
}
