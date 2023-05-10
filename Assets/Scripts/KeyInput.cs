using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyInput : MonoBehaviour
{
    public GameObject word, letter;
    private int txtIndex = 0;
    private string str="";
    string[] myanLetters = {"က","ခ","ဂ","ဃ","င",
                            "စ","ဆ","ဇ","ျ","ည",
                            "ဋ","ဌ","ဍ","ဎ","ဏ",
                            "တ","ထ","ဒ","ဓ","န",
                            "ပ","ဖ","ဗ","ဘ","မ",
                            "ယ","ရ","လ","၀","သ",
                            "ဟ","ဠ","အ",
                            "ေ","ှ","ိ","ီ","်",
                            "္","ါ","ွ","့","ံ",
                            "ြ","ဲ","ု","ူ","း",
                            "၏","ၑ","ဝ","ဣ","၎",
                            "ဤ","၌","ဥ","၍","ဿ",
                            "ဧ","ဩ","ဪ","ဉ","ာ",
                            "ဦ","၊","။","ၒ","ၓ","ၔ",
                            "၁","၂","၃","၄","၅",
                            "၆","၇","၈","၉","၀"
    };
    string[] engLetters = {"u","c",":","C","i",
                            "p","q","Z","s","n",
                            "#","X","!","~","P",
                            "w","x","K","L","e",
                            "y","z","A","b","r",
                            "B","&","v","0","o",
                            "[","V","t",
                            "a","S","d","D","f",
                            "F","g","G","h","H",
                            "j","J","k","l",";",
                            "\\","|","W","E","R",
                            "T","Y","U","I","O",
                            "{","]","}","N","m",
                            "M","<",">","@","$","^",
                            "1","2","3","4","5",
                            "6","7","8","9","0"
    };
    List<string> text;

    // Start is called before the first frame update
    void Start()
    {
        TextReader textReader = transform.GetComponent<TextReader>();
        text = textReader.GetTextList();
        LoadTextObject(txtIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            int index = IndexOfString(Input.inputString, engLetters);
            string inputStr="";
            if(word.transform.childCount!=0)
            {
                GameObject child = word.transform.GetChild(0).gameObject;
                string str = child.transform.GetChild(0).GetComponent<Text>().text;

                if (index == -1)
                    inputStr = Input.inputString;
                else
                    inputStr = myanLetters[index];

                if (inputStr == str)
                {
                    transform.GetComponent<GameManager>().PlayerAttack();
                    Destroy(child);
                }
                else
                {
                    if (inputStr != "")
                        AudioManager.PlayWrongAudio();
                }
            }
        }
        else
            transform.GetComponent<GameManager>().player.GetComponent<Animator>().SetBool("attack", false);

        if (txtIndex == text.Count)
            return;

        if(word.transform.childCount==0)
        {
            LoadTextObject(++txtIndex);
        }

    }

    int IndexOfString(string str, string[] strList)
    {
        for (int i = 0; i < strList.Length; i++)
            if (str == strList[i])
                return i;
        return -1;
    }

    void LoadTextObject(int index)
    {
        if (text.Count != 0)
        {
            int n = text[index].Length;
            for (int i = 0; i < n; i++)
            {
                GameObject obj = Instantiate(letter);
                obj.transform.SetParent(word.transform);
                obj.transform.GetChild(0).GetComponent<Text>().text = text[index][i].ToString();
                obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
