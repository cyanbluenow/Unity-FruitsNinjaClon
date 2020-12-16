using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody _rigidbody;
    private float
        minForce = 12,
        maxForce = 16,
        maxTorque = 10,
        xRange= 4,
        ySpawnPos = -6
    ;


    [Range(-100,100)]
    public int pointValue;

    public ParticleSystem explosionParticles;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(explosionParticles, transform.position, explosionParticles.transform.rotation);
        gameManager.UpdateScore(pointValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("KillZone"))
        {
            Destroy(gameObject);
            if (pointValue > 0)
            {
                gameManager.UpdateScore(-10);
            }
        }
    }
}
