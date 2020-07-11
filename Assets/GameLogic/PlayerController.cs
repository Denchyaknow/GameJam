using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D Body
    {
        get
        {
            if (m_Body == null)
                m_Body = transform.root.GetComponent<Rigidbody2D>();
            return m_Body;
        }
    }
    private Rigidbody2D m_Body = null;

    public float inputAcceleration = 2f;
    public float inputDamping = 2f;
    public float moveSpeed = 1f;
    public Vector2 CurrentInput = Vector2.zero;
    public Vector2 CurrentVelocity { get; private set; }
    public Vector2 TargetVelocity { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput(ref CurrentInput);
    }
    private void FixedUpdate()
    {
        Body.velocity = CurrentInput * moveSpeed * Time.fixedDeltaTime;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit: " + collision.collider.name);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(Time.frameCount % 20 == 0)
        Debug.Log("Hit: " + collision.collider.name);

    }

    private void UpdateInput(ref Vector2 input_)
    {
        if (Input.GetKey(KeyCode.A))
            input_.x = Mathf.MoveTowards(input_.x, -1f, Time.deltaTime * inputAcceleration);
        else if (Input.GetKey(KeyCode.D))
            input_.x = Mathf.MoveTowards(input_.x, 1f, Time.deltaTime * inputAcceleration);
        else
            input_.x = Mathf.MoveTowards(input_.x, 0f, Time.deltaTime * inputDamping);
        if (Input.GetKey(KeyCode.S))
            input_.y = Mathf.MoveTowards(input_.y, -1f, Time.deltaTime * inputAcceleration);
        else if (Input.GetKey(KeyCode.W))
            input_.y = Mathf.MoveTowards(input_.y, 1f, Time.deltaTime * inputAcceleration);
        else
            input_.y = Mathf.MoveTowards(input_.y, 0f, Time.deltaTime * inputDamping);
    }
}
