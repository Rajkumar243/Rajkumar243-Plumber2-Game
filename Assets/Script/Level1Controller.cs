using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level1Controller : MonoBehaviour
{

    int ButtonClickedCount = 0;
    private Button Click1;
    private Button Click2;

    private Vector3 Position1, Position2;

    public string Click1Name;
    public string Click2Name;

 
    public Sprite Type_0;
    public Sprite Waterflow;
    public GameObject OutWaterflow;
    
    
    public string[] CorrectPositions;

    public float timeStart;
    public int Minutes;
    public TMP_Text TimertextBox;
    public TMP_Text MinutestextBox;
    public bool timerActive = false;

    public GameObject DisplayScreen;
    public TMP_Text Score;
    public TMP_Text DisplayScore;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void FixedUpdate()
    {
        if(ButtonClickedCount == 2)
        {
            Click1.transform.position = Vector3.Lerp(Click1.transform.position, Position2, 10f * Time.deltaTime);

            Click2.transform.position = Vector3.Lerp(Click2.transform.position, Position1, 10f * Time.deltaTime);

            Invoke("ResetScale", 0.5f);
        }
    }
    public void ResetScale()
    {
   
        Click1.transform.name = Click2Name;
        Click2.transform.name = Click1Name;
        Click1.transform.localScale = new Vector2(1f, 1f);
        Click2.transform.localScale = new Vector2(1f, 1f);
        ButtonClickedCount = 0;
        CheckResult();
        GeneratorWaterFlow();
    }
    public void ButtonFunction(Button Btn)
    {
        if(Btn.transform.name!= "Clicked" && ButtonClickedCount == 0)
        {

            Click1Name = Btn.transform.name;
            Click1 = Btn;
            Position1 = Btn.transform.position;      
            Btn.transform.name = "Clicked";
            Btn.transform.localScale = new Vector2(1.25f, 1.25f);
            ButtonClickedCount++;


            if(Btn.GetComponent<Image>().sprite.name == "WaterFlow")
            {
                Btn.GetComponent<Image>().sprite = Type_0;
            }
        }
        if (Btn.transform.name != "Clicked" && ButtonClickedCount == 1)
        {
            Click2Name = Btn.transform.name;
            Click2 = Btn;
            Position2 = Btn.transform.position;
          
            Btn.transform.name = "Clicked";
            Btn.transform.localScale = new Vector2(1.25f, 1.25f);
            ButtonClickedCount++;

            if (Btn.GetComponent<Image>().sprite.name == "WaterFlow")
            {
                Btn.GetComponent<Image>().sprite = Type_0;
            }
        }
    }

    private void CheckResult()
    {
        for(int i = 0; i<=CorrectPositions.Length-1; i++)
        {
            if (GameObject.Find(CorrectPositions[i]).GetComponent<Image>().sprite.name == "Type-1")
            {
                Debug.Log(CorrectPositions[i] + "Here");

            }
            else
            {
                break;
            }
        }
    }

    private void GeneratorWaterFlow()
    {
        if (GameObject.Find("1,0").GetComponent<Image>().sprite.name == "Type-1" && GameObject.Find("1,1").GetComponent<Image>().sprite.name == "Type-0")
        {
            GameObject.Find("1,1").GetComponent<Image>().sprite = Waterflow;
        }
        if (GameObject.Find("1,0").GetComponent<Image>().sprite.name == "Type-1" && GameObject.Find("1,1").GetComponent<Image>().sprite.name == "Type-1" && GameObject.Find("1,2").GetComponent<Image>().sprite.name == "Type-0")
        {
            GameObject.Find("1,2").GetComponent<Image>().sprite = Waterflow;
        }
        if (GameObject.Find("1,0").GetComponent<Image>().sprite.name == "Type-1" && GameObject.Find("1,1").GetComponent<Image>().sprite.name == "Type-1" && GameObject.Find("1,2").GetComponent<Image>().sprite.name == "Type-1")
        {
            Debug.Log("Completed");
           
            OutWaterflow.SetActive(true);
            timerActive = false;
            Invoke("GameOver", 1f);
        }
    }

   public void GameOver()
   {
        PlayerPrefs.SetInt("Score", +1);
        Score.text = PlayerPrefs.GetInt("Score").ToString();
        DisplayScore.text = PlayerPrefs.GetInt("Score").ToString();
        DisplayScreen.SetActive(true);
   }


    // Update is called once per frame
    void Update()
    {

        if (timerActive)
        {
            timeStart += Time.deltaTime;
            TimertextBox.text = timeStart.ToString("F0");

            if (timeStart > 59)
            {
                Minutes++;
                timeStart = 0;
            }
            MinutestextBox.text = Minutes.ToString();
        }
    }
}
