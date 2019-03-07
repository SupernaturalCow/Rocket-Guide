using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField] float rotSpeed = 100f;
    [SerializeField] float thrustSpeed = 100f;

    Rigidbody rigidBody;
    AudioSource audioSource;
    bool btnThrust;
    bool btnLeft;
    bool btnRight;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Thrust();
        Rotate();
    }

    private void GetInput()
    {
        btnThrust = Input.GetKey(KeyCode.W);
        btnLeft = Input.GetKey(KeyCode.A);
        btnRight = Input.GetKey(KeyCode.D);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Collided");
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true;    // Take manual control of rotation

        if (btnLeft)
        {
            float rotAdjustedSpeed = rotSpeed * Time.deltaTime;
            transform.Rotate(-Vector3.up * rotAdjustedSpeed);
        }
        else if (btnRight)
        {
            float rotAdjustedSpeed = rotSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up * rotAdjustedSpeed);
        }

        rigidBody.freezeRotation = false;    // Resume physics control
    }
    private void Thrust()
    {
        if (btnThrust)
        {
            float thrustAdjustedSpeed = thrustSpeed * Time.deltaTime;
            rigidBody.AddRelativeForce(Vector3.forward * thrustAdjustedSpeed);
            if (!audioSource.isPlaying) audioSource.Play();
        }
        else
        {
            if (audioSource.isPlaying) audioSource.Stop();
        }
    }
}
