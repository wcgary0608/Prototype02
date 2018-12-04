using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NeiGongData{

    public static Dictionary<string, string[]> DicNeiGongData = new Dictionary<string, string[]>();
    public static Dictionary<string, List<string[]>> DicNeiGongChapterData = new Dictionary<string, List<string[]>>();

    public static void Initialize()
    {
        string[] n1 = new string[] {"n1", "虎啸功", "良", "习练者当如深山呼啸，其力无穷，震慑群山。","0/1/2", "0" };
        string[] n2 = new string[] { "n2", "先天功", "绝", "养先天浩然之气，藏于内府而游于百脉。", "0", "" };

        string[] n1c0 = new string[] { "入门", "HpGain/2", "MpGain/1", "ShenFaGain/1", "SkillGain/1", "ExpCost/20", "HpCost/1", "ShenFaCost/0", "SpotRequire/" };
        string[] n1c1 = new string[] { "总纲", "HpGain/2", "MpGain/1", "ShenFaGain/1", "SkillGain/", "ExpCost/40", "HpCost/1", "ShenFaCost/0", "SpotRequire/" };
        string[] n2c0 = new string[] { "口授", "HpGain/5", "MpGain/2", "ShenFaGain/1", "SkillGain/", "ExpCost/60", "HpCost/1", "ShenFaCost/0", "SpotRequire/" };

        List<string[]> listN1 = new List<string[]>() { n1c0, n1c1, n1c0, n1c1, n1c1, n1c1, n1c1,n1c1,n1c1};
        List<string[]> listN2 = new List<string[]>() { n2c0, n2c0, n2c0, n2c0, n2c0, n2c0, n2c0, n2c0, n2c0};
        DicNeiGongData.Add("n1", n1);
        DicNeiGongData.Add("n2", n2);

        DicNeiGongChapterData.Add("n1", listN1);
        DicNeiGongChapterData.Add("n2", listN2);
    }

}
