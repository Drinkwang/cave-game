using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class boom : MonoBehaviour {
    public GameObject cage;
    public GameObject scrobar;
    public GameObject BG, alert, endText;
    public float t;
    public bool timeend,doorclosed,AlertB=false;
    public int RD;  
    // Use this for initialization
    void Start() {
        timeend = false;
        doorclosed = true;
    }

    // Update is called once per frame
    void Update() { if (timeend == true) t = t + Time.deltaTime;

        if (cage!=null)
cage.transform.position = Vector3.Lerp(cage.transform.position, new Vector3(cage.transform.position.x, cage.transform.position.y - 5, cage.transform.position.z), t);

        if (t > 1) {
            Destroy(scrobar);
            Destroy(cage);
            timeend = false;
            if(endText!=null)
            endText.SetActive(true);
            Destroy(endText, 4f);
          

        }
    }
    public void buttonup() {
        if (AlertB == true)
        { Debug.Log("啊，被发现啦！生命值-1！");
            GetComponent<ShakeCamera>().shake();

            Game._instant.Damage(1);
        }
        RD = Random.Range(0,8);
        if (RD == 1) { BG.GetComponent<SpriteRenderer>().color =Color.red;
            AlertB = true;
            StartCoroutine(Alert());
            alert.SetActive(true);
            BG.GetComponent<AudioSource>().Play();
        }
        scrobar.GetComponent<Scrollbar>().size = scrobar.GetComponent<Scrollbar>().size - 0.05f;
        cage.GetComponent<AudioSource>().PlayScheduled(5f);
        // cage.transform.position = Vector3.Lerp(,, t);
        if (scrobar.GetComponent<Scrollbar>().size == 0)
        {
            if (doorclosed == true)

            { OpenDoor(); timeend = true; } }
        
    }
    public void OpenDoor()
    {
        this.GetComponent<AudioSource>().Play();
        doorclosed = false;

    }
    IEnumerator Alert() {
        yield return new WaitForSeconds(6.2f);
        BG.GetComponent<SpriteRenderer>().color = Color.white;
        if(alert!=null)
        alert.SetActive(false);
        AlertB = false;
    }

    
}
