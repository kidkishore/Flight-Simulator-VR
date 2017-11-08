using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class flightAction : MonoBehaviour
{


     float speed;
     float horizontal;
     float vertical;
    float shoot;
    //GameObject camera;
    float rot_speed = 7f;
    bool cast;
    LayerMask mask;
    float step_x=180;
    float step_z = 0;
    int score = 0;
    Text score_text;
    Text final_score_text;
    GameObject score_text_object;
    GameObject final_score_text_object;
    GameObject startMenu;
    GameObject pauseMenu;
    GameObject endMenu;

    bool gamePaused = true;
    bool start_menu_on = true;
    bool gameEnd = false;
    float i = 0;
    float i1 = 0;
    float i2 = 0;
    float i3 = 0;
    float i4 = 0;
    float i5 = 0;
    float i6 = 0;
    float i7 = 0;


    GameObject sphere;
    GameObject sphere1;
    GameObject sphere2;
    GameObject sphere3;
    GameObject sphere4;
    GameObject sphere5;
    GameObject sphere6;
    GameObject sphere7;

    public AudioClip shootingNoise;
    public AudioSource shootingSource;




    void Start()
    {

        shootingSource.clip = shootingNoise;
        sphere = GameObject.Find("Sphere");
        sphere1 = GameObject.Find("Sphere (1)");
        sphere2 = GameObject.Find("Sphere (2)");
        sphere3 = GameObject.Find("Sphere (3)");
        sphere4 = GameObject.Find("Sphere (4)");
        sphere5 = GameObject.Find("Sphere (5)");
        sphere6 = GameObject.Find("Sphere (6)");
        sphere7 = GameObject.Find("Sphere (7)");

        score_text_object = GameObject.Find("Score Text");
        final_score_text_object = GameObject.Find("final score");
        startMenu = GameObject.Find("start");
        pauseMenu = GameObject.Find("pause");
        endMenu = GameObject.Find("end");
        score_text = score_text_object.GetComponent<Text>();
        final_score_text = final_score_text_object.GetComponent<Text>();
        score_text.text = "Current Score:" + score;
        score_text_object.SetActive(false);
        endMenu.SetActive(false);
        pauseMenu.SetActive(false);





    }
    // Update is called once per frame
    void Update()
    {

        

        if (Input.GetButton("A"))
        {
            if (!gameEnd) { 
                startMenu.SetActive(false);
                score_text_object.SetActive(true);
                gamePaused = false;
                start_menu_on = false;
                pauseMenu.SetActive(false);
                }
        }

        if (Input.GetButton("Y"))
        {
            if ((gamePaused || gameEnd) && start_menu_on==false )
                SceneManager.LoadScene(0);

        }

        if (Input.GetButton("B"))
        {
                if (!gameEnd)
                {
                    pauseMenu.SetActive(true);
                    score_text_object.SetActive(false);
                    gamePaused = true;
                }
            
        }

        if (!gamePaused && !gameEnd)
        {

            speed = Input.GetAxis("Speed");
            horizontal = Input.GetAxis("Horizontal Rotation");
            vertical = Input.GetAxis("Vertical Rotation");
            //camera = GameObject.Find("Main Camera");
            shoot = -Input.GetAxis("Right Trigger");
            RaycastHit hit;

            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            cast = Physics.Raycast(transform.position, fwd, out hit, 150f);



            if (cast && hit.collider.gameObject.name != "Terrain" && shoot > 0.2)
            {
                shootingSource.Play();
                hit.collider.gameObject.SetActive(false);
                GameObject hit_obj = hit.collider.gameObject;
                if(hit_obj == sphere)
                    i = 0;
                else if (hit_obj == sphere1)
                    i1 = 0;
                else if (hit_obj == sphere2)
                    i2 = 0;
                else if (hit_obj == sphere3)
                    i3 = 0;
                else if (hit_obj == sphere4)
                    i4 = 0;
                else if (hit_obj == sphere5)
                    i5 = 0;
                else if (hit_obj == sphere6)
                    i6 = 0;
                else if (hit_obj == sphere7)
                    i7 = 0;

                score++;
                score_text.text = "Current Score:" + score;
            }

            i += Time.deltaTime;
            i1 += Time.deltaTime;
            i2 += Time.deltaTime;
            i3 += Time.deltaTime;
            i4 += Time.deltaTime;
            i5 += Time.deltaTime;
            i6 += Time.deltaTime;
            i7 += Time.deltaTime;

            if (i > 5f)
                sphere.SetActive(true);
            if (i1 > 5f)
                sphere1.SetActive(true);
            if (i2 > 5f)
                sphere2.SetActive(true);
            if (i3 > 5f)
                sphere3.SetActive(true);
            if (i4 > 5f)
                sphere4.SetActive(true);
            if (i5 > 5f)
                sphere5.SetActive(true);
            if (i6 > 5f)
                sphere6.SetActive(true);
            if (i7 > 5f)
                sphere7.SetActive(true);






            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * (-(speed * 0.8f - 1) * 6F + 2F));
            transform.Rotate(new Vector3(0, 0.6f, -0.8f) * (horizontal * 60f) * Time.deltaTime);
            transform.Rotate(Vector3.right * (vertical * 60f) * Time.deltaTime);

            step_x = transform.rotation.eulerAngles.x;
            step_z = transform.rotation.eulerAngles.z;
            //Debug.Log(step_x);

            if (step_x > 1 && step_x < 179)
            {
                step_x = step_x - rot_speed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(step_x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            }

            if (step_x > 180 && step_x < 360)
            {
                step_x = step_x + rot_speed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(step_x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            }

            if (step_z > 1 && step_z < 179)
            {
                step_z = step_z - rot_speed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, step_z);
            }

            if (step_z > 180 && step_z < 360)
            {
                step_z = step_z + rot_speed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, step_z);
            }

           

        }



    }


    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Terrain")
        {
            shootingSource.Play();
     
            endMenu.SetActive(true);
            score_text_object.SetActive(false);
            gamePaused = true;
            gameEnd = true;
            final_score_text.text = "Final Score: " + score;
        }
    }

}
