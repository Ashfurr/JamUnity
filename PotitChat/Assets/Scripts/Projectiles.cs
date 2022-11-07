using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] float speed;
    
    public bool alive=false;
    // Start is called before the first frame update
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * speed);
            alive=true;
            Destroy(gameObject, 5);
        }
    }
    private void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
