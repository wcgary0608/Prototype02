using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeiGongChapter
{
    private int _chapterIndex;
    public int ChapterIndex
    {
        get { return _chapterIndex; }
    }

    private bool _isActive;
    public bool IsActive
    {
        get { return _isActive; }
    }

    public bool IsComplete { get; set; }


    private string _chapterName;
    public string ChapterName
    {
        get { return _chapterName; }
    }


    private List<string[]> _listChapterConditions;
    public List<string[]> ListChapterConditions
    {
        get { return _listChapterConditions; }
    }

    private List<string[]> _listChapterAwards;
    public List<string[]> ListChapterAwards
    {
        get { return _listChapterAwards; }
    }

    public NeiGongChapter(string[] data, int index)
    {
        _isActive = false;

        _chapterIndex = index;

        _chapterName = data[0];

        string[] hpGain = data[1].Split(new char[] { '/' });
        string[] mpGain = data[2].Split(new char[] { '/' });
        string[] shenFaGain = data[3].Split(new char[] { '/' });
        string[] skillGain = data[4].Split(new char[] { '/' });
       

        string[] expCost = data[5].Split(new char[] { '/' });
        string[] hpCost = data[6].Split(new char[] { '/' });
        string[] shenFaCost = data[7].Split(new char[] { '/' });
        string[] spotRequire = data[8].Split(new char[] { '/' });
        _listChapterAwards = new List<string[]>() { hpGain, mpGain, shenFaGain, skillGain };
        _listChapterConditions = new List<string[]>() { expCost, hpCost, shenFaCost, spotRequire };
    }

}
