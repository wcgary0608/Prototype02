using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distribution
{
    private string _distributionName;
    public string DistributionName
    {
        get { return _distributionName; }
    }

    private List<Spot> _listSpots = new List<Spot>();

    private List<Distribution> _listDistributionBeside = new List<Distribution>();

    public Distribution()
    {
    }
}
