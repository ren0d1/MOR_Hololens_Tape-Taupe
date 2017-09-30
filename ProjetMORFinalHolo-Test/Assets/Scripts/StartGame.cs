using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    public GameObject taupePrefab;
    public GameObject taupeChapeauPrefab;
    public GameObject chatPrefab;
    private List<Transform> trous = new List<Transform>();
    private GameObject creature;
    private int level = 1;
    private int temps = 0;
    private int random;
    private int whichCreature;
    private int hatRand;
    private bool kill = false;

    // Use this for initialization
    void Start () {
        Transform[] temp = FindObjectsOfType(typeof(Transform)) as Transform[];
        foreach (Transform t in temp)
        {
            if(t.name == "Motte de terre")
            {
                trous.Add(t);
            }
        }

        Terrain.getInstance().setRotate(level);
    }

    public void setLevel()
    {
        level = Level.getInstance().getLevel();
        Terrain.getInstance().setRotate(level);
    }

    private void Update()
    {
        if (Time.time > (temps + (5-(level*0.01))))
        {
            temps = (int) Time.time;

            if(creature != null)
            {
                if(!kill)
                {
                    if (creature.GetComponent<Chat>() != null)
                    {
                        Score.getInstance().setScore(creature.GetComponent<Chat>().notHit());
                    }

                    if (creature.GetComponent<Taupe>() != null)
                    {
                        if (!creature.GetComponent<Taupe>().getKill())
                        {
                            Animation anim = creature.GetComponent<Animation>();
                            anim["Take 001"].speed = -1.0f;
                            anim["Take 001"].time = anim["Take 001"].length;
                            anim.Play();
                            kill = true;
                        }
                    }else if (creature.GetComponent<Chat>() != null){
                        if (!creature.GetComponent<Chat>().getKill())
                        {
                            Animation anim = creature.GetComponent<Animation>();
                            anim["Take 001"].speed = -1.0f;
                            anim["Take 001"].time = anim["Take 001"].length;
                            anim.Play();
                            kill = true;
                        }
                    }
                }
            }else{
                kill = false;
                random = Random.Range(0, (trous.Count - 1));
                whichCreature = Random.Range(0, 100);

                if (level <= 50)
                {
                    if (whichCreature < (101 - level))
                    {
                        hatRand = Random.Range(1, 100);

                        if (hatRand > 75)
                        {
                            creature = Instantiate(taupeChapeauPrefab, trous[random].position, Quaternion.Euler(0, 180, 0));
                            creature.transform.parent = trous[random];
                            Animation anim = creature.GetComponent<Animation>();
                            anim["Take 001"].speed = 2f;
                            anim.Play();
                            creature.GetComponent<Taupe>().setRotate(level);
                            creature.GetComponent<Taupe>().setCasque(true);
                            creature.GetComponent<Taupe>().setPoints(15);
                        }else{
                            creature = Instantiate(taupePrefab, trous[random].position, Quaternion.Euler(0, 180, 0));
                            creature.transform.parent = trous[random];
                            Animation anim = creature.GetComponent<Animation>();
                            anim["Take 001"].speed = 2f;
                            anim.Play();
                            creature.GetComponent<Taupe>().setPoints(10);
                            creature.GetComponent<Taupe>().setRotate(level);
                        }
                    }else{
                        creature = Instantiate(chatPrefab, trous[random].position, Quaternion.Euler(0, 180, 0));
                        creature.transform.parent = trous[random];
                        Animation anim = creature.GetComponent<Animation>();
                        anim["Take 001"].speed = 2f;
                        anim.Play();
                        creature.GetComponent<Chat>().setPoints(10);
                        creature.GetComponent<Chat>().setRotate(level);
                    }
                }else{
                    if (whichCreature < (101 - (level / 2)))
                    {
                        hatRand = Random.Range(1, 100);

                        if (hatRand > 75)
                        {
                            creature = Instantiate(taupeChapeauPrefab, trous[random].position, Quaternion.Euler(0, 180, 0));
                            creature.transform.parent = trous[random];
                            Animation anim = creature.GetComponent<Animation>();
                            anim["Take 001"].speed = 2f;
                            anim.Play();
                            creature.GetComponent<Taupe>().setRotate(level);
                            creature.GetComponent<Taupe>().setCasque(true);
                            creature.GetComponent<Taupe>().setPoints(15);
                        }else{
                            creature = Instantiate(taupePrefab, trous[random].position, Quaternion.Euler(0, 180, 0));
                            creature.transform.parent = trous[random];
                            Animation anim = creature.GetComponent<Animation>();
                            anim["Take 001"].speed = 2f;
                            anim.Play();
                            creature.GetComponent<Taupe>().setPoints(10);
                            creature.GetComponent<Taupe>().setRotate(level);
                        }
                    }else{
                        creature = Instantiate(chatPrefab, trous[random].position, Quaternion.Euler(0, 180, 0));
                        creature.transform.parent = trous[random];
                        Animation anim = creature.GetComponent<Animation>();
                        anim["Take 001"].speed = 2f;
                        anim.Play();
                        creature.GetComponent<Chat>().setPoints(10);
                        creature.GetComponent<Chat>().setRotate(level);
                    }
                }
            }  
        }
        if(creature != null)
        {
            Animation animTemp = creature.GetComponent<Animation>();
            if (creature.GetComponent<Taupe>() != null)
            {
                if (!animTemp.isPlaying && kill && !creature.GetComponent<Taupe>().getKill())
                {
                    Destroy(creature);
                }
            }
            else if (creature.GetComponent<Chat>() != null){
                if (!animTemp.isPlaying && kill && !creature.GetComponent<Chat>().getKill())
                {
                    Destroy(creature);
                }
            }
            
        }
        //Debug.Log(Time.time);
    }
}
