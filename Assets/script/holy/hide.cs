using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Video;
using RenderHeads.Media.AVProVideo;

public class hide : MonoBehaviour {
    public GameObject input;
    public Text t;
    public GameObject end2;
   // public GameObject end2source;
    public MediaPlayer mediaplayer;
    //public VideoPlayer t2;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void Submit()
    {
        if (input.GetComponent<InputField>().text == "1004")
        {
           // t2.Play();
            print("hahaha");
            // GetComponent<AudioSource>().Play();

            end2.SetActive(true);
            end2.GetComponent<DisplayUGUI>()._mediaPlayer = mediaplayer;
            mediaplayer.Control.Play();
            input.SetActive(false);
           // Destroy(this);
           StartCoroutine("tisme",22.0f);
        }
        else { t.text = "密码错误"; }


    }
    IEnumerator tisme(float t)
    {
        //Debug.Log("dd");
        yield return new WaitForSeconds(t);
        end2.GetComponentInChildren<Text>().enabled = true;
    }
    void OnMouseDown() {
        input.SetActive(true);
        

    }
   
}

