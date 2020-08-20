using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wikitude;
using System.Linq;
using UnityEngine.UI;

[System.Serializable]
public class WordList
{
    public string word;
    public Texture prompt;
}

public class SpellController : MonoBehaviour {

    public GameObject trackable;
    public GameObject tick;
    public GameObject cross;
    public GameObject claire;

    public List<WordList> words;
    public Texture gameOver;
    public RawImage screenPrompt;
    public Text score;

    string wordToSearch;

    private bool gotReward = false;
    private int currentWord = -1;

    public void Start()
    {
        PickRandomWord();
    }

    public void PickRandomWord()
    {
        if (currentWord > -1)
            words.RemoveAt(currentWord);

        currentWord = Random.Range(0, words.Count);
        wordToSearch = words[currentWord].word;
        screenPrompt.texture = words[currentWord].prompt;
    }

    public void OnImageRecognized(ImageTarget target)
    {
        Invoke("CheckSpelling", 0.1f);
    }

    public void OnImageLost(ImageTarget target)
    {
        if(gotReward)
        {
            if(words.Count == 1)
            {
                screenPrompt.texture = gameOver;
                trackable.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                PickRandomWord();
                gotReward = false;
            }
        }
    }

    private void CheckSpelling()
    {
        Transform[] allTransforms = trackable.GetComponentsInChildren<Transform>();
        List<Transform> markers = new List<Transform>();

        foreach (Transform t in allTransforms)
            if (t.parent.gameObject == trackable)
                markers.Add(t);

        if (markers.Count != wordToSearch.Length)
        {
            gotReward = false;
            return;
        }

        markers = markers.OrderByDescending(marker => marker.position.x).ToList();

        int matchCount = 0;

        for(int i = 0; i < markers.Count; i++)
        {
            if (markers[i].gameObject.name.StartsWith(wordToSearch[i] + "_"))
            {
                matchCount++;
                GameObject tickObj = Instantiate(tick, markers[i].position, markers[i].rotation);
                tickObj.transform.parent = markers[i];
            }
            else
            {
                GameObject crossObj = Instantiate(cross, markers[i].position, markers[i].rotation);
                crossObj.transform.parent = markers[i];
            }
        }

        if (matchCount == wordToSearch.Length && !gotReward)
        {
            Debug.Log("wordToSearch : " + wordToSearch + " and markers : + " + markers[0].gameObject.name + markers[1].gameObject.name + markers[2].gameObject.name);

            GameObject c = Instantiate(claire, markers[0].position, markers[0].rotation);
            c.transform.parent = markers[0];
            gotReward = true;

            score.text = (int.Parse(score.text) + 1) + "";
        }
    }
}
