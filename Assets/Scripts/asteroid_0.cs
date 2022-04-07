using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid_0 : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    public float asteroidRate=-17f;
    public GameObject explosion;
    int count = 0;
   public GameObject rocket;
    public GameObject bullet;
    public Rigidbody2D rb;
    public Transform Rocket;
   void Start()
    {
        speed=Random.Range(10f,15f);
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector2.down*Time.deltaTime*speed);  
      if (transform.position.y<asteroidRate){
         newAsteroid(); 
      }  
    }
    void newAsteroid(){
        float randomNumber=Random.Range(-11f,11f);
        Vector2 newPosition=new Vector2(randomNumber,7);
        transform.position=newPosition;
        speed=Random.Range(10f,15f);
    }
    void OnTriggerEnter2D(Collider2D other){
        
        if(other.gameObject.CompareTag("Player")){
            GameObject clone =(GameObject)Instantiate(explosion,transform.position,transform.rotation);
            Destroy(other.gameObject);
                        // Debug.Log("Asteroid destroyed");
            Destroy(clone,1.5f);
            count+=1;
            if(count<3){
                 Invoke("showRocket", 1.7f);
            }else if(other.gameObject.CompareTag("bullet")){
                Destroy(bullet);    
            }   else{
                Destroy(this.gameObject);//to stop the asteroids falling
            }    
        }
        if (other.gameObject.CompareTag("Finish") || other.gameObject.CompareTag("Player"))
        {
            newAsteroid();
        }


    }
    void showRocket(){
        Instantiate(rocket);
    }
}
