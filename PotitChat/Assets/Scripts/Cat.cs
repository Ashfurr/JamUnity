using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{
    [SerializeField] GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="fish")
        {
            Destroy(collision.gameObject);
            gameManager.GetComponent<gameManager>().setScore(gameManager.GetComponent<gameManager>().getScore()+10);
            print("poisson");
            
        }
        if (collision.gameObject.tag == "bomb")
        {
            Destroy(collision.gameObject);
            gameManager.GetComponent<gameManager>().setScore(gameManager.GetComponent<gameManager>().getScore() - 10);
            print("bomb");

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
