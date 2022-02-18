using System.Collections;
using System.Collections.Generic;
using MyMath;
using UnityEngine;

public class MeMuevo : MonoBehaviour
{
    [SerializeField] private VectorYef displacement, velocity, aceleration, damping;
    [SerializeField] private float Xborde, Yborde;
    [SerializeField] private GameObject otherBall;


    public void Move()
    {
        velocity = velocity + aceleration * Time.deltaTime;
        displacement = velocity * Time.deltaTime;
        
        
        transform.position = transform.position + displacement;
        
        
        
        aceleration.Draw(new VectorYef(transform.position.x,transform.position.y), Color.blue);
        velocity.Draw(new VectorYef(transform.position.x,transform.position.y), Color.green);
        transform.position.Draw(Color.red);
        
    }
    

    // Update is called once per frame
    void Update()
    {
        MoveForwardBall();
    }

    private void CheckCollisions() {

        if (transform.position.x >= Xborde || transform.position.x <= -Xborde) {

            if (transform.position.x >= Xborde) transform.position = new Vector3(Xborde, transform.position.y, 0);
            if (transform.position.y <= -Xborde) transform.position = new Vector3(-Xborde, transform.position.y, 0);
            velocity.X = velocity.X * -1;
            velocity.X = velocity.X * damping.X;
        }

        if (transform.position.y >= Yborde || transform.position.y <= -Yborde)
        {
            if (transform.position.y >= Yborde) transform.position = new Vector3(transform.position.x, Yborde, 0);
            if (transform.position.y <= -Yborde)  transform.position = new Vector3(transform.position.x, -Yborde, 0);
            velocity.Y = velocity.Y * -1;
            velocity.Y = velocity.Y * damping.Y;
        }
    }

    private void MoveForwardBall()
    {
        aceleration = new VectorYef(otherBall.transform.position.x, otherBall.transform.position.y) 
                      - new VectorYef(this.transform.position.x, this.transform.position.y);

        velocity = velocity + aceleration * Time.deltaTime;
        displacement = velocity * Time.deltaTime;
        
        transform.position = transform.position + displacement;
        
        aceleration.Draw(new VectorYef(transform.position.x,transform.position.y), Color.blue);
        velocity.Draw(new VectorYef(transform.position.x,transform.position.y), Color.green);
        transform.position.Draw(Color.red);
    }
}
