using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveProgress{

    private static BinaryFormatter formatter = new();
    public static Progress CurrentPrigress { get; private set; }

    public static void Saveing(Progress prigress) {
        Debug.Log("C����������� ����������");
        using (FileStream fs = new("Save.dat", FileMode.OpenOrCreate)) {
            // ����������� ���� ������ people
            prigress.FixTime();
            formatter.Serialize(fs, prigress);
            CurrentPrigress = new(prigress);
            Debug.Log("���������� ������������");
        }
    }

    public static Progress Reading() {
        Progress prigress;
        // ��������������
        Debug.Log("������ ����������");
        using (FileStream fs = new("Save.dat", FileMode.OpenOrCreate)) {
            prigress = new ((Progress)formatter.Deserialize(fs));
            CurrentPrigress = new(prigress);
            Debug.Log("���������� ��������");
        }
        return prigress;
    }
}
