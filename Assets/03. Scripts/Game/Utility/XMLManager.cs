using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using UnityEngine;

public class XMLManager
{
    private static XMLManager instance = new XMLManager();
    public static XMLManager Instance { get { return instance; } }

    XmlNodeList characterTable;
    XmlNodeList enemyTable;

    //DESC : 초기화
    public XMLManager()
    {
        Load_Character();
        Load_Enemy();
    }
    //DESC : Load_XXX
    public void Load_Character()
    {
        TextAsset textAsset = Resources.Load("XML/Character") as TextAsset;
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml(textAsset.text);

        characterTable = xmldoc.SelectNodes("NewDataSet/Sheet1");
    }
    public void Load_Enemy()
    {
        TextAsset textAsset = Resources.Load("XML/Enemy") as TextAsset;
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml(textAsset.text);

        enemyTable = xmldoc.SelectNodes("NewDataSet/Sheet1");
    }
    public CharacterInfo Load_CharacterData(int id)
    {
        CharacterInfo temp = new CharacterInfo();

        foreach(XmlNode node in characterTable)
        {
            if(id == int.Parse(node.SelectSingleNode("ID").InnerText))
            {
                temp.ID = id;
                temp.HP = int.Parse(node.SelectSingleNode("HP").InnerText);
                temp.AP = int.Parse(node.SelectSingleNode("AP").InnerText);
                temp.Name = node.SelectSingleNode("Name").InnerText;
                temp.Sac1 = int.Parse(node.SelectSingleNode("Sac1").InnerText);
                temp.Sac2 = int.Parse(node.SelectSingleNode("Sac2").InnerText);
                temp.Sac3 = int.Parse(node.SelectSingleNode("Sac3").InnerText);
                temp.Sac4 = int.Parse(node.SelectSingleNode("Sac4").InnerText);
                temp.Sac5 = int.Parse(node.SelectSingleNode("Sac5").InnerText);

                return temp;
            }
        }
        return null;
    }
    public EnemyInfo Load_EnemyData(int id)
    {
        EnemyInfo temp = new EnemyInfo();

        foreach(XmlNode node in enemyTable)
        {
            if(id == int.Parse(node.SelectSingleNode("ID").InnerText))
            {
                temp.ID = id;
                temp.Name = node.SelectSingleNode("Name").InnerText;
                temp.HP = int.Parse(node.SelectSingleNode("HP").InnerText);
                temp.AP = int.Parse(node.SelectSingleNode("AP").InnerText);

                return temp;
            }
        }
        return null;
    }
}

public class CharacterInfo
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int HP { get; set; }
    public int AP { get; set; }
    public int Sac1 { get; set; }
    public int Sac2 { get; set; }
    public int Sac3 { get; set; }
    public int Sac4 { get; set; }
    public int Sac5 { get; set; }
}

public class EnemyInfo
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int HP { get; set; }
    public int AP { get; set; }
}

