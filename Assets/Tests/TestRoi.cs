using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestRoi
{
    [Test]
    public void TestRoiSimplePasses()
    {
        GameObject gameObject= new GameObject("RoiBlanc");
        Roi roi = gameObject.AddComponent<Roi>();
        roi.SetCoordonnees(new Coordonnees(4,4));
        List<Coordonnees> positionsPossibles = roi.PositionsPossibles(new List<IPiece>());
        Assert.Contains(new Coordonnees(4,3), positionsPossibles, "Le roi peut se déplacer à cet endroit");
    }
}
