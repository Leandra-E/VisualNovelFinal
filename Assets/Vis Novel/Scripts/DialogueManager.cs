using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    //Text Component
    public TextMeshPro Text;
    //The SpriteRenderer that draws the speaking character
    public SpriteRenderer Character;
    //The SpriteRenderer that draws the background
    public SpriteRenderer Background;
    public TextMeshPro NameText;
    
    //button components
    public GameObject buttonA;
    public GameObject buttonB;
    public GameObject buttonC;

    public GameObject buttonpg35A;
    public GameObject buttonpg35B;
    public GameObject buttonpg35C;
    
    public GameObject buttonpg43A;
    public GameObject buttonpg43B;
    
    
    
    //A list of all the character sprites
    //I need to make these variables, so I can reference them
    public Sprite ElliotDefault;
    public Sprite AnastasiaDefault;
    public Sprite BlairDefault;
    public Sprite GarrettDefault;
    public Sprite EmersonDefault;
    public Sprite MorganDefault;
    public Sprite ArthurDefault;
    public Sprite TheaDefault;
    public Sprite LouisDefault;
    public Sprite Player;
    public Sprite Notice;
    
    //A list of all the background sprites
    public Sprite MansionBG;
    public Sprite FoyerBG;
    public Sprite StudyBG;
    public Sprite ObservatoryBG;
    public Sprite LibraryBG;
    public Sprite LoungeBG;
    public Sprite BarBG;
    
    //A list of all the lines of dialogue
    //These will be read out by the characters in order
    //DialogueLine is a custom class at the bottom of this script
    public List<DialogueLine> Lines;
    //Which line of dialogue am I currently on?
    public int Index = 0;

    void Start()
    {
        //Here I make sure to imprint the first line of dialogue
            //on the text/sprite renderers
        ImprintLine();
    }

    private void Update()
    {
        //If I hit space. . .
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Set the current line of dialogue to the next one
            Index = Lines[Index].NextPage;
            //And redo all the text and art to match it
            ImprintLine();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            //Set the current line of dialogue to the next one
            Index = Lines[Index].AltNextPage;
            //And redo all the text and art to match it
            ImprintLine();
        }
    }

    //Makes all the text and art match the dialogue line we're currently on
    public void ImprintLine()
    {
        //If we've hit the end of the script. . .
        if (Index >= Lines.Count)
        {
            //End the game
            SceneManager.LoadScene("You Win");
            return;
        }

        //Find which line of dialogue we're currently on
        DialogueLine current = Lines[Index];
        //Set the text to match that line's dialogue text
        Text.text = current.Text;
        //Find the character art the line of dialogue requests
        Character.sprite = GetCharacter(current.Character);
        //Find the background art the line of dialogue requests
        Background.sprite = GetBackground(current.Background);
        NameText.text = current.NameText;


        if (Index == 8)
        {
            buttonA.SetActive(true);
            buttonB.SetActive(true);
            buttonC.SetActive(true);
        }
        else
        {
            buttonA.SetActive(false);
            buttonB.SetActive(false);
            buttonC.SetActive(false);
        }

        if (Index == 35)
        {
            buttonpg35A.SetActive(true);
            buttonpg35B.SetActive(true);
            buttonpg35C.SetActive(true);
        }
        else
        {
            buttonpg35A.SetActive(false);
            buttonpg35B.SetActive(false);
            buttonpg35C.SetActive(false);
        }

        if (Index == 43)
        {
            buttonpg43A.SetActive(true);
            buttonpg43B.SetActive(true);
        }
        else
        {
            buttonpg43A.SetActive(false);
            buttonpg43B.SetActive(false);
        }
    }

    //Convert the text description of a character to a sprite
    public Sprite GetCharacter(string who)
    {
        //If the dialogue line calls for "Gary", use this sprite
        if (who == "Elliot") return ElliotDefault;
        //And so on. . .
        if (who == "Anastasia") return AnastasiaDefault;
        if (who == "Garrett") return GarrettDefault;
        if (who == "Louis") return LouisDefault;
        if (who == "Morgan") return MorganDefault;
        if (who == "Emerson") return EmersonDefault;
        if (who == "Arthur") return ArthurDefault;
        if (who == "Blair") return BlairDefault;
        if (who == "Thea") return TheaDefault;
        if (who == "Player") return Player;
        if (who == "Notice") return Notice;
        //If Character is left blank, just don't change anything
        return Character.sprite;
    }
    
    //Convert the text description of a background to a sprite
    public Sprite GetBackground(string where)
    {
        //If the dialogue line calls for "Outside", use this sprite
        if (where == "Outside") return MansionBG;
        //If the dialogue line calls for "Inside", use this sprite
        if (where == "Foyer") return FoyerBG;
        if (where == "Study") return StudyBG;
        if (where == "Lounge") return LoungeBG;
        if (where == "Library") return LibraryBG;
        if (where == "Observatory") return ObservatoryBG;
        if (where == "Bar") return BarBG;
        //If Background is left blank, just don't change anything
        return Background.sprite;
    }
    
    
    public void MakeChoiceA()
    {
        Index = 9;
        ImprintLine();
    }

    public void MakeChoiceB()
    {
      Index = 10;
      ImprintLine();
    }
    public void MakeChoiceC()
    {
      Index = 11;
      ImprintLine();
    }

    public void MakeChoice35A()
    {
        Index = 36;
        ImprintLine();
    }

    public void MakeChoice35B()
    {
        Index = 0;
        ImprintLine();
    }

    public void MakeChoice35C()
    {
        Index = 0;
        ImprintLine();
    }

    public void MakeChoice43A()
    {
        Index = 0;
        ImprintLine();
    }
    
    public void MakeChoice43B()
    {
        Index = 0;
        ImprintLine();
    }
    
}

//This line makes a class appear in the Unity Inspector
  //when used as a variable type
[System.Serializable]
public class DialogueLine
{
    //A custom class that just records dialogue, a character, and a background
    //Think of it almost like a Vector3, but for story instead of position
    public string Text;
    public string Character;
    public string Background;
    public string NameText;
    public int Index;
    public int NextPage;
    public int AltNextPage;
    public int AltNextNextPage;


}
