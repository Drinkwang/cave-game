using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Game : MonoBehaviour
{
    public GameObject sword;
    public static Game _instant;
    public bool once = false;
    public int health = 3;
    public GameObject[] heart;
   public  Color prefer,bad;
    public GameObject Arrouce;
    private Text ArrouceTEXT;
    public GameObject cabin;
    public GameObject chooseOne;
    public GameObject MiniminigameFixgame;
    public GameObject hammer;
    public GameObject[] nail;
    public GameObject one, two;
    public GameObject[] ITEM;
    public GameObject end;
    public float x;
    public GameObject baiduyun;
    private bool mini=false;
    private int move=1;
    public int score = 0;
    public GameObject guard;
    public bool isads;
    

    public  void changetext(string x)
    {
        ArrouceTEXT.text = x;
    }

  
    public int isclickbridge
    { get; private set; } 
    // Use this for initialization
  
    void Start()
    {
        isads = false;
        _instant = this;
        isclickbridge = 0;
        ArrouceTEXT = Arrouce.transform.GetChild(1).gameObject.GetComponent<Text>();
        DontDestroyOnLoad(this.transform.parent);
        prefer = new Color(); 
 bad = new Color();
        bad= heart[0].GetComponent<Image>().color; prefer = heart[0].GetComponent<Image>().color;        
    }

    // Update is called once per frame
    void Update()
    {if (Input.GetKeyDown(KeyCode.Escape))
        {Destroy(transform.parent.gameObject);
            Application.LoadLevel(0);
        }
        uponbridge();
        if (mini == true)
        { minigame(); }
    }
   public  void Damage(int d)
    {
        GetComponent<AudioSource>().Play();
        health-=d;
        switch (health)
        {
            case 3:
                heart[0].GetComponent<Image>().color = prefer;
                heart[1].GetComponent<Image>().color = prefer;
                heart[2].GetComponent<Image>().color = prefer;
                break;
            case 2:
                while (bad.a>0)
                { bad.a -= 0.1f;
                    heart[0].GetComponent<Image>().color = bad;
                    heart[1].GetComponent<Image>().color = prefer;
                    heart[2].GetComponent<Image>().color = prefer;
                    StartCoroutine(wait(0.05f));
                } bad.a = 1; break;
            case 1:
                while (bad.a>0)
                {
                    bad.a -= 0.1f;

                    heart[1].GetComponent<Image>().color = bad;
                    heart[2].GetComponent<Image>().color = prefer;
                    StartCoroutine(wait(0.05f));
                }
                bad.a = 1;  break;
            case 0:
                while (bad.a > 0)
                {
                    bad.a -= 0.1f;
                   
                    guard.transform.position = new Vector3(guard.transform.position.x+2.5f, guard.transform.position.y, guard.transform.position.z);
                    
                    heart[2].GetComponent<Image>().color = bad;
                    StartCoroutine(wait(0.05f));
                }
                bad.a = 1; guard.GetComponent<AudioSource>().Play();
                Arrouce.SetActive(true);
                one.SetActive(false);
                two.SetActive(false);
                ArrouceTEXT.text="你被警卫捉住了，Game over，按Esc重新开始游戏"; break;
        }
    }
    IEnumerator wait(float t){

            yield return new WaitForSeconds(t);
        }
    public void StartGame() {
    
        Arrouce.SetActive(false);
        ArrouceTEXT.text = "";
    }
    public void changeclickbridge()
    {
        ArrouceTEXT.text = "这是一个地下洞穴，不过这个地方黑黑的，你的心怕怕的！";
        Arrouce.SetActive(true);
        //        
    }
    public void explore()
    { once = true;
        if (isclickbridge!=1)
        one.gameObject.SetActive(false);
          if(GameObject.Find("underbridge"))     isclickbridge++;  }
    public void NO() {
        if (Application.loadedLevel == 1)
        { GameObject.FindGameObjectWithTag("MainCamera").GetComponent<holychoose>().chooese[0].SetActive(true);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<holychoose>().chooese[1].SetActive(true);
        }
        end.SetActive(false);
        baiduyun.SetActive(false);
        Arrouce.SetActive(false);
        one.gameObject.SetActive(true);
        if (isclickbridge == 2)
        { isclickbridge--; one.GetComponentInChildren<Text>().text = "探索"; }
        MiniminigameFixgame.SetActive(false);
    }
void uponbridge()
{
    
        if (once == true) if (isclickbridge == 1)
            {
                ArrouceTEXT.text += "在这地方伸手不见五指，你很难在这样的环境下找到其他东西";
                once = false;
            }
            else if (isclickbridge == 2)
            {
                ArrouceTEXT.text += "你终于从黑暗处发现了一个木桶，但是木桶已经不能用了";
                one.transform.GetComponentInChildren<Text>().text = "修复它";
                once = false;
            }
            else if (isclickbridge == 3)
            {//游戏环节
                nail[0].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(x = Random.Range(-280, 280), -8.999989f, 0);
                nail[1].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(x = Random.Range(-280, 280), -8.999989f, 0);
                nail[2].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(x = Random.Range(-280, 280), -8.999989f, 0);

                two.SetActive(false);
                ArrouceTEXT.text = "你需要在锤子每次与漏洞的钉子刚好重合，按下鼠标，即可修复一处。当你修好三处，任务完成，否则则失败！";
                once = false;
                mini = true;
                MiniminigameFixgame.SetActive(true);
            }
            else if (isclickbridge == 4)
            {
                
                ArrouceTEXT.text = "你再次进入了洞穴，这回是真的找不到东西了";
                once = false;
            }

            else if (isclickbridge == 5)
            {
                Damage(1); ArrouceTEXT.text = "你再进入洞穴时候收到惊吓，失去一点生命值！";
                once = false;
            }
            else if (isclickbridge > 5) { one.gameObject.SetActive(false); ArrouceTEXT.text = "无功而返..."; }
    }
    void minigame() {
        if (Input.GetMouseButtonDown(0))
        { hammer.GetComponent<Animator>().SetTrigger("duang");
            hammer.GetComponent<AudioSource>().Play(); }
        if (hammer.GetComponent<RectTransform>().anchoredPosition.x < -360 || hammer.GetComponent<RectTransform>().anchoredPosition.x > 340)
            move = -move;
            hammer.transform.position = new Vector3(hammer.transform.position.x - move, hammer.transform.position.y, hammer.transform.position.z);
        if (score == 3)
        { changetext("你已经修好了水桶，你将其取走");
            one.GetComponentInChildren<Text>().text = "探索";
            mini = false;
            two.SetActive(true);
            ITEM[5].SetActive(true);
        }
    }
   
    
  
}
