using UnityEngine;
using UnityEditor;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    // Add Example1 into a new menu list
    [MenuItem("Example/Example1", false, 100)]
    public static void Example1()
    {
        print("Example/Example1");
    }

    // Add Example2 into the same menu list
    [MenuItem("Example/Example2", false, 100)]
    public static void Example2()
    {
        print("Example/Example2");
    }
}