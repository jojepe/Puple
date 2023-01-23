using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    public float forceMultiplier = 3f;
    public float maximumVelocity = 5f;
    public ParticleSystem deathParticles;
    public GameObject mainVcam;
    public GameObject zoomVcam;

    private CinemachineImpulseSource cineImpulse;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cineImpulse = GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance == null)
        {
            return;
        }
        var horizontalInput = Input.GetAxis("Horizontal");
        
        if (rb.velocity.magnitude <= maximumVelocity)
        {
            rb.AddForce(new Vector3(horizontalInput * forceMultiplier * Time.deltaTime, 0, 0));
        }
    }

    private void OnEnable()
    {
        transform.position = new Vector3(0, 1.874f, 0);
        transform.rotation = Quaternion.Euler(0,0,0);
        rb.velocity = Vector3.zero;
        zoomVcam.SetActive(false);
        mainVcam.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            GameManager.Instance.GameOver();
            gameObject.SetActive(false);
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            cineImpulse.GenerateImpulse();
            mainVcam.SetActive(false);
            zoomVcam.SetActive(true);

        }

        if (collision.gameObject.CompareTag("MapBarrier"))
        {
            GameManager.Instance.GameOver();
            gameObject.SetActive(false);
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            cineImpulse.GenerateImpulse();
            
            mainVcam.SetActive(false);
            zoomVcam.SetActive(true);
        }
    }
}
