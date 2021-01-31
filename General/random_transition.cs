using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class random_transition : MonoBehaviour
{
    public GameObject blure;
    void Start()
    {
        blure = GameObject.Find("randomModeBlur");
    }

    public void Transition(int number)
    {
        if(!RandomTransitionContainer.isRandomTypeAvailable){
            StartCoroutine(waiter());
            return;
        }
        PlayerPrefs.SetInt("LevelRecord", 0);
        RandomTransitionContainer.LivesCount = 3;
    	RandomTransitionContainer.randomTransition = true;
    	if(!RandomTransitionContainer.randomTransition)
        {
        	SceneManager.LoadScene(number);
    	}
        else
        {
            if(RandomTransitionContainer.sceneCount != RandomTransitionContainer.available_scenes.Count)
            {
                print("fill av scenes");
                for(int i = 0; i < RandomTransitionContainer.sceneCount; i++)
                {
                    print(20 + i);
                    if(!RandomTransitionContainer.available_scenes.Contains(20 + i))
                        RandomTransitionContainer.available_scenes.Add(20 + i);
                }
            }

            RandomTransitionContainer.LevelRecord = 0;
            System.Random r = new System.Random();
            int r_scene = RandomTransitionContainer.available_scenes.OrderBy(x => r.Next()).Take(1).First();//random_except_list(RandomTransitionContainer.sceneCount, RandomTransitionContainer.passed_scenes);
            RandomTransitionContainer.available_scenes.Remove(r_scene);
            RandomTransitionContainer.passed_scenes.Add(r_scene);
            SceneManager.LoadScene(r_scene);
        }
    }

    public int random_except_list(int n, List<int> x) 
    {
        var r = new System.Random();
        int result = r.Next(2,n - x.Count);

        for (int i = 0; i < x.Count; i++) 
        {
            if (result < x[i])
                return result;
            result++;
        }
        return result;
    }

    IEnumerator waiter()
    {
        blure.transform.SetSiblingIndex(1000);
        yield return new WaitForSeconds(1);
        blure.transform.SetSiblingIndex(0);
    }
}
