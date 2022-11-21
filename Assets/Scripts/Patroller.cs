using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    int groundLayer;
    RaycastHit2D groundCheck;
    float speed = 10.0f;
    float size;

    // Start is called before the first frame update
    void Start()
    {
        groundLayer = 1 << LayerMask.NameToLayer("Ground");
        size = GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = transform.position + (-transform.localScale.x * transform.right * size);

        Debug.DrawLine(origin, origin + -transform.up * 10, Color.red);

        groundCheck = Physics2D.Raycast(origin, transform.TransformDirection(Vector3.down),
            Mathf.Infinity, groundLayer);

        if (groundCheck.collider == null)
        {
            transform.localScale = new Vector3(-transform.localScale.x,
                transform.localScale.y, transform.localScale.z);
        }

        else
        {
            transform.position += -transform.right * transform.localScale.x * speed * Time.deltaTime;
        }
    }
}
