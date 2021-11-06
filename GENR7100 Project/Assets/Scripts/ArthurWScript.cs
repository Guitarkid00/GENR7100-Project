using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArthurWScript : MonoBehaviour
{
    

    public float particleLife = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, particleLife);
    }
}
