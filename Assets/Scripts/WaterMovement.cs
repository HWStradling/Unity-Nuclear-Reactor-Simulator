using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.ParticleSystem;
using Random = UnityEngine.Random;

public class WaterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float InitialSpeed { get;  set; }

    private List<GameObject> closest;

    [SerializeField]private int closestCount = 5;

    public WaterFluidManager ManagerScript { get; set; }

    private Vector2 initialVelocity;
    // Start is called before the first frame update
    void Start()
    {
        initialVelocity =  Random.insideUnitCircle.normalized * InitialSpeed;
        rb.velocity = initialVelocity;
        closest = FindClosestParticles(transform, ManagerScript.particleArray, closestCount);
    }
    private List<GameObject> FindClosestParticles(Transform target, List<GameObject> gameObjects, int count)
    {
        return gameObjects
               .Cast<GameObject>() // Convert ArrayList to IEnumerable<GameObject>
               .OrderBy(obj => Vector3.Distance(target.position, obj.transform.position)) // Sort by distance
               .Take(count) // Take the top `count`
               .ToList(); // Convert to List<GameObject>
    }
    private void CullFarCohesion()
    {
        SpringJoint2D[] springs = GetComponentsInParent<SpringJoint2D>(); // destroy springs with non proximal particles.
        foreach (SpringJoint2D spring in springs)
        {
            if (!closest.Contains(spring.connectedBody.transform.parent.gameObject) ) { 
                Destroy(spring);
            }
        }
    }
    
    private Boolean HasSpringWithThis(GameObject target)
    {
        SpringJoint2D[] springs = target.GetComponents<SpringJoint2D>();

        if (springs.Length > 0) // if has springs
        {
          foreach (SpringJoint2D spring in springs)
            { 
                if (spring.attachedRigidbody == GetComponentInParent<Rigidbody2D>()) // if already a spring between this and target
                {
                    return true;
                }
            }
        }
        return false;
    }


    private void ApplyCohesion()
    {
        CullFarCohesion();
        foreach (GameObject particle in closest)
        {
            if (!HasSpringWithThis(particle))
            {
                throw new NotImplementedException("not implemented apply cohesion");
            }
           
            
        }
    }

    void Update()
    {
        closest = FindClosestParticles(transform, ManagerScript.particleArray, closestCount);
    }
}
