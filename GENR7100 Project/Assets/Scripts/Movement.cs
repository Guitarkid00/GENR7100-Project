using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public NavMeshAgent agent;

    public float rotateSpeedMovement = 0.1f;
    public float rotateVelocity;

    public HeroCombat heroCombatScript;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        heroCombatScript = GetComponent<HeroCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        if(heroCombatScript.targetedEnemy != null)
        {
            if(heroCombatScript.targetedEnemy.GetComponent<HeroCombat>() != null)
            {
                if (!heroCombatScript.targetedEnemy.GetComponent<HeroCombat>().isHeroAlive)
                {
                    heroCombatScript.targetedEnemy = null;
                }
            }

        }

        //When pressing the right mouse button
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            //Check if raycast hits the nav mesh
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if(hit.collider.tag == "Floor")
                {
                    //MOVEMENT
                    //Move to raycast hit point
                    agent.SetDestination(hit.point);
                    heroCombatScript.targetedEnemy = null;
                    agent.stoppingDistance = 0;

                    //Rotation
                    Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref rotateVelocity, rotateSpeedMovement * (Time.deltaTime * 5));

                    transform.eulerAngles = new Vector3(0, rotationY, 0);
                }


            }
        }
    }
}
