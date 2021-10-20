using UnityEngine;

public class CreditScrollScript : MonoBehaviour
{
    public float force;

    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * force * Time.deltaTime);
    }
}
