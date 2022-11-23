using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    
    [SerializeField] GameObject fish;
    [SerializeField] GameObject bomb;
    [SerializeField] ParticleSystem fxSpawn;
    [SerializeField] GameObject gameManager;
    private gameManager gm;
    private bool CanSpawn = true;
    private GameObject liveObject = null;
    private GameObject liveObjecttmp = null;
    private int compteur = 0;
    private  bool tuto = false;
    
    private void Awake()
    {
        gm=gameManager.GetComponent<gameManager>();
    }
    private void Start()
    {
        liveObject = Instantiate(fish, new Vector3(this.transform.position.x, this.transform.position.y + 0.3f, this.transform.position.z), Quaternion.identity);
        StartCoroutine(checkTuto());
        StartCoroutine(timerSpawn());
       
    }
    
    IEnumerator timerSpawn ()
    {
        while (true) {
            if (CanSpawn&&tuto)
            {
                
                Spawn();
                yield return new WaitForSeconds(gm.getRespawnTimer());
                if (liveObject != null && liveObject.GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0))
                {
                    if (liveObject.name == liveObjecttmp.name)
                    {
                        Destroy(liveObject);
                    }
                }
            }
            CanSpawn = true;
            yield return new WaitForSeconds(0.1f);
        }
        
        /*if(liveObject != null)
        {
            Destroy(liveObject,7);
        }*/

    }
    IEnumerator checkTuto()
    {
        bool run = true;
        while (run)
        {
            if (gm.intro)
            {
                if(liveObject  != null)
                {
                    Destroy(liveObject, 4f);
                }
                
                tuto = true;
                run = false;
            }
            yield return new WaitForSeconds(0.5f);
        }
        

    }
    void Spawn()
    {
        
        int random = Random.Range(0, 2);
        
        if ( random == 1)
        {
            compteur++;
            liveObject = Instantiate(fish, new Vector3(this.transform.position.x, this.transform.position.y + 0.3f, this.transform.position.z), Quaternion.identity);
            Instantiate(fxSpawn,new Vector3(this.transform.position.x, this.transform.position.y + 0.3f, this.transform.position.z), Quaternion.identity);
            liveObject.gameObject.name = gameObject.name + compteur.ToString();
            liveObjecttmp=liveObject;

            CanSpawn = false;
        }
        else
        {
            compteur++;
            liveObject = Instantiate(bomb, new Vector3(this.transform.position.x, this.transform.position.y + 0.3f, this.transform.position.z), Quaternion.identity);
            Instantiate(fxSpawn, new Vector3(this.transform.position.x, this.transform.position.y + 0.3f, this.transform.position.z),Quaternion.identity);
            CanSpawn = false;
            liveObject.gameObject.name = gameObject.name + compteur.ToString();
            liveObjecttmp = liveObject;
        }
    }
}
