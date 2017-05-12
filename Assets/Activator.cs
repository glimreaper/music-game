using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour {
    SpriteRenderer sr;
    public KeyCode key;
    bool isactive = false;
    GameObject note, gm;
    public AudioClip hitsound;
    private AudioSource source;
    Color old;
    public bool createMode;
    public GameObject n; //note for timing

	// Use this for initialization
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
    }

    void Start () {
        gm = GameObject.Find("GameManager");
        old = sr.color;
	}
	
	// Update is called once per frame
	void Update () {
        if (createMode && Input.GetKeyDown(key))
        {
            if (Input.GetKeyDown(key))
            {
                //source.PlayOneShot(hitsound, 0.3F);
                Instantiate(n, transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetKeyDown(key))
            {
                StartCoroutine(Pressed());
            }
            if (Input.GetKeyDown(key) && isactive)
            {
                Destroy(note);
               // source.PlayOneShot(hitsound, 0.3F);
                isactive = false;
                gm.GetComponent<GameManager>().AddStreak(); 
                AddScore();
                

            }
            else if (Input.GetKeyDown(key)&& !isactive)
            {
                gm.GetComponent<GameManager>().ResetStreak();
            }

        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        isactive = true;
        if(col.gameObject.tag == "Note")
        {
            note = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        isactive = false;
        gm.GetComponent<GameManager>().ResetStreak();
    }

    void AddScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + + gm.GetComponent<GameManager>().GetScore());
    }

    IEnumerator Pressed()
    {
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        sr.color = old;
        
    }
}
