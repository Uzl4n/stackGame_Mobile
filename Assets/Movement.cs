using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public static float lastY = 0.8f;
    public static float count = 1;
    private bool stoped = false;


    public static int score = 0;
    public Text scoreUI;

    private bool hasColided = false;

    

    void Start()
    {
        
        scoreUI = GameObject.Find("score").gameObject.GetComponent<Text>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Rigidbody>() == null) {
            transform.position += new Vector3(0, 0, 0.02f);
        }

        if (Input.GetKeyUp(KeyCode.Space) && stoped == false || Input.touchCount>0 && Input.touches[0].phase == TouchPhase.Began && stoped == false)
        {
            
            
            
            this.gameObject.AddComponent<Rigidbody>();
            
            stoped = true;
            
        }

        if (transform.position.y < 0)
        {
            Application.LoadLevel(Application.loadedLevel);
            lastY = 0.8f;
            score = 0;
        }

        

    }

    void OnCollisionEnter(Collision col)
    {
        if(hasColided == false)
        {
            hasColided = true;
            score++;
            scoreUI.text = score.ToString();
            GameObject cube = Instantiate(Resources.Load("CubeBase", typeof(GameObject)) as GameObject, new Vector3(0, lastY + 0.5f, 1.149f), Quaternion.Euler(0, 0, 0));
            lastY = transform.position.y;
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 0.02f,Camera.main.transform.position.z);
            cube.AddComponent<Movement>();
        }
    }



    
}
