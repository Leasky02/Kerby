using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsEntry
{
    public string title;
    public string[] names;

    public static CreditsEntry Create(string _title, string[] _names)
    {
        return new CreditsEntry {
            title = _title,
            names = _names
        };
    }
}

public class CreditScrollScript : MonoBehaviour
{
    [SerializeField]
    private GameObject titleTextTemplate;

    [SerializeField]
    private GameObject nameTextTemplate;

    [SerializeField]
    private float force;

    private List<CreditsEntry> credits;

    void Awake()
    {
        credits = new List<CreditsEntry>();

        credits.Add(CreditsEntry.Create(
            "Gameplay Designers",
            new string[] {
                "Alasdair Leask",
                "Leah Thompson"
            }
        ));
        credits.Add(CreditsEntry.Create(
            "Lead Programmer",
            new string[] {
                "Alasdair Leask"
            }
        ));
        credits.Add(CreditsEntry.Create(
            "Lead Artist",
            new string[] {
                "Leah Thompson"
            }
        ));
        credits.Add(CreditsEntry.Create(
            "Additional Programmer",
            new string[] {
                "Calum Leask"
            }
        ));
        credits.Add(CreditsEntry.Create(
            "Additional Artist",
            new string[] {
                "Jen Leask"
            }
        ));
        credits.Add(CreditsEntry.Create(
            "Music",
            new string[] {
                        "Alasdair Leask"
            }
        ));
        credits.Add(CreditsEntry.Create(
            "Loyal Supervisor",
            new string[] {
                "Mary (the doggo)"
            }
        ));
        credits.Add(CreditsEntry.Create(
            "Testers",
            new string[] {
                "James Thompson",
                "Arran Leask",
                "Emily Leask",
                "Calum Leask (the annoyingly good one)",
                "Jen Leask",
                "Tim Thompson",
                "Mel Thompson",
                "Josh Thompson"
            }
        ));
        credits.Add(CreditsEntry.Create(
            "Spell Checker",
            new string[] {
                "Leah Thompson"
            }
        ));
        credits.Add(CreditsEntry.Create(
            "Software",
            new string[] {
                "Unity 2019.4.31",
                "Gimp 2.10.12",
                "Autodesk Sketchbook",
                "GarageBand 10.4.1 iOS",
            }
        ));
        credits.Add(CreditsEntry.Create(
            "Sound Effects",
            new string[] {
                "https://www.zapsplat.com/",
                "",
                "Feesound.org",
                "",
                "S: Coins / Selling sound by williamornelas | License: Attribution",
                "S: rain 2.wav by FenrirFangs | License: Creative Commons 0",
                "S: Close lightning strike 2018 07 07 by csengeri | License: Creative Commons 0",
                "S: Struck By Lightning.wav by Cheeseheadburger | License: Attribution",
                "S: Coin Flipping, A.wav by InspectorJ | License: Attribution",
                "S: stone_and_cup_hit.aiff by k06a | License: Creative Commons 0",
                "S: Splats.wav by jjxmf | License: Creative Commons 0",
                "S: Game Fail Sounds by steel2008 | License: Creative Commons 0",
                "S: 320655__rhodesmas__level-up-01.mp3 by shinephoenixstormcrow | License: Attribution",
                "S: Fireworks, Standard and Whistle, A.wav by InspectorJ | License: Attribution",
                "S: happy clapps.wav by timtube | License: Attribution Noncommercial",
                "S: basketball by vhschool2019 | License: Creative Commons 0"
            }
        ));

        foreach (CreditsEntry credit in credits)
        {
            // Create space
            GameObject spaceObject = Instantiate(nameTextTemplate) as GameObject;
            spaceObject.GetComponent<Text>().text = "";
            spaceObject.transform.SetParent(nameTextTemplate.transform.parent, false);
            spaceObject.SetActive(true);

            // Create more space
            GameObject moreSpaceObject = Instantiate(nameTextTemplate) as GameObject;
            moreSpaceObject.GetComponent<Text>().text = "";
            moreSpaceObject.transform.SetParent(nameTextTemplate.transform.parent, false);
            moreSpaceObject.SetActive(true);

            GameObject titleObject = Instantiate(titleTextTemplate) as GameObject;
            titleObject.GetComponent<Text>().text = credit.title;
            titleObject.transform.SetParent(titleTextTemplate.transform.parent, false);
            titleObject.SetActive(true);
            
            foreach (string name in credit.names)
            {
                GameObject nameObject = Instantiate(nameTextTemplate) as GameObject;
                nameObject.GetComponent<Text>().text = name;
                nameObject.transform.SetParent(nameTextTemplate.transform.parent, false);
                nameObject.SetActive(true);
            }
        }
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * force * Time.deltaTime);
    }
}
