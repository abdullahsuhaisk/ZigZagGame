using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
public class KarakterController : MonoBehaviour {

    public Rigidbody rb;
    bool sagamibakiyor;
    GameManager gm;
    Animator animController;
    public Transform rayOrijin;
    public GameObject particleprefabs;
    float movespeed = 1;
    float gecensure = 0;

    void Start () {
        sagamibakiyor = true;
        gm = FindObjectOfType<GameManager>();
        //PUBLİC YAPIP ATAMAK GİBİ YADA GETCOMPONENT GİBİ
        animController = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
        gecensure += Time.deltaTime;
        if (gecensure >5)
        {
            gecensure = 0;
            movespeed += 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            yondegistir();
        }
        //if (Input.touchCount > 0)
        //{
        //    if (Input.GetTouch(0).phase == TouchPhase.Began)
        //    {
        //        yondegistir();
        //    }

        //}



        if (transform.position.y < -2)
        {
            gm.RestartGame();
        }
        
	}

    private void yondegistir()
    {
        sagamibakiyor = !sagamibakiyor;

        //İlk işlemden sonra yön SoL

        if (sagamibakiyor) 
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {   //false iken hala yönümüz sağda değişmedi  Sola baktırdı
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }

    private void FixedUpdate()
    {
        if (!gm.isGameStart) return;
        else
        {
            animController.SetTrigger("GameStarted");
            rb.position += transform.forward * Time.deltaTime * movespeed; //Forward İleri Yöndür.

            if (!Physics.Raycast(rayOrijin.position, Vector3.down))
            {
                animController.SetTrigger("fall");
            }
        }
        
    }
    private void OnTriggerEnter(Collider other) //İçinden geçtiğinde tetikleyen
    {
       if(other.gameObject.tag=="Cristal")
        {
            gm.MakeScore();
            GameObject particle= Instantiate(particleprefabs, transform);
            Destroy(other.gameObject);
            Destroy(particle, 1);
            
        }
    }
}
