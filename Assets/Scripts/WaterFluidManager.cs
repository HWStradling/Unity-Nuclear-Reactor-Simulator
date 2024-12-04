using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFluidManager : MonoBehaviour
{
    [SerializeField] private GameObject WaterParticle;
    [SerializeField] private int particleCount;
    [SerializeField] private Transform bottomLeft, topRight;
    public List<GameObject> particleArray { get; set; }
    [SerializeField] private float initialSpeed;


    //private int avgTemperature, pressure;
    // Start is called before the first frame update
    void Start()
    {
        particleArray = new List<GameObject>();

        Vector2 leftCorner = bottomLeft.position;
        Vector2 rightCorner = topRight.position;

        for (int i = 0; i < particleCount; i++)
        {
            Vector2 randomSpawnPoint = new(Random.Range(leftCorner.x, rightCorner.x), Random.Range(leftCorner.y, rightCorner.y));
            GameObject newParticle = Instantiate(WaterParticle);
            newParticle.transform.position = new Vector3(randomSpawnPoint.x, randomSpawnPoint.y);
            newParticle.GetComponent<WaterMovement>().InitialSpeed = initialSpeed;
            newParticle.GetComponent<WaterMovement>().ManagerScript = this;
            particleArray.Add(newParticle);
        }
    }
    /*    private void maintainSpeed()
        {
            foreach (GameObject particle in particleArray)
            {
                Rigidbody2D particleRB = particle.GetComponent<Rigidbody2D>();
                if (particleRB.velocity.magnitude < initialSpeed)
                {
                    particleRB.velocity = particleRB.velocity.normalized * initialSpeed;
                }
            }
        }*/
    // Update is called once per frame
    void Update(){
    }
}
