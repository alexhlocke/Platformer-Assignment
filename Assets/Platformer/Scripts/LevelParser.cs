using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;
    public GameObject stonePrefab;
    public GameObject coinPrefab;
    public GameObject flagPrefab;
    public GameObject waterPrefab;
    public Transform environmentRoot;

    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
    }

    // --------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");

        Stack<string> levelRows = new Stack<string>();

        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }

        // Go through the rows from bottom to top
        int row = 0;
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            int column = 0;
            char[] letters = currentLine.ToCharArray();
            foreach (var letter in letters)
            {
                // Todo - Instantiate a new GameObject that matches the type specified by letter
                

                if (letter == 'x')
                {
                    var testObject = Instantiate(rockPrefab);
                    testObject.transform.position = new Vector3(column+0.5f, row+0.5f, 0f);
                } else if (letter == 'b')
                {
                    var testObject = Instantiate(brickPrefab);
                    testObject.transform.position = new Vector3(column + 0.5f, row + 0.5f, 0f);
                } else if (letter == '?')
                {
                    var testObject = Instantiate(questionBoxPrefab);
                    testObject.transform.position = new Vector3(column + 0.5f, row + 0.5f, 0f);
                } else if (letter == 's')
                {
                    var testObject = Instantiate(stonePrefab);
                    testObject.transform.position = new Vector3(column + 0.5f, row + 0.5f, 0f);
                } else if (letter == 'c')
                {
                    var testObject = Instantiate(coinPrefab);
                    testObject.transform.position = new Vector3(column + 0.5f, row + 0.5f, 0.2f);
                } else if (letter == 'f')
                {
                    var testObject = Instantiate(flagPrefab);
                    testObject.transform.position = new Vector3(column + 0.24f, row + 5.47f, 0.2f);
                    var testObject2 = Instantiate(stonePrefab);
                    testObject2.transform.position = new Vector3(column + 0.5f, row + 0.5f, 0f);
                } else if (letter == 'w')
                {
                    var testObject = Instantiate(waterPrefab);
                    testObject.transform.position = new Vector3(column + 0.5f, row + 0.5f, 0.2f);
                }

                // Todo - Position the new GameObject at the appropriate location by using row and column
                // Todo - Parent the new GameObject under levelRoot
                column++;
            }
            row++;
        }
    }

    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in environmentRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
