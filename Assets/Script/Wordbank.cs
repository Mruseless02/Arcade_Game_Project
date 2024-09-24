using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Wordbank : MonoBehaviour
{
    private List<string> originalWord = new List<string>()
    {
        "sword", "magic", "bow"
    };
    private List<string> workingWord = new List<string>();

    private void Awake()
    {
        workingWord.AddRange(originalWord);
        Shuffle(workingWord);
        ConvertTolowerCase(workingWord);
    }

    private void Shuffle(List<string> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            int random = Random.Range(i, list.Count);
            string temp = list[i];
            list[i] = list[random];
            list[random] = temp;
        }
    }

    private void ConvertTolowerCase(List<string> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            list[i] = list[i].ToLower();
        }
    }

    public string GetWord()
    {
        string newWord = string.Empty;
        if(workingWord.Count != 0)
        {
            newWord = workingWord.Last();
            workingWord.Remove(newWord);
        }
        return newWord;
    }

}
