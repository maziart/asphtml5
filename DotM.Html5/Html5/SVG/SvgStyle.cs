using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace DotM.Html5.SVG
{
    public class SvgStyle
    {
        private const string AttribPrefix = "$st";

        private StateBag Bag;
        public SvgStyle(StateBag bag)
        {
            Bag = bag;
        }
        public string this[string attribute]
        {
            get
            {
                return (string)Bag[AttribPrefix + attribute.ToLower()];
            }
            set
            {
                Bag[AttribPrefix + attribute.ToLower()] = value;
            }
        }
        public IEnumerable<string> Keys
        {
            get { return KeysFullName.Select(GetKeyByFullName); }
        }
        private string GetKeyByFullName(string keyFullName)
        {
            return keyFullName.Substring(AttribPrefix.Length);
        }
        private IEnumerable<string> KeysFullName
        {
            get { return Bag.Keys.Cast<string>().Where(n => n.StartsWith(AttribPrefix)); }
        }
        internal string GetSingleAttributeValue()
        {
            return string.Join("; ", KeysFullName.Select(key => string.Format("{0}:{1}", GetKeyByFullName(key), Bag[key])));
        }
    }
}
