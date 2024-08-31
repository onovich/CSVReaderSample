using System;
using NReco.Csv;

[Serializable]
public struct RoleTM {

    public int typeID;
    public string name;
    public int hp;

    public void FromCSV(CsvReader csv) {
        typeID = int.Parse(csv[0]);
        name = csv[1];
        hp = int.Parse(csv[2]);
    }

}