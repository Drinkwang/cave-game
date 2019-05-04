using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class skip : MonoBehaviour {
   
    private Game game=Game._instant;
	// Use this for initialization
	void Start () {
        game = GameObject.FindGameObjectWithTag("game").GetComponent<Game>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D HIT;

            HIT = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            if (HIT.collider == null||game.cabin!=null||game.Arrouce.activeSelf==true) { return; }
            if (HIT.transform.name == "windows")
            { SceneManager.LoadScene("window");
                game.Arrouce.SetActive(true);
                game.one.SetActive(false);
                game.two.SetActive(true);
                game.changetext("这个地方根本就走不完，你充满了恐惧，这个地方声音听起来太怪了...");

            }
            else if (HIT.transform.name == "underbridge")
            { game.changeclickbridge(); }
            else if (HIT.transform.name == "leftcave")
            { SceneManager.LoadScene("cave"); }
            else if (HIT.transform.name == "rope")
            { game.changetext("这些木板散落了许多绳子    你顺势拿走了一些");
                game.Arrouce.SetActive(true);
                game.one.SetActive(false);
                game.two.SetActive(true);
                game.ITEM[0].SetActive(true);
            }
            }
	
	}
  
}
