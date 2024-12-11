using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class represents a story block with text and options
class StoryBlock
{
    public string story;
    public string opChoiceTxt1;
    public string opChoiceTxt2;
    public StoryBlock optionOne;
    public StoryBlock optionTwo;

    public StoryBlock(string story, string opChoiceTxt1 = "", string opChoiceTxt2 = "", StoryBlock optionOne = null, StoryBlock optionTwo = null)
    {
        this.story = story;
        this.opChoiceTxt1 = opChoiceTxt1;
        this.opChoiceTxt2 = opChoiceTxt2;
        this.optionOne = optionOne;
        this.optionTwo = optionTwo;
    }
}

public class GameManager : MonoBehaviour
{
    private StoryBlock currentBlock;

    // References to UI elements
    public Text mainText;
    public Button opOne;
    public Button opTwo;

    // Story blocks
    private static StoryBlock block1;
    private static StoryBlock block2;
    private static StoryBlock block3;
    private static StoryBlock block4;
    private static StoryBlock block5;
    private static StoryBlock block6;
    private static StoryBlock block7;
    private static StoryBlock block8;
    private static StoryBlock block9;
    private static StoryBlock block10;
    private static StoryBlock block11;
    private static StoryBlock block12;

    void Start()
    {
        InitializeStoryBlocks();
        DisplayBlock(block1);
    }

    void InitializeStoryBlocks()
    {
        // Initialize all story blocks
        block12 = new StoryBlock("The man takes out a knife and stabs your thigh... \nAnd you drop the gun... \nThe man picks it up and points it at you, smiles and pulls the trigger... \nGAME OVER", "Restart", "", block1);
        block11 = new StoryBlock("You turn and you look at the TV... \nYou state that you will find the mystery man and you will kill him. \nMystery Man: (Laughs)... \n*beep!* \nAll the doors shut and a toxic fume starts to fill the room... \nYou start to lose vision and can't breathe... GAME OVER!", "Restart", "", block1);
        block10 = new StoryBlock("You feel the sun on your skin for the first time in what seems like forever... \nThe thought of freedom distracts you so much that you don't entertain other thoughts... \nThe End.", "Restart", "", block1);
        block9 = new StoryBlock("You tackle the man... \nBut he got to the gun first... \nMystery Man: tsk tsk tsk, I had so much hope in you... \nThe man fires the gun without hesitation... \nGAME OVER!", "Restart", "", block1);
        block8 = new StoryBlock("You rush towards the gun and you lunge on top of the table... \nBoth of you have your hands on the gun... \nThe TV starts playing... \nMystery Man: (laughs) I wonder who has the guts to fight for their freedom?... \nThe gun goes off, the man is distracted... You see a chance to pull the gun from him... \nYou are standing over him with a gun pointing towards him.", "Shoot", "Don't shoot", block6, block12);
        block7 = new StoryBlock("You ask, \"Who are you?\" \nThe room is silent for a long minute... \nMystery Man: Wrong answer. \nFrom the corner of your eye, you see a dark shadow... \nYou see the gun, it's in the middle of you two... \nThe figure rushes towards the gun.", "Rush Towards Gun", "Rush Towards the Figure", block8, block9);
        block6 = new StoryBlock("BOOM! \nThe room is silent... \nYour ears are ringing... \nYour vision blurs... \nThe TV reveals what you've done... a lifeless body. \nMystery Man: Wow, I didn't know you had the guts... You are free to go.", "Leave", "Stay and look for Mystery Man", block10, block11);
        block5 = new StoryBlock("You ask, \"Who are you?\" \nThe room is silent for a long minute... \nMystery Man: Wrong answer. \nA dark shadow appears in the corner... \nThe gun is between you two... \nThe figure rushes towards the gun.", "Rush Towards Gun", "Rush Towards the Figure", block8, block9);
        block4 = new StoryBlock("You grab the gun... \nA shiver goes down your spine... \nMystery Man: (Laughs) \nA huge shadowy figure rushes towards you.", "SHOOT!", "Shout out \"Wait!\"", block6, block7);
        block3 = new StoryBlock("The room is dingy and smells putrid. \nSymbols on the wall read: \"IT'S NOT A G, DO NOT TRUST.\" \nYou walk towards the light into a room with a TV playing. \nMystery Man: Ah! You are awake... Pick up the gun in front of you.", "Who are you?", "Pick up gun", block5, block4);
        block2 = new StoryBlock("You walk towards the light into a room with a TV playing. \nMystery Man: Ah! You are awake... Pick up the gun in front of you.", "Who are you?", "Pick up gun", block5, block4);
        block1 = new StoryBlock("You wake up in a dark room, smelling the weight of the air... \nYou see a glimmer of light in the distance.", "Walk towards the light", "Gather your bearings", block2, block3);
    }

    void DisplayBlock(StoryBlock block)
    {
        mainText.text = block.story;

        if (!string.IsNullOrEmpty(block.opChoiceTxt1))
        {
            opOne.gameObject.SetActive(true);
            opOne.GetComponentInChildren<Text>().text = block.opChoiceTxt1;
        }
        else
        {
            opOne.gameObject.SetActive(false);
        }

        if (!string.IsNullOrEmpty(block.opChoiceTxt2))
        {
            opTwo.gameObject.SetActive(true);
            opTwo.GetComponentInChildren<Text>().text = block.opChoiceTxt2;
        }
        else
        {
            opTwo.gameObject.SetActive(false);
        }

        currentBlock = block;
    }

    public void ButtonOneClicked()
    {
        if (currentBlock.optionOne != null)
        {
            DisplayBlock(currentBlock.optionOne);
        }
        else
        {
            DisplayBlock(block1);
        }
    }

    public void ButtonTwoClicked()
    {
        if (currentBlock.optionTwo != null)
        {
            DisplayBlock(currentBlock.optionTwo);
        }
        else
        {
            DisplayBlock(block1);
        }
    }
}
