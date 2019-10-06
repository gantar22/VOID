using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_right : MonoBehaviour
{
    public void move_x(float deltax)
    {
        transform.position += Vector3.right * deltax;
    }
}
