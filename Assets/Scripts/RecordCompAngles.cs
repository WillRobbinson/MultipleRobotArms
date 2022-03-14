using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class RecordCompAngles : MonoBehaviour
{
    public InputField inputField;

    void Awake()
    {
        // load value
    }


    // Start is called before the first frame update
    void Start()
    {
        //Save(3, new Vector3(1, 2, 3));
        //SaveObject so = Load();
        //if (so != null)
        //{
        //    print("Loaded: " + so);
        //} else
        //{
        //    print("Not so much");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveAngle()
    {
        string jointName = "ShoulderJoint";
        string jointAngle = inputField.text;
        Save(jointName, jointAngle);
    }

    private void Save(string jointName,string jointAngle)
    {
        SaveObject saveObject = new SaveObject
        {
            jointName = jointName,
            jointAngle = jointAngle
        };
        string json = JsonUtility.ToJson(saveObject);
        File.WriteAllText(Application.dataPath + "/save.json",json);
        print(json);
        SaveObject loadedSaveObject = JsonUtility.FromJson<SaveObject>(json);
        print("LoadedGoldAmount:"+loadedSaveObject.jointAngle);
    }

    private SaveObject Load()
    {
        if (File.Exists(Application.dataPath+"/save.json"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/save.json");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            print("Load: saveObject: "+saveObject);
            return saveObject;
        }
        return null;
    }
}

class SaveObject
{
    public string jointName;
    public string jointAngle;
}