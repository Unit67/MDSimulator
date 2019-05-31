using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    public static void SavePlayer(PlayerController player)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.MDSimulatorSaveFile";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        binaryFormatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.MDSimulatorSaveFile";

        if(File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path,FileMode.Open);

            PlayerData data = binaryFormatter.Deserialize(fileStream) as PlayerData;

            Debug.Log("Des: " + data.Des + " Money:" + data.Money + " Pos: " + data.Pos[0] + " " + data.Pos[1] + " " + data.Pos[2]);

            fileStream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
    public static Vector3 GetPlayerPos()
    {
        string path = Application.persistentDataPath + "/player.MDSimulatorSaveFile";
        Vector3 Pos = new Vector3();

        if(File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            PlayerData data = binaryFormatter.Deserialize(fileStream) as PlayerData;
            if(data.Pos != null)
            {
                Pos = new Vector3(data.Pos[0], data.Pos[1], data.Pos[2]);
                return Pos;
            }
        }
        return Pos;
    }
}
