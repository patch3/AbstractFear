using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveProgress{

    private static BinaryFormatter formatter = new();
    public static Progress CurrentPrigress { get; private set; }

    public static void Saveing(Progress prigress) {
        Debug.Log("Cериализация сохранение");
        using (FileStream fs = new("Save.dat", FileMode.OpenOrCreate)) {
            // сериализуем весь массив people
            prigress.FixTime();
            formatter.Serialize(fs, prigress);
            CurrentPrigress = new(prigress);
            Debug.Log("Сохранение сериализован");
        }
    }

    public static Progress Reading() {
        Progress prigress;
        // десериализация
        Debug.Log("Чтение сохранение");
        using (FileStream fs = new("Save.dat", FileMode.OpenOrCreate)) {
            prigress = new ((Progress)formatter.Deserialize(fs));
            CurrentPrigress = new(prigress);
            Debug.Log("Сохранение прочтено");
        }
        return prigress;
    }
}
