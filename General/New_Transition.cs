using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class New_Transition : MonoBehaviour
{
    public void Transition(int number)
    {
    	if(!RandomTransitionContainer.randomTransition){
        	SceneManager.LoadScene(number);
    	}
        else{
            call_random_transition();
        }
    }

    public void AnswerTransition(int number)
    {
        if(!RandomTransitionContainer.randomTransition){
            if(!LevelsContainer.passed_levels.Contains("saved_level " + number.ToString())){
                LevelsContainer.passed_levels.Add("saved_level " + number.ToString());
                SaveLevels();
            }
            SceneManager.LoadScene(number);
        }
        else{
            call_random_transition();
        }
    }

    public void FinalLearningTransition(int number)
    {
        if(!RandomTransitionContainer.randomTransition){
            if(!LevelsContainer.passed_levels.Contains("saved_level " + number.ToString())){
                LevelsContainer.passed_levels.Add("saved_level " + number.ToString());
                SaveLevels();
            }
            PlayerPrefs.SetInt("LevelRecord", 0);
            RandomTransitionContainer.randomTransition = true;
            RandomTransitionContainer.LivesCount = 3;
            if(RandomTransitionContainer.sceneCount != RandomTransitionContainer.available_scenes.Count)
            {
                for(int i = 1; i < RandomTransitionContainer.sceneCount; i++)
                {
                    if(!RandomTransitionContainer.available_scenes.Contains(20 + i))
                        RandomTransitionContainer.available_scenes.Add(20 + i);
                }
            }
            SceneManager.LoadScene(number);
        }
        else{
            call_random_transition();
        }
    }

    void SaveLevels()
    {
        for (int i = 0; i < LevelsContainer.passed_levels.Count; i++)
        {
            PlayerPrefs.SetString(LevelsContainer.passed_levels[i], LevelsContainer.passed_levels[i]);
        }
    }

    public void changingCondition()
    {
    	if(RandomTransitionContainer.randomTransition){
    		RandomTransitionContainer.randomTransition = false;
    		Transition(0);
    	}
    	else{
    		Transition(1);	
    	}
    }

    public void changeLevelScene(int number)
    {
        if(LevelsContainer.passed_levels != null && LevelsContainer.passed_levels.Contains("saved_level " + number.ToString()))
            SceneManager.LoadScene(number);
    }

    public void call_random_transition()
    {
        if(RandomTransitionContainer.available_scenes.Count() == 0){ //(RandomTransitionContainer.sceneCount-1)){//add =
            RandomTransitionContainer.randomTransition = false;
            RandomTransitionContainer.passed_scenes = new List<int>();
            RandomTransitionContainer.LevelRecord++;
            SceneManager.LoadScene(0);
            return;
        }

        System.Random r = new System.Random();
        int r_scene = RandomTransitionContainer.available_scenes.OrderBy(x => r.Next()).Take(1).First();//random_except_list(RandomTransitionContainer.sceneCount, RandomTransitionContainer.passed_scenes);
        RandomTransitionContainer.available_scenes.Remove(r_scene);
        RandomTransitionContainer.passed_scenes.Add(r_scene);
        RandomTransitionContainer.passed_scenes.Sort();
        RandomTransitionContainer.LevelRecord++;
        PlayerPrefs.SetInt("LevelRecord", RandomTransitionContainer.LevelRecord);
        SceneManager.LoadScene(r_scene);
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
    void OnApplicationQuit()
    {
        SaveLevels();
    }
}
