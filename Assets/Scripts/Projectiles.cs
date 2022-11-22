using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] float throwForceInXandY = 1f; //to control throw force in x and y direction 
    [SerializeField] float throwForceInZ = 5f; //to control throw force in z direction 


    Vector2[] startPos = new Vector2[] {new Vector2(0,0),new Vector2(0,0), new Vector2(0, 0) };
    Vector2[] endPos = new Vector2[] {new Vector2(0,0),new Vector2(0,0), new Vector2(0, 0) };
    bool[] isHit = new bool[] {false,false,false };
    Rigidbody[] proj = new Rigidbody[] {null,null,null};

    private void Start()
    {
 
    }
    void Update()
    {
        //print("tabdehit= " + isHit[0].ToString() + isHit[1].ToString() + isHit[2].ToString()+ "nombres de doigt= "+ Input.touchCount);
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
                        hit.rigidbody.name = hit.collider.gameObject.name;

                        if (hit.rigidbody.isKinematic && checkname(hit.collider.gameObject.name))
                        {
                            
                            proj[i] = hit.rigidbody;
                            
                            startPos[i] = t.position;

                        }
                    };
                }  
            }
            //if you release the finger
            if (Input.touchCount > 0 && t.phase == TouchPhase.Ended && proj[i]!=null )
            {  
                endPos[i] = t.position;
                Launch(startPos[i], endPos[i], proj[i]);
                print(proj[i]);
                
            }

        }
       

    }
    void Launch(Vector2 startPos, Vector2 endPos,Rigidbody proj)
    {
        Vector2 direction = startPos - endPos;
        if (direction.magnitude != 0)
        {
            float dirYClamp = Mathf.Clamp(-direction.y * throwForceInXandY, 0, 250);
            proj.isKinematic = false;
            proj.AddForce(Vector2.Distance(startPos, endPos) * 0.3f, dirYClamp, direction.x * throwForceInXandY);
        }
    }
    bool checkname(string objname)
    {
        for(int i = 0; i < proj.Length; i++)
        {
            if (proj[i] != null)
            {
                if (proj[i].name == objname)
                {
                    return false;
                }
            }
        }
        return true;

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
 

