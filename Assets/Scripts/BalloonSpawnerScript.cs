using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class BalloonSpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Balloon=new GameObject[5];
    private float delay=1;
    private float limit=0;
    
    private List<BalloonScript> balloons = new List<BalloonScript>();
    private List<string> balloonTexts = new List<string>();
    private int numberOfBalloon = 0;
    private GameObject balloonJustInstantiated;
    private List<string> randomWords = new List<string>() {
    "accept", "action", "advice", "answer", "beauty", "belief", "breeze",
    "calm", "chance", "change", "comfort", "courage", "create", "crisis",
    "dance", "danger", "desire", "dream", "emotion", "energy", "escape",
    "faith", "freedom", "friend", "future", "glory", "growth", "harmony",
    "health", "hope", "idea", "imagine", "inspire", "joy", "journey",
    "justice", "kind", "liberty", "life", "listen", "magic",
    "memory", "message", "miracle", "moment", "mystery", "nature", "optimist",
    "passion", "peace", "power", "promise", "purpose", "quiet", "reflection",
    "release", "remember", "renew", "return", "serenity", "silence",
    "simple", "smile", "solace", "spirit", "strength", "sunlight", "thought",
    "thrill", "together", "transform", "trust", "truth", "unity", "value",
    "victory", "vision", "voice", "wander", "wisdom", "wonder", "zenith",
    "dance", "glory", "hope", "joy", "magic", "peace", "spirit",
    "dream", "energy", "freedom", "glory", "harmony", "kind", "memory",
    "miracle", "purpose", "silence", "smile", "strength", "thought", "wisdom",
    "courage", "victory", "belief", "desire", "friend", "nature", "purpose",
    "freedom", "harmony", "liberty", "moment", "promise", "reflection", "release",
    "renew", "resilient", "return", "serenity", "silence", "spirit", "sunlight",
    "thrill", "together", "transform", "unity", "wisdom", "wonder", "advice",
    "answer", "beauty", "breeze", "calm", "chance", "change", "comfort",
    "create", "crisis", "danger", "emotion", "escape", "faith", "future",
    "growth", "health", "idea", "imagine", "inspire", "journey", "justice", "life", "listen", "message", "nature", "optimist", "passion",
    "power", "quiet", "reflect", "remember", "spirit", "sunlight", "transform",
    "trust", "truth", "value", "voice", "wonder", "accept", "breath",
    "choice", "classic", "contact", "defend", "effort", "elegant",
    "example", "expand", "flow", "follow", "golden", "honest",
    "humble", "impact", "income", "journey", "legend", "loyal",
    "moment", "normal", "oppose", "perfect", "protect", "radiant",
    "respect", "result", "secure", "simple", "spirit", "temple",
    "thank", "vivid", "wisdom", "explore", "discover", "create", "imagine", "reflect", "connect", "inspire", "transform", "embrace", "challenge", "achieve",
        "empower", "illuminate", "insight", "enlighten", "elevate", "evolve", "nurture", "expand", "manifest", "realize", "awaken",
        "unleash", "express", "embody", "harmonize", "thrive", "synthesize", "facilitate", "foster", "forgive", "heal", "revitalize",
        "renew", "transcend", "transmute", "actualize", "liberate", "attune", "align", "unify", "revive", "remember", "empower",
        "authentic", "catalyze", "co-create", "flow", "engage", "thrive", "release", "embrace", "unfold", "emerge", "awaken",
        "explore", "reveal", "manifest", "surrender", "embody", "blossom", "transcend", "transmute", "flourish", "transform",
        "empower", "actualize", "realize", "evolve", "expand", "nurture", "create", "inspire", "express", "thrive", "heal", "connect",
        "harmonize", "illuminate", "enlighten", "liberate", "awaken", "embrace", "align", "facilitate", "synthesize", "reflect",
        "remember", "forgive", "evolve", "transcend", "unleash", "liberate", "inspire", "connect", "explore", "embody", "transform",
        "empower", "manifest", "enlighten", "awaken", "realize", "thrive", "nurture", "evolve", "release", "heal", "unfold",
        "express", "reflect", "synthesize", "harmonize", "facilitate", "revitalize", "blossom", "transcend", "attune", "create",
        "engage", "revive", "remember", "connect", "evolve", "release", "heal", "transform", "illuminate", "enlighten", "synthesize",
        "unfold", "empower", "explore", "reflect", "harmonize", "nurture", "awaken", "realize", "express", "thrive", "inspire",
        "liberate", "transform", "manifest", "embrace", "connect", "evolve", "release", "heal", "illuminate", "enlighten", "express",
        "unfold", "harmonize", "realize", "thrive", "inspire", "liberate", "manifest", "awaken", "transform", "connect", "release",
        "evolve", "heal", "illuminate", "enlighten", "unfold", "express", "harmonize", "thrive", "realize", "inspire", "liberate",
        "manifest", "awaken", "transform" ,  "empower", "illuminate", "inspire", "enlighten", "transform", "awaken", "liberate", "connect", "harmonize", "realize",
        "manifest", "unfold", "release", "embrace", "evolve", "nurture", "reflect", "synthesize", "thrive", "explore",
        "engage", "revitalize", "forge", "transcend", "unleash", "forge", "create", "spark", "facilitate", "foster",
        "expand", "align", "attune", "cherish", "embody", "revive", "remember", "forgive", "heal", "blossom", "transmute",
        "actualize", "co-create", "balance", "transcend", "unify", "flourish", "discover", "imagine", "challenge", "achieve",
        "express", "flow", "absorb", "accept", "adapt", "advocate", "appreciate", "aspire", "assimilate", "authentic", "celebrate",
        "clarify", "coexist", "communicate", "compromise", "conceive", "condense", "confront", "connect", "conquer", "contemplate",
        "cope", "create", "cultivate", "curate", "debate", "decipher", "dedicate", "defend", "delegate", "deliberate", "demonstrate",
        "depict", "design", "develop", "devise", "discern", "discuss", "display", "dispel", "dissent", "distinguish", "dream",
        "educate", "elaborate", "embrace", "encounter", "encourage", "endeavor", "endorse", "enrich", "entertain", "envision",
        "establish", "evaluate", "evolve", "examine", "exemplify", "exhibit", "experience", "experiment", "explore", "express",
        "facilitate", "fathom", "flourish", "forge", "formulate", "found", "foster", "fulfill", "further", "fuse", "gather",
        "generate", "grow", "guide", "harmonize", "highlight", "identify", "illustrate", "imagine", "implement", "improvise",
        "incorporate", "indulge", "influence", "initiate", "innovate", "inspect", "inspire", "instruct", "integrate", "interpret",
        "introduce", "investigate", "invite", "invoke", "join", "journey", "justify", "learn", "lecture", "listen", "live",
        "manifest", "marshal", "mediate", "merge", "mobilize", "modify", "motivate", "multiply", "navigate", "negotiate", "nurture",
        "observe", "obtain", "offer", "open", "operate", "optimize", "organize", "overcome", "participate", "penetrate", "perceive",
        "perform", "persuade", "pioneer", "plan", "ponder", "present", "promote", "propose", "provoke", "publish", "pursue",
        "question", "quicken", "raise", "realize", "reason", "reclaim", "reconcile", "recruit", "refine", "reflect", "reframe",
        "refresh", "regenerate", "relate", "release", "renew", "repair", "replace", "represent", "replicate", "reshape", "resonate",
        "resolve", "respect", "respond", "restore", "revise", "rigor", "ruminate", "savor", "scan", "scrutinize", "seek", "select",
        "sense", "serve", "shape", "sharpen", "shift", "shine", "simulate", "sketch", "spark", "speculate", "spread", "stand",
        "steward", "stimulate", "strategize", "strengthen", "stretch", "study", "support", "sustain", "teach", "teleport",
        "testify", "trace", "track", "transcend", "transcribe", "translate", "transmit", "travel", "treasure", "uncover", "understand",
        "unify", "unlock", "uplift", "validate", "value", "venture", "visualize", "voyage", "watch", "welcome", "wonder", "work", "write"


};
    private ScoreManager scoreManager;
    private int difficulty;
    private float upperLim=3;
    private int counter = 0;
    private float previousPosition;

    

    // Start is called before the first frame update
    void Start()
    {
        scoreManager=GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        scoreManager.setLives();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (delay > limit )
        {
            if(counter==10)
            {
                counter %= 10;
                if(upperLim<=3)
                {
                    upperLim -= 0.1f;
                }
                
            }
            
            delay = 0;
            limit = Random.Range(2f, upperLim);

            float newPosition;
            do
            {
                newPosition = Random.Range(-7.22f, 7.22f);
            } while (Mathf.Abs(previousPosition - newPosition) < 2);

            previousPosition = newPosition;
            createBalloon(previousPosition, transform.position.y);
 
        }    
        else
            delay += Time.deltaTime;
        
        

    }
    private void createBalloon(float positionx, float positiony)
    {
        int num = Random.Range(0, 5);
        
        balloonJustInstantiated = Instantiate(Balloon[num], new Vector3(positionx, positiony, transform.position.z), transform.rotation);

        if (balloonJustInstantiated != null)
        {
            BalloonScript balloon = balloonJustInstantiated.GetComponent<BalloonScript>();
            balloon.speedChange();
            if (balloon != null)
            {
                string word = " ";
                bool again = false;
                do
                {
                    word = returnRandomWord();
                    for(int i=0;i<balloonTexts.Count;i++)
                        if (word == balloonTexts[i])
                        {
                            again = true;
                            break;
                        }
                } while (word.Length > 8 || again);


                if (balloon.changeText(word))
                {
                    Debug.Log("--------" + word);
                }
                balloons.Add(balloon);
                balloonTexts.Add(word);
                numberOfBalloon++;
            }
            else
            {
                Debug.LogWarning("BalloonScript component not found on the instantiated balloon!");
            }
        }
        else
        {
            Debug.LogWarning("Failed to instantiate balloon!");
        }
    }
    public string returnRandomWord()
    {
        return randomWords[Random.Range(0, randomWords.Count)];
    }
    public void getAndCompareInput(string text)
    {
#if UNITY_EDITOR
        Debug.Log("Input Submitted: " + text);
#endif
        for(int i = 0;i<balloonTexts.Count;i++) 
        {
            if (balloonTexts[i] == text)
            {
                balloons[i].popped = true;
                balloons[i].popBalloon();
                removeBalloonByIndex(i);
                
            }
        }
        
    }
    public void removeBalloonByIndex(int number)
    {
        balloons.RemoveAt(number);
        balloonTexts.RemoveAt(number);
        scoreManager.addscore();

    }
    public void removeBalloon(BalloonScript balloon)
    {
        string text = balloon.textOnBalloon();
        balloons.Remove(balloon);
        for (int i = 0; i < balloonTexts.Count; i++)
        {
            if (balloonTexts[i] == text)
            {
                balloonTexts.RemoveAt(i);
            }
        }
    }
    public bool allBalloonsDestroyed()
    {
        return balloons.Count == 0;
    }
    public void setDifficulty(int value)
    {
        difficulty = value;
#if UNITY_EDITOR
        Debug.Log("difficulty Value" + difficulty);
#endif
    }
    public int getDifficulty()
    {
        return difficulty;
    }
}
