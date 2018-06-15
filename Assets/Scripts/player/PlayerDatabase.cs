using UnityEngine;
using System.Collections.Generic;
using System;
using System.Xml;

public class PlayerDatabase : MonoBehaviour {
   public static PlayerDatabase instance = null;

   private void Awake() {
      instance = this;
      //ParseXmlDocument();
      SavePlayerData();
   }

   private void OnApplicationQuit() {
      SavePlayerData();
   }

   private void ParseXmlDocument() {
      const string xmlUrl = "";
      TextAsset xml = (TextAsset)Resources.Load(xmlUrl);
      XmlDocument doc = new XmlDocument();

      if (xml != null) {
         doc.LoadXml(xml.text);
      }
      else {
         Debug.Log("File " + xmlUrl + " does not exist");
         return;
      }
   }

   public void SavePlayerData() {
      SkillManager mgr = GameObject.FindGameObjectWithTag("Player").GetComponent<SkillManager>();
      XmlDocument xmlDoc = new XmlDocument();

      XmlNode rootNode = xmlDoc.CreateElement("player");
      xmlDoc.AppendChild(rootNode);

      XmlNode node = xmlDoc.CreateElement("stats");

      foreach (int type in Enum.GetValues(typeof(SkillType))) {
         XmlNode statNode = xmlDoc.CreateElement("stat");

         XmlAttribute attr = xmlDoc.CreateAttribute("id");
         attr.Value = type.ToString();
         statNode.Attributes.Append(attr);

         attr = xmlDoc.CreateAttribute("xp");
         attr.Value = mgr.GetSkillXp((SkillType)type).ToString();
         statNode.Attributes.Append(attr);

         node.AppendChild(statNode);
      }

      rootNode.AppendChild(node);

      xmlDoc.Save(Application.dataPath + "/playerData.xml");
   }
}
