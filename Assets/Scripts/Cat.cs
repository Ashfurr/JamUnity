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
    private gameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        Vibration.Init();
        gm =gameManager.GetComponent<gameManager>();
        animator = GetComponent<Animator>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="fish")
        {
            Destroy(collision.gameObject);
            gm.setScore(gm.getScore() + gm.getFishPoint());
            Instantiate(fxHitFish, new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z), Quaternion.identity);
            animator.SetTrigger("eat");
           
            
        }
        if (collision.gameObject.tag == "bomb")
        {
            Destroy(collision.gameObject);
            gm.setScore(gm.getScore() + gm.getBombPoint());
            Instantiate(fxHitBomb, collision.transform.position, Quaternion.identity);
            animator.SetTrigger("hit");
            Vibration.VibratePeek();
           

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
