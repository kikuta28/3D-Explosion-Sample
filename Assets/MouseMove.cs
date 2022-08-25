using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    private Vector2 mouseInput;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * 5;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + mouseInput.y, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);



        //// Mathf.Clamp()数値を制限
        //viewPoint.rotation = Quaternion.Euler(mouseInput, viewPoint.rotation.eulerAngles.y, viewPoint.rotation.eulerAngles.z);

        //Debug.Log(viewPoint.rotation.eulerAngles.x);
    }
}
