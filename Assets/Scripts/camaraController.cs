using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraController : MonoBehaviour
{
    public Transform playerTransform;

    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        var y = playerTransform.position.y + 0f;
        var x = playerTransform.position.x + 6f;
        transform.position = new Vector3(playerTransform.position.x, y, transform.position.z);
    }
}