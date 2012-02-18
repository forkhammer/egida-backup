using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EgidaBackup
{
    public class OptionsClass
    {
        List<OptionItem> FList = new List<OptionItem>();
        string FFilename;

        public int Count
        {
            get { return FList.Count; }
        }
        public OptionItem this[int Index]
        {
            get { return FList[Index]; }
        }
        public OptionItem this[string Name]
        {
            get { return GetByName(Name); }
        }
        public string Filename
        {
            get { return FFilename; }
            set { FFilename = value; }
        }

        OptionItem GetByName(string Name)
        {
            foreach (OptionItem N in FList)
                if (N.Name == Name)
                    return N;
            OptionItem OI = new OptionItem(Name, null);
            FList.Add(OI);
            return OI;
        }

        public void Load()
        {
            try
            {
                XmlDocument Doc = new XmlDocument();
                Doc.Load(Filename);
                if (Doc.DocumentElement != null && Doc.DocumentElement.Name == "BackupOptions")
                {
                    FList.Clear();
                    foreach (XmlNode Node in Doc.DocumentElement)
                        if (Node.Name == "Option")
                        {
                            OptionItem OI = new OptionItem();
                            OI.Load(Node);
                            FList.Add(OI);
                        }
                }
            }
            catch { }
        }

        public void Load(string Filename)
        {
            this.Filename = Filename;
            Load();
        }

        public void Save()
        {
            try
            {
                XmlDocument Doc = new XmlDocument();
                XmlNode Root = Doc.AppendChild(Doc.CreateElement("BackupOptions"));
                foreach (OptionItem OI in FList)
                    OI.Save(Root);
                XmlTextWriter Wr = new XmlTextWriter(Filename, Encoding.UTF8);
                Wr.Indentation = 4;
                Wr.Formatting = Formatting.Indented;
                Doc.Save(Wr);
                Wr.Close();
            }
            catch { }
        }

        public void Save(string Filename)
        {
            this.Filename = Filename;
            Save();
        }
    }

    public delegate void OptionItemChangeDelegate(object Sender);

    public class OptionItem
    {
        string FName;
        object FValue = null;

        public string Name
        {
            get { return FName; }
            set { FName = value; }
        }
        public object Value
        {
            get { return FValue; }
            set 
            {
                if (FValue != value)
                {
                    FValue = value;
                    if (OptionItemChangeEvent != null)
                        OptionItemChangeEvent(this);
                }
            }
        }
        public string AsString
        {
            get 
            {
                if (Value is string)
                    return (string)Value;
                else
                    return "";
            }
            set { Value = value; }
        }
        public int AsInt
        {
            get 
            {
                if (Value is int)
                    return (int)Value;
                else
                    return 0;
            }
            set { Value = value; }
        }
        public bool AsBool
        {
            get 
            {
                if (Value is bool)
                    return (bool)Value;
                else
                    return false;
            }
            set { Value = value; }
        }
        public event OptionItemChangeDelegate OptionItemChangeEvent;

        public OptionItem()
        { }

        public OptionItem(string N, object V)
        {
            FName = N;
            FValue = V;
        }

        public void Save(XmlNode Node)
        {
            XmlNode N = Node.AppendChild(Node.OwnerDocument.CreateElement("Option"));
            N.Attributes.Append(Node.OwnerDocument.CreateAttribute("name")).Value = Name;
            if (Value is string)
                N.Attributes.Append(Node.OwnerDocument.CreateAttribute("type")).Value = "string";
            if (Value is int)
                N.Attributes.Append(Node.OwnerDocument.CreateAttribute("type")).Value = "int";
            if (Value is bool)
                N.Attributes.Append(Node.OwnerDocument.CreateAttribute("type")).Value = "bool";
            N.Attributes.Append(Node.OwnerDocument.CreateAttribute("value")).Value = Value.ToString();
        }

        public void Load(XmlNode Node)
        {
            Name = XMLUtils.GetAttr(Node, "name");
            switch (XMLUtils.GetAttr(Node, "type"))
            {
                case "string":
                    AsString = XMLUtils.GetAttr(Node, "value");
                    break;
                case "int":
                    AsInt = int.Parse(XMLUtils.GetAttr(Node, "value"));
                    break;
                case "bool":
                    AsBool = bool.Parse(XMLUtils.GetAttr(Node, "value"));
                    break;
            }
        }
    }

}
