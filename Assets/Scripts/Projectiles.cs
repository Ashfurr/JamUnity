using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] float throwForceInXandY = 1f; //to control throw force in x and y direction 
    [SerializeField] float throwForceInZ = 5f; //to control throw force in z direction 
    Vector2[] startPos, endPos;
    float touchTimeStart, touchTimeFinish;

    public List<touchLocation> touches = new List<touchLocation>();


    public bool alive = false;
    private Vector3 tempscale;

    private void Start()
    {
        tempscale = transform.localScale;

    }


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);


            if (Input.touchCount > 0 && t.phase == TouchPhase.Began)
            {

                Ray ray = Camera.main.ScreenPointToRay(t.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {

                    if (hit.collider.tag == "fish" || hit.collider.tag == "bomb")
                    {
                        Rigidbody rb = hit.rigidbody;
                        rb.name = "Touch" + t.fingerId;
                        touches.Add(new touchLocation(t.fingerId, rb));



                    };
                }

                //gettinf touch position and marking time when you touch the screen
               
                startPos[i] = t.position;

            }
            //if you release the finger
            if (Input.touchCount > 0 && t.phase == TouchPhase.Ended)
            {

                //getting release finge rposition
                endPos[i] = t.position;

                //calculate swpie direction in 2d Space
                Vector2 direction = startPos[i] - endPos[i];
                Launch(direction, startPos[i], endPos[i], t);

                
            }

        }

    }



    void Launch(Vector2 direction, Vector2 startPos, Vector2 endPos, Touch t)
    {
        if (direction.magnitude != 0)
        {
            touchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchId == t.fingerId);
            Rigidbody rb = thisTouch.projectil;
            if(rb == null)
            {
                touches.Clear();
            }

            float dirYClamp = Mathf.Clamp(-direction.y * throwForceInXandY, 0, 250);
            rb.isKinematic = false;

            rb.AddForce(Vector2.Distance(startPos, endPos) * 0.3f, dirYClamp, direction.x * throwForceInXandY);

            touches.RemoveAt(touches.IndexOf(thisTouch));
        }
    }
}
   /* void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb=GetComponent<Rigidbody>();

        }

    }
   */
 

