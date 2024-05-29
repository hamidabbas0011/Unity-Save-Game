using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Color _color;
    // Start is called before the first frame update
    void Start()
    {
        _color = GetComponent<Color>();
        Debug.Log("Game Started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pos"))
        {
            _color = Color.red;
        }
    }
}
