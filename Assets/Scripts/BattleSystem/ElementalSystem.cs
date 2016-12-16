using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public  class ElementalSystem : ScriptableObject {
    public enum Element { Neutral , Fire , Thunder, Water };

    private static bool initalized = false;

    static Dictionary<Element, List<Element>> effective = new Dictionary<Element, List<Element>>();
    static Dictionary<Element, List<Element>> innefective = new Dictionary<Element, List<Element>>();
    public static void Initialize()
    {
        if (initalized)
            return;
        effective.Add(Element.Fire, new List<Element> { Element.Thunder });
        effective.Add(Element.Thunder, new List<Element> { Element.Water });
        effective.Add(Element.Water, new List<Element> { Element.Fire });
        effective.Add(Element.Neutral, new List<Element> {  });
        innefective.Add(Element.Fire, new List<Element> { Element.Water });
        innefective.Add(Element.Thunder, new List<Element> { Element.Fire });
        innefective.Add(Element.Water, new List<Element> { Element.Thunder });
        innefective.Add(Element.Neutral, new List<Element> { });
        initalized = true;
    }

    public static float GetDamageRatio(Element source , Element destination )
    {
        //Est efficace 
        if (effective[source].Contains(destination))
            return 2f;
        //N'est pas efficace 
        if (innefective[source].Contains(destination))
            return 0.5f;

        return 1;
    }
}
