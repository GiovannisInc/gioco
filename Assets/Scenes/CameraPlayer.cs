using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    Transform mauro;

    [SerializeField]
    float z_offset = -10f;

    [SerializeField]
    float y_offset = 1.89f;

    [SerializeField]
    float smooth = 0.6f;

    Vector3 velocity = Vector3.zero;
    void Start()
    {
        mauro = GameObject.FindGameObjectWithTag("Giocatore").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (mauro != null)
        {
            Vector3 targetPosition = new Vector3(mauro.position.x, mauro.position.y + y_offset, mauro.position.z + z_offset);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smooth);
        }
    }
}
