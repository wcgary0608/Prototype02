using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot {

    private string _spotName;
    public string SpotName
    {
        get { return _spotName; }
    }

    private string _spotDescription;
    public string SpotDescription
    {
        get { return _spotDescription; }
    }

    private Vector2 _spotLocation;
    public Vector2 SpotLocation
    {
        get { return _spotLocation; }
    }

    private Distribution _belongingDistribution;
    public Distribution BelongingDistribution
    {
        get { return _belongingDistribution; }
    }

}
