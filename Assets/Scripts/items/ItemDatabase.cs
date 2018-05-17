using UnityEngine;
using System.Collections.Generic;
using System;
using System.Xml;

public class ItemDatabase : MonoBehaviour {
   // Size comes from items.xml.  Scrolling to the very bottom should give you size.
   private const int MaxSize = 2004;

   // Array is likely better as it is easier O(1) to grab information from and don't need to loop...
   // List is easier to add things but since our database will be constant size for the most part...
   // Could also use List to put in item since it's better at allocating more size then convert to array
   // Empty list in that case, could also use a map or set to id -> item.
   // HashMap or HashSet is the best.
   private Dictionary<int, BaseItem> database = new Dictionary<int, BaseItem>(MaxSize);

   public static ItemDatabase instance = null;

   void Awake() {
      instance = this;
      //Parse the items and put into the dictionary, database
      ParseXmlDocument();
   }

   public BaseItem GetItemById(int id) {
      return database[id];
   }


   /**
    * Parses the items.xml for items to put into the dictionary
    * The XML has the following form:
    * <xs:element name="id"          type="xs:integer" minOccurs="1" maxOccurs="1"/>
    * <xs:element name="type"        type="type"       minOccurs="1" maxOccurs="1"/>
    * <xs:element name="name"        type="xs:string"  minOccurs="1" maxOccurs="1"/>
    *
    * @return {[type]} [description]
    */
   private void ParseXmlDocument() {
      const string xmlUrl = "Xml/items";
      TextAsset xml = (TextAsset)Resources.Load(xmlUrl);
      XmlDocument doc = new XmlDocument();

      if (xml != null) {
         doc.LoadXml(xml.text);
      }
      else {
         Debug.Log("File " + xmlUrl + " does not exist");
         return;
      }

      XmlNode itemNode = doc.SelectSingleNode("itemdatabase");
      XmlNodeList itemNodeList = itemNode.SelectNodes("item");
      foreach (XmlNode node in itemNodeList) {
         BaseItem item = new BaseItem();
         XmlNode attrNode;

         item.ItemID = Convert.ToInt32(node.SelectSingleNode("id").InnerText);
         item.SlotType = (BaseItem.SlotTypes)Convert.ToInt32(node.SelectSingleNode("slot").InnerText);
         item.ItemType = (BaseItem.ItemTypes)Convert.ToInt32(node.SelectSingleNode("type").InnerText);
         item.ItemName = node.SelectSingleNode("name").InnerText;

         attrNode = node.SelectSingleNode("str");
         if (attrNode != null) {
            item.Strength = Convert.ToInt32(attrNode.InnerText);
         }

         attrNode = node.SelectSingleNode("stacksize");
         if (attrNode != null) {
            item.Stacksize = Convert.ToInt32(attrNode.InnerText);
         }

         database.Add(item.ItemID, item);
      }
   }
}