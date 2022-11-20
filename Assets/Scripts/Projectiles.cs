using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float throwForceInXandY = 1f; //to control throw force in x and y direction 
    [SerializeField] float throwForceInZ = 5f; //to control throw force in z direction 
    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;
    Rigidbody rb;
    public bool alive = false;
    private Vector3 tempscale ;

    private void Start()
    {
        tempscale = transform.localScale;
       
    }

  
    // Update is called once per frame
    void Update()
    {
       
       
        //if you touch the screen
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && rb !=null)
            {
            
                //gettinf touch position and marking time when you touch the screen
                touchTimeStart = Time.time;
                startPos = Input.GetTouch(0).position;

            }
            //if you release the finger
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended&& rb != null)
            {
                //marking time when you release it
                touchTimeFinish = Time.time;
                //calculate swipe time interval
                timeInterval = touchTimeFinish - touchTimeStart;
                //getting release finge rposition
                endPos = Input.GetTouch(0).position;

                //calculate swpie direction in 2d Space
                direction = startPos - endPos;
                
                //add force to fish rigidbody in 3d space depending on swipe time, direction adn throw forces 
                if (direction.magnitude != 0)
                {
                float dirYClamp = Mathf.Clamp(-direction.y * throwForceInXandY, 0, 250);
                rb.isKinematic = false;
              
                rb.AddForce(Vector2.Distance(startPos,endPos)*0.3f, dirYClamp, direction.x * throwForceInXandY);
                //throwForceInZ / timeInterval
                rb = null;
                alive = true;
                Destroy(gameObject, 5);
                print("oui");
            }

            }
        
    }
   
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb=GetComponent<Rigidbody>();
            
            //transform.localScale = tempscale + new Vector3(0.2f,0.2f,0.2f);
     
        }
    }
 
}
