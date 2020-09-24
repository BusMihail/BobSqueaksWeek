using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LaptopScript : MonoBehaviour, IMinigame
{
    string[] adjectiveList = { "Huge", "Big", "Scary", "Deadly", "Dangerous", "Humongous", "Threatening", "Brave", "Tasty", "Courageous", "Zany", "Grotesque", "Fast", "Perplexing", "Furious", "Angry", "Proud", "Risky"};
    string[] nounList = { "Lions", "Hippopotamuses", "Ants", "Cats", "Panthers", "Hyenas", "Trees", "Oasis", "Monkeys", "Rhinoceros", "Giraffe", "Gamer", "Elephant", "Centipede", "Virus", "Kangaroos", "Vultures" };
    string[] SocialMedia = { "JungleBook :", "SnapClaw :", "InstaRoar :", "FelineCupid :", "MeowChat :", "TailHub :", "ApeTube :" };
    public int maxNo = 100;
    public int difficulty = 3;
    int solveIndex = 0;
    int wrongCount = 0;
    List<string> passwords = new List<string>();
    List<string> currentSocialMedia = new List<string>();

    public Text crtPass;
    public Text crtSocialMedia;
    public InputField inputField;
    public Canvas screen;
    public Text wrongPass;


    public MinigameType minigame { get; set; }
    public Action<IMinigame, bool> OnMinigameFinished { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        inputField.ActivateInputField();
        //inputField.Select();

        System.Random rnd = new System.Random();
        for(int i=0; i<difficulty; i++)
        {
            //Add to list of social media pages for the current instance of minigame
            int x = rnd.Next(SocialMedia.Length);
            currentSocialMedia.Add(SocialMedia[x]);

            //Create password
            string crtPass = "";
            crtPass += adjectiveList[rnd.Next(adjectiveList.Length)]+nounList[rnd.Next(nounList.Length)]+rnd.Next(10,maxNo).ToString();
            passwords.Add(crtPass);
        }

        crtPass.text = passwords.ElementAt(0);
        crtSocialMedia.text = currentSocialMedia.ElementAt(0);
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void PasswordEntered()
    {
        if(inputField.text.Equals(passwords.ElementAt(solveIndex)))
        {
            solveIndex++;
            if(solveIndex == difficulty)
            {
                //MINIGAME
                //IS
                //FINISHED
                Debug.Log("Stop, gj");
                OnMinigameFinished(this, true);
            }
            else
            {
                crtPass.text = passwords.ElementAt(solveIndex);
                crtSocialMedia.text = currentSocialMedia.ElementAt(solveIndex);
                inputField.text = "";
                inputField.ActivateInputField();
            }
        }
        else
        {
            inputField.text = "";
            inputField.ActivateInputField();

            RectTransform rt = screen.GetComponent<RectTransform>();
            Vector3[] v = new Vector3[4];
            rt.GetWorldCorners(v);
            Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(v[0].x, v[3].x), UnityEngine.Random.Range(v[0].y, v[2].y), 0);
            Quaternion q = Quaternion.identity;
            q.z = UnityEngine.Random.Range(-0.25f,0.25f);
            GameObject spawnObj = Instantiate(wrongPass.gameObject, spawnPosition, q, rt);
            wrongCount++;
            if (wrongCount > 2)
            {
                //GAME
                //IS
                //LOST
            }
        }
    }

    public void DestroyMinigame()
    {
        Destroy(gameObject);
    }
}
