using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class Robot : MonoBehaviour
    {
	    private Rigidbody2D rb2D;				//The Rigidbody2D component attached to this object.
        private Animator animator;              //The animator component attached to this object.
        private SpriteRenderer render;          //The SpriteRenderer component attached to this object.
        public float baseSpeed = 3;            //Movespeed of the robot
        public float hoseStrength = 0;         //How fast the hose pushes
        public float maxHoseSpeed = 5;        //Fastest hose will push
        public float accelerationSpeed = 1;    //Rate the hose speeds up
        // Start is called before the first frame update
        void Start()
        {
	        //Get a component reference to this object's Rigidbody2D
	        rb2D = GetComponent <Rigidbody2D>();

            animator = GetComponent<Animator>();

            render = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if(Input.GetMouseButton(0))
            {
                /*
                //Subtract current position from mouse position. Save it to direction.
                Vector2 direction = rb2D.position - new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
                //Normalize the difference. (All values endu up between zero and one in the same ratio)
                direction.Normalize();

                var tmpForce2 = rb2D.position;

                tmpForce2.x -= Input.mousePosition.x;
                tmpForce2.y -= Input.mousePosition.y;
                tmpForce2 = tmpForce2.normalized;
                Debug.Log(tmpForce2);
                tmpForce2.x *= hoseStrength;
                tmpForce2.y *= hoseStrength;
                Debug.Log(tmpForce2);
                //Push robot in the opposite direction of the hose multiplied by the current hose strength.
                rb2D.AddForce(tmpForce2, ForceMode2D.Impulse);
                */
                rb2D.position = Vector2.MoveTowards(rb2D.position, Input.mousePosition, 1*hoseStrength);
                Accelerate();
            }
            else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb2D.velocity = new Vector2(-baseSpeed, 0);
                animator.Play("Left", 0);
            }
            else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb2D.velocity = new Vector2(baseSpeed, 0);
                animator.Play("Right", 0);
            }
            else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                rb2D.velocity = new Vector2(0, baseSpeed);
                animator.Play("Up", 0);
            }
            else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                rb2D.velocity = new Vector2(0, -baseSpeed);
                animator.Play("Forward", 0);
            }
             else if (Input.GetKey(KeyCode.F))
            {
                animator.Play("Dancing", 0);
            }
            //If none of the move keys are pressed
            else
            {
                Stop();
            }
        }
        public void Stop()
        {
            rb2D.velocity = new Vector2(0, 0);
            animator.Play("Idle", 0);
        }
        public void Accelerate()
        {
            if(hoseStrength < maxHoseSpeed)
            {
                hoseStrength += accelerationSpeed;
            }
        }
    }



