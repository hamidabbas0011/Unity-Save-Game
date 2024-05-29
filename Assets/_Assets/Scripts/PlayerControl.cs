using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    private Color _color;
    [SerializeField] private KeyCode moveUp;
    [SerializeField] private KeyCode moveDown;
    public float[] position;
    [SerializeField] private float speed;
    private Rigidbody _rigidbody;
    public TextMeshProUGUI positionText;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _color = GetComponent<MeshRenderer>().material.color;
        Debug.Log("Game Started");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = GetCurrentPosition();
        positionText.text = $"Current Position: {currentPosition.x:F2}, {currentPosition.y:F2}, {currentPosition.z:F2}";
        position[0] = GetCurrentPosition().x;
        position[1] = GetCurrentPosition().y;
        position[2] = GetCurrentPosition().z;
        PlayerMovement();
    }

    void PlayerMovement()
    {
        bool pressedUp = Input.GetKey(this.moveUp);
        bool pressedDown = Input.GetKey(this.moveDown);

        
        if (pressedUp)
        {
            _rigidbody.velocity = Vector3.forward * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (pressedDown)
        {
            _rigidbody.velocity = Vector3.back * speed;
        }
        if(!pressedDown && !pressedUp)
        {
            _rigidbody.velocity = Vector3.zero;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pos"))
        {
            other.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pos"))
        {
            other.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public Vector3 GetCurrentPosition()
    {
        // Return the player's current position
        return transform.position;
    }
}
