using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Video;
using RenderHeads.Media.AVProVideo;

public class holychoose : MonoBehaviour {
    private int explorX;
    public Image toyoungtosimple;
    private Color color;
    private bool boolap=false;
    public GameObject end;
    public GameObject endmovie;
    private bool movieplay=false;
    public AudioClip xxx;
    private int randompotion;
    private int randomMAx;
   public  GameObject[] chooese;
    public GameObject canvas;
    public MediaPlayer mediaplayer;

    public int windowleft = 0;
    //public VideoPlayer t;
   
    // Use this for initialization
    void Start() {
        randomMAx = 100;
      //  endmovie.loop = false;
        color = toyoungtosimple.color;
    
    }

    // Update is called once per frame
    void Update() { 

    }
    public void explore() {
        chooese[0].SetActive(false);
        chooese[1].SetActive(false);

        explorX = Random.Range(0, randomMAx);
        if (explorX > 95)
        {
            Game._instant.sword.SetActive(true);
            Game._instant.sword.GetComponent<AudioSource>().Play();
            explore("这里有一把刀，述说着“恶魔”和他勇士的故事，刀上残留着家人的鲜血，是只为内心的“正义”？登上权利宝座，还曾记得？？，这声音残留在你的脑海里"); randomMAx = 80; }
       
        else if (explorX > 50) { explore("你在这片无尽阶梯上行走时候，然而并没有发生任何事情。");}
        else if (explorX > 30) {
         
            randompotion = Random.Range(1, 4);
            Game._instant.ITEM[randompotion].SetActive(true);
            explore("你在这片无尽阶梯上行走时候，走进了一个貌似是一所炼金房的小屋，在这里面有着各式各样的药品，你随手一哈，捞了瓶不知名的药品！你获得了"+Game._instant.ITEM[randompotion].name);
        }
        else if (explorX > 10) {
            explore("你在这片无尽阶梯上行走时候，遇到了一个奇怪的蛋糕，当然你没有胆量吃掉它...");
            Game._instant.end.SetActive(true);
        }
        else if (explorX > 0) { explore("你在这片无尽阶梯上行走时候，眼前突然泛出白光，配合这里呼 ~呼~呼~的声音，着实吓坏了你，你失去了一点生命值。");
            Game._instant.Damage(1);
        }
    }
    void appear() { color.a+=0.1f;
        toyoungtosimple.color = color;
        print(toyoungtosimple.color.a);
    }

    public void No()
    {if (windowleft == 0)
        {
            explore("你想要从这里离开，但是你发现这里根本没有回来的路...");
            chooese[1].GetComponentInChildren<Text>().text = "狂跑";
            windowleft++;
            return;
        }
        if (windowleft == 1)
        {
            explore("你离开了这，但是损失了一点体力（想好再进来吧）...");
            chooese[1].GetComponentInChildren<Text>().text = "狂跑";
            windowleft = 0;
            Application.LoadLevel("2");
            Game._instant.Damage(1);
            
        }
    }

    public void usedwater()
    {
        if (Game._instant.ITEM[4].activeSelf == true && boolap == false)
        {
         
            {
                Invoke("appear", 0.05f);
                if (toyoungtosimple.color.a > 0.9)
                {
                    toyoungtosimple.gameObject.GetComponentInChildren<Text>().text = "饮用桶里的水";
                    boolap = true;
                    
                }

            }
        }
        if (boolap == true)
        {
            chooese[0].SetActive(false);
            chooese[1].SetActive(false);
            explore("你喝下了这桶里的水，这水让你困意绵绵，你似乎睡着了....");
            Game._instant.one.SetActive(false);
            Game._instant.two.SetActive(false);
            end.SetActive(true);
          
        }
    }

void explore(string x)
    {
        Game._instant.Arrouce.SetActive(true);
        Game._instant.one.SetActive(false);
        Game._instant.two.SetActive(true);
        Game._instant.changetext(x);
    }
    /*
    
    
*/
    public void playmovie() {
        //canvas.SetActive(false);
      //  t.Play();
      //  GetComponent<AudioSource>().loop = false;
        //GetComponent<AudioSource>().Play();
        end.SetActive(false);
        endmovie.SetActive(true);
        endmovie.GetComponent<DisplayUGUI>()._mediaPlayer = mediaplayer;
        mediaplayer.Control.Play();
        StartCoroutine("tisme", 17.8f);
       
        movieplay = true;
    }
    IEnumerator tisme(float t)
    {
        //Debug.Log("dd");
        yield return new WaitForSeconds(t);
        endmovie.GetComponentInChildren<Text>().enabled = true;
    }

}
