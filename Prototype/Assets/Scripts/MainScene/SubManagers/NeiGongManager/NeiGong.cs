using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeiGong
{
    private string _id;
    public string Id
    {
        get { return _id; }
    }

    private string _name;
    public string Name
    {
        get { return _name; }
    }

    private string _quality;
    public string Quality
    {
        get { return _quality; }
    }

    private string _description;
    public string Description
    {
        get { return _description; }
    }

    private List<int> _listActiveChapterIndex = new List<int>();
    public List<int> ListActiveChapterIndex
    {
        get { return _listActiveChapterIndex; }
    }

    private List<int> _listCompleteChapterIndex = new List<int>();
    public List<int> ListCompleteChapterIndex
    {
        get { return _listCompleteChapterIndex; }
    }

    private Dictionary<int, NeiGongChapter> _dicChapters = new Dictionary<int, NeiGongChapter>();
    public Dictionary<int, NeiGongChapter> DicChapters
    {
        get { return _dicChapters; }
    }

    public NeiGong(string[] data)
    {
        _id = data[0];
        _name = data[1];
        _quality = data[2];
        _description = data[3];

        string[] activeChapters = data[4].Split(new char[] { '/' });
        foreach (string id in activeChapters)
        {
            int index;
            int.TryParse(id, out index);
            _listActiveChapterIndex.Add(index);
        }

        if (data[5] != "")
        {
            string[] completeChapters = data[5].Split(new char[] { '/' });

            foreach (string id in completeChapters)
            {
                int index;
                int.TryParse(id, out index);
                _listCompleteChapterIndex.Add(index);
            }
        }

        List<string[]> listChapterData = NeiGongData.DicNeiGongChapterData[_id];
        for(int i = 0; i < listChapterData.Count; i++)
        {
            NeiGongChapter chapter = new NeiGongChapter(listChapterData[i], i);
            _dicChapters.Add(i, chapter);
        }


    }

}


