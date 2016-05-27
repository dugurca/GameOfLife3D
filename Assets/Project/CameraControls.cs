using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour
{
    private const float Speed = 15f;

	void Update ()
	{
	    float xTrans = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
	    float zTrans = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
	    float yTrans = 0;
	    if (Input.GetKey(KeyCode.Space)) yTrans = 1;
        else if (Input.GetKey(KeyCode.LeftControl)) yTrans = -1;
	    yTrans *= Speed * Time.deltaTime;
        
        transform.Translate(xTrans, yTrans, zTrans, Space.Self);
	}
}
