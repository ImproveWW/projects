using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float force = 40;

    public void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * force, ForceMode.Impulse);
    } 
}
