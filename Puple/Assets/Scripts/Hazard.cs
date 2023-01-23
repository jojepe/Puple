using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

public class Hazard : MonoBehaviour
{
    public ParticleSystem deathParticles;
    private CinemachineImpulseSource cineImpulse;

    private void Start()
    {
        cineImpulse = GetComponent<CinemachineImpulseSource>();

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
            cineImpulse.GenerateImpulse();
        }
    }
}
