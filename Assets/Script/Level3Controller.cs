using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level3Controller : MonoBehaviour
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


    public float timeStart;
    public int Minutes;
    public TMP_Text TimertextBox;
    public TMP_Text MinutestextBox;
    public bool timerActive = false;


    public bool IsResultCheck = false;
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
       
        GeneratorWaterFlow();

        IsResultCheck = true;
    }
    public void ButtonFunction(Button Btn)
    {
        if(Btn.transform.name!= "Clicked" && ButtonClickedCount == 0)
        {
            IsResultCheck = false;

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

  

    private void GeneratorWaterFlow()
    {

        if (GameObject.Find("1,0").GetComponent<Image>().sprite.name == "Type-0" )
        {
            GameObject.Find("1,0").GetComponent<Image>().sprite = Waterflow;
        }

        //case-1
        if (GameObject.Find("1,0").GetComponent<Image>().sprite.name == "Type-1"  && GameObject.Find("1,1").GetComponent<Image>().sprite.name == "Type-0")
        {
            GameObject.Find("1,1").GetComponent<Image>().sprite = Waterflow;
        }
        if (GameObject.Find("1,0").GetComponent<Image>().sprite.name == "Type-1" && GameObject.Find("1,1").GetComponent<Image>().sprite.name == "Type-5" && GameObject.Find("2,1").GetComponent<Image>().sprite.name == "Type-3" && GameObject.Find("2,2").GetComponent<Image>().sprite.name == "Type-0")
        {     
            GameObject.Find("2,2").GetComponent<Image>().sprite = Waterflow;
        }

        //case-2
        if (GameObject.Find("1,0").GetComponent<Image>().sprite.name == "Type-5" && GameObject.Find("2,0").GetComponent<Image>().sprite.name == "Type-3"  && GameObject.Find("2,1").GetComponent<Image>().sprite.name == "Type-0")
        {
            GameObject.Find("2,1").GetComponent<Image>().sprite = Waterflow;
        }
        if (GameObject.Find("1,0").GetComponent<Image>().sprite.name == "Type-5" && GameObject.Find("2,0").GetComponent<Image>().sprite.name == "Type-3" && GameObject.Find("2,1").GetComponent<Image>().sprite.name == "Type-2" && GameObject.Find("1,2").GetComponent<Image>().sprite.name == "Type-2")
        {
            GameObject.Find("1,2").GetComponent<Image>().sprite= Waterflow;
        }

        //Case-3
        if (GameObject.Find("1,0").GetComponent<Image>().sprite.name == "Type-2" && GameObject.Find("0,0").GetComponent<Image>().sprite.name == "Type-4" && GameObject.Find("0,1").GetComponent<Image>().sprite.name == "Type-0")
        {
            GameObject.Find("0,1").GetComponent<Image>().sprite = Waterflow;
        }
        if (GameObject.Find("1,0").GetComponent<Image>().sprite.name == "Type-2" && GameObject.Find("0,0").GetComponent<Image>().sprite.name == "Type-4" && GameObject.Find("0,1").GetComponent<Image>().sprite.name == "Type-5" && GameObject.Find("1,1").GetComponent<Image>().sprite.name == "Type-3" && GameObject.Find("1,2").GetComponent<Image>().sprite.name == "Type-0")
        {
            GameObject.Find("1,2").GetComponent<Image>().sprite = Waterflow;
        }
        //case4
        if (GameObject.Find("1,0").GetComponent<Image>().sprite.name == "Type-2" && GameObject.Find("0,0").GetComponent<Image>().sprite.name == "Type-4" && GameObject.Find("0,1").GetComponent<Image>().sprite.name == "Type-5" && GameObject.Find("1,1").GetComponent<Image>().sprite.name == "Type-3" && GameObject.Find("1,2").GetComponent<Image>().sprite.name == "Type-0")
        {
            GameObject.Find("1,2").GetComponent<Image>().sprite = Waterflow;
        }

         //case5
        if (GameObject.Find("1,0").GetComponent<Image>().sprite.name == "Type-5" && GameObject.Find("2,0").GetComponent<Image>().sprite.name == "Type-4" && GameObject.Find("2,1").GetComponent<Image>().sprite.name == "Type-0" )
        {
            GameObject.Find("2,1").GetComponent<Image>().sprite = Waterflow;
        }
      
    }

    public void GameOver()
   {
        PlayerPrefs.SetInt("Score", 3);
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

        if (IsResultCheck == true)
        {

            //case1
            if (GameObject.Find("1,0").GetComponent<Image>().sprite.name == "Type-5")
            {
                if (GameObject.Find("2,0").GetComponent<Image>().sprite.name == "Type-3")
                {
                    if (GameObject.Find("2,1").GetComponent<Image>().sprite.name == "Type-2")
                    {
                        if (GameObject.Find("1,1").GetComponent<Image>().sprite.name == "Type-4")
                        {
                            if (GameObject.Find("1,2").GetComponent<Image>().sprite.name == "Type-1")
                            {
                                Debug.Log(" case2 Completed");

                                Debug.Log("Completed");
                                OutWaterflow.SetActive(true);
                                timerActive = false;
                                Invoke("GameOver", 1f);
                            }

                        }
                    }
                }
            }
            //case2
            if (GameObject.Find("1,0").GetComponent<Image>().sprite.name == "Type-1")
            {
                if (GameObject.Find("1,1").GetComponent<Image>().sprite.name == "Type-5")
                {
                    if (GameObject.Find("2,1").GetComponent<Image>().sprite.name == "Type-3")
                    {
                        if (GameObject.Find("2,2").GetComponent<Image>().sprite.name == "Type-2")
                        {
                            if (GameObject.Find("1,2").GetComponent<Image>().sprite.name == "Type-4")
                            {
                                Debug.Log(" case1 Completed");

                                Debug.Log("Completed");
                                OutWaterflow.SetActive(true);
                                timerActive = false;
                                Invoke("GameOver", 1f);
                            }

                        }
                    }
                }
            }

            //case3
            if (GameObject.Find("1,0").GetComponent<Image>().sprite.name == "Type-2")
            {
                if (GameObject.Find("0,0").GetComponent<Image>().sprite.name == "Type-4")
                {
                    if (GameObject.Find("0,1").GetComponent<Image>().sprite.name == "Type-5")
                    {
                        if (GameObject.Find("1,1").GetComponent<Image>().sprite.name == "Type-3")
                        {
                            if (GameObject.Find("1,2").GetComponent<Image>().sprite.name == "Type-1")
                            {
                                Debug.Log(" case3 Completed");

                                Debug.Log("Completed");
                                OutWaterflow.SetActive(true);
                                timerActive = false;
                                Invoke("GameOver", 1f);
                            }

                        }
                    }
                }
            }

            //case4
            if (GameObject.Find("1,0").GetComponent<Image>().sprite.name == "Type-5")
            {
                if (GameObject.Find("2,0").GetComponent<Image>().sprite.name == "Type-3")
                {
                    if (GameObject.Find("2,1").GetComponent<Image>().sprite.name == "Type-2")
                    {
                        if (GameObject.Find("1,1").GetComponent<Image>().sprite.name == "Type-4")
                        {
                            if (GameObject.Find("1,2").GetComponent<Image>().sprite.name == "Type-1")
                            {
                                Debug.Log(" case5 Completed");

                                Debug.Log("Completed");
                                OutWaterflow.SetActive(true);
                                timerActive = false;
                                Invoke("GameOver", 1f);
                            }

                        }
                    }
                }
            }
            //case5
            if (GameObject.Find("1,0").GetComponent<Image>().sprite.name == "Type-1")
            {
                if (GameObject.Find("1,1").GetComponent<Image>().sprite.name == "Type-2")
                {
                    if (GameObject.Find("0,1").GetComponent<Image>().sprite.name == "Type-4")
                    {
                        if (GameObject.Find("0,2").GetComponent<Image>().sprite.name == "Type-5")
                        {
                            if (GameObject.Find("1,2").GetComponent<Image>().sprite.name == "Type-3")
                            {
                                Debug.Log(" case5 Completed");

                                Debug.Log("Completed");
                                OutWaterflow.SetActive(true);
                                timerActive = false;
                                Invoke("GameOver", 1f);
                            }

                        }
                    }
                }
            }

            //Case6
            if (GameObject.Find("1,0").GetComponent<Image>().sprite.name == "Type-5")
            {
                if (GameObject.Find("2,0").GetComponent<Image>().sprite.name == "Type-3")
                {
                    if (GameObject.Find("2,1").GetComponent<Image>().sprite.name == "Type-1")
                    {
                        if (GameObject.Find("2,2").GetComponent<Image>().sprite.name == "Type-2")
                        {
                            if (GameObject.Find("1,2").GetComponent<Image>().sprite.name == "Type-4")
                            {
                                Debug.Log(" case6 Completed");

                                Debug.Log("Completed");
                                OutWaterflow.SetActive(true);
                                timerActive = false;
                                Invoke("GameOver", 1f);
                            }

                        }
                    }
                }
            }
            IsResultCheck = false;
        }

    }
}
