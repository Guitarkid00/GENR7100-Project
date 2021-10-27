using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArthurQScript : MonoBehaviour
{
    Rigidbody thisRB;

    public float projectileLife = 1f;
    public float projectileSpeed = 2f;

    public int projectileDamage = 100;



    // Start is called before the first frame update
    void Start()
    {
        thisRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        thisRB.velocity = new Vector3(projectileSpeed, 0, 0);
        Destroy(gameObject, projectileLife);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Stats>().currentHealth -= projectileDamage;
            Destroy(gameObject);
        }
    }
}
