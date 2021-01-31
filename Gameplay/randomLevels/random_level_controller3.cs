using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class random_level_controller3 : MonoBehaviour
{
    public Text quest_cond;
    public string conditionPart1;
    public string conditionPart2;
    public string conditionPart3;

    public string wordForm1;
    public string wordForm2;
    public string wordForm3;
    

    public GameObject nkblock;
    public GameObject k2_block;
    public GameObject n1_block;
    public GameObject n2_block;
    public GameObject minus_n_block;
    public GameObject mul_n_block;
    public GameObject F;
    public GameObject k_fact;
    public GameObject n_fact;
    private List<GameObject> objects = new List<GameObject>();
    private int N;
    private int K; 
    void Start()
    {
        objects.Add(nkblock);
        objects.Add(k2_block);
        objects.Add(n1_block);
        objects.Add(minus_n_block);
        objects.Add(mul_n_block);
        objects.Add(k_fact);
        objects.Add(n_fact);
        objects.Add(F);
        
        List<Vector3> tempListOfObjects = new List<Vector3>();
        for(int i = 0; i < objects.Count; i++)
        {
            tempListOfObjects.Add(objects[i].transform.position);
        }

        Shuffle(objects);
        for(int i = 0; i < objects.Count; i++)
        {
           objects[i].transform.position = tempListOfObjects[i];
           objects[i].GetComponent<drop_item>().startPosition = tempListOfObjects[i];
        }

    	N = UnityEngine.Random.Range(5,20);
        K = UnityEngine.Random.Range(1,N);
        int M = 0, Mi = 0;
        var factorsOfN = Factor(N);
        var factorsOfK = Factor(K);
        int n = 0;
        int k = 0;
        int itr = 0;
        if(UnityEngine.Random.Range(0,2) == 1)
        {
            itr = 0;
            while(n * M != N && k + Mi != K)// && (K == 0 || Mi == 0 || k == 0 || n == 0 || N == 0))
            {

                //M = UnityEngine.Random.Range(2, 5);
                System.Random r = new System.Random();
                //if(factorsOfN.Count > 0)
                M = factorsOfN.OrderBy(x => r.Next()).Take(1).First();
                Mi = UnityEngine.Random.Range(2, 10);
                if(itr > 111){
                    print("bad 1");
                    break;
                }
                //if(M != 0)
                n = N/M;
                k = K + Mi;
                itr++;
            }
        }
        else
        {
            itr = 0;
            while(n + Mi != N && k * M != K && (K == 0 || Mi == 0 || k == 0 || n == 0 || N == 0))
            {

                System.Random r = new System.Random();
                //if(factorsOfK.Count > 0)
                M = factorsOfK.OrderBy(x => r.Next()).Take(1).First();
        
                Mi = UnityEngine.Random.Range(2, 10);
                if(itr > 111){
                    print("bad 2");
                    break;
                }
                n = N + Mi;
                //if(M != 0)
	            k = K / M;
                itr++;
            }
        }
        
        n1_block.transform.GetChild(0).GetComponent<Text>().text = n.ToString();
    	
        k2_block.transform.GetChild(0).GetComponent<Text>().text = k.ToString();
        mul_n_block.transform.GetChild(1).GetComponent<Text>().text = (M).ToString();
        minus_n_block.transform.GetChild(1).GetComponent<Text>().text = (Mi).ToString();
        
        quest_cond.text = conditionPart1 + N.ToString() + PluralizeStudents(N) + conditionPart2 +  K.ToString() +  PluralizeStudents(K, false) + conditionPart3;
        


        GameObject.Find("answer_spot").GetComponent<answer_drop>().optional_k = K;
        GameObject.Find("answer_spot").GetComponent<answer_drop>().optional_n = N;

    }

    public List<int> Factor(int number) 
    {
        var factors = new List<int>();
        int max = (int)Math.Sqrt(number);

        for (int factor = 1; factor <= max; ++factor)
        {  
            if (number % factor == 0) 
            {
                if(factor < 10 && factor > 1)
                    factors.Add(factor);
                if (factor != number/factor && number/factor < 10 && number/factor > 1)
                    factors.Add(number/factor);
            }
        }
        return factors;
    }

    public static void Shuffle<T>(IList<T> list)  
    {  
        var rng = new System.Random(); 
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            T value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }

	public string PluralizeStudents(int count, bool secondIn = true)
	{	
		var last = count % 10;
		var penultimate = (count / 10) % 10;
		if (penultimate != 1 && last == 1 && secondIn) return wordForm1;
		if (penultimate != 1 && last == 1 && !secondIn) return wordForm1;
		if (penultimate != 1 && (last == 2 || last == 3 || last == 4)) return wordForm2;
		return wordForm3;
	}    
}
