using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] float throwForceInXandY = 1f; //to control throw force in x and y direction 
    [SerializeField] float throwForceInZ = 5f; //to control throw force in z direction 
    [SerializeField] GameObject gamemanager;
    gameManager gm;


    Vector2[] startPos = new Vector2[] { new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0) };
    Vector2[] endPos = new Vector2[] { new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0) };
    //bool[] isHit = new bool[] {false,false,false };
    Rigidbody[] proj = new Rigidbody[] { null, null, null };

    private void Start()
    {
        gm = gamemanager.GetComponent<gameManager>();
    }
    void Update()
    {

        //print("tabdehit= " + isHit[0].ToString() + isHit[1].ToString() + isHit[2].ToString()+ "nombres de doigt= "+ Input.touchCount);
        for (int i = 0; i < Input.touchCount; i++)
        {


            if (Input.touchCount > 0 && Input.GetTouch(i).phase == TouchPhase.Began)
            {
                gm.interact();

                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {

                    if (hit.collider.tag == "fish" || hit.collider.tag == "bomb")
                    {

                        Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red, 1);
                        hit.rigidbody.name = hit.collider.gameObject.name;

                        if (hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic)
                        {

                            proj[i] = hit.collider.gameObject.GetComponent<Rigidbody>();
                            hit.collider.gameObject.name = hit.collider.gameObject.name + 1;

                            startPos[i] = Input.GetTouch(i).position;
                            print("objtab1 : " + " 1= " + proj[0] + " 2= " + proj[1] + " 3= " + proj[2]);


                        }
                    };
                }
            }
            //if you release the finger
            if (Input.touchCount > 0 && Input.GetTouch(i).phase == TouchPhase.Ended && proj[i] != null)
            {
                print("objtab2 : " + " 1= " + proj[0] + " 2= " + proj[1] + " 3= " + proj[2]);
                print("oui");
                endPos[i] = Input.GetTouch(i).position;

                Vector2 direction = startPos[i] - endPos[i];
                if (direction.magnitude != 0)
                {
                    float dirYClamp = Mathf.Clamp(-direction.y * throwForceInXandY, 0, 250);
                    print("objtab3 : " + " 1= " + proj[0] + " 2= " + proj[1] + " 3= " + proj[2]);
                    proj[i].isKinematic = false;
                    print("objtab4 : " + " 1= " + proj[0] + " 2= " + proj[1] + " 3= " + proj[2]);
                    proj[i].AddForce(Vector2.Distance(startPos[i], endPos[i]) * 0.3f, dirYClamp, direction.x * throwForceInXandY);
                }

                proj[i] = null;
                print("objtab5 : " + " 1= " + proj[0] + " 2= " + proj[1] + " 3= " + proj[2]);

            }

        }


    }
    void Launch(Vector2 startPos, Vector2 endPos, Rigidbody proj)
    {
        Vector2 direction = startPos - endPos;
        if (direction.magnitude != 0)
        {
            float dirYClamp = Mathf.Clamp(-direction.y * throwForceInXandY, 0, 250);
            proj.isKinematic = false;
            proj.AddForce(Vector2.Distance(startPos, endPos) * 0.3f, dirYClamp, direction.x * throwForceInXandY);
        }
    }
    bool checkname(GameObject objname)
    {
        for (int i = 0; i < proj.Length; i++)
        {
            if (proj[i] != null)
            {
                if (proj[i].gameObject == objname)
                {
                    return false;
                }
            }
        }
        return true;

    }
}
    /*public void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}
   void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb=GetComponent<Rigidbody>();

        }

    }
   */
 

