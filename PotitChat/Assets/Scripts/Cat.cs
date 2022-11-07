using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    [SerializeField] ParticleSystem fxHitFish;
    [SerializeField] ParticleSystem fxHitBomb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="fish")
        {
            Destroy(collision.gameObject);
            gameManager.GetComponent<gameManager>().setScore(gameManager.GetComponent<gameManager>().getScore()+10);
            Instantiate(fxHitFish, new Vector3(collision.transform.position.x, collision.transform.position.y + 0.4f, collision.transform.position.z), Quaternion.identity);
            animator.SetTrigger("eat");
            print("poisson");
            
        }
        if (collision.gameObject.tag == "bomb")
        {
            Destroy(collision.gameObject);
            gameManager.GetComponent<gameManager>().setScore(gameManager.GetComponent<gameManager>().getScore() - 10);
            Instantiate(fxHitBomb, collision.transform.position, Quaternion.identity);
            animator.SetTrigger("hit");
            print("bomb");

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
