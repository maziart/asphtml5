using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotM.Html5
{
    internal static class Helper
    {
        public static void AddStringAttributeIfNotEmpty(HtmlTextWriter writer, string attribName, string value)
        {
            if (!string.IsNullOrEmpty(value))
                writer.AddAttribute(attribName, value);
        }
        public static void AddBooleanAttribute(HtmlTextWriter writer, string attribName, bool value)
        {
            if (value)
                writer.AddAttribute(attribName, null);
        }
        public static void AddLowerCaseEnumIfNotZero<T>(HtmlTextWriter writer, string attribName, T value) where T: struct
        {
            var ignoreValue = (T)Enum.ToObject(typeof(T), 0);
            AddLowerCaseEnumIfNotValue<T>(writer, attribName, value, ignoreValue);
        }

        public static void AddLowerCaseEnumIfNotValue<T>(HtmlTextWriter writer, string attribName, T value, T ignoreValue) where T : struct
        {
            if (value.Equals(ignoreValue))
                return;
            writer.AddAttribute(attribName, value.ToString().ToLower());
        }
        public static void AddFloatAttributeIfNotDefault(HtmlTextWriter writer, string attribName, float value, float defaultValue)
        {
            if (value != defaultValue)
                writer.AddAttribute(attribName, value.ToString());
        }
        public static void AddUrlAttributeIfNotEmpty(HtmlTextWriter writer, string attribName, string value, Control control)
        {
            if (string.IsNullOrEmpty(value))
                return;
            writer.AddAttribute(attribName, control.ResolveClientUrl(value));
        }

        public static void AddUnitAttributeIfNotEmpty(HtmlTextWriter writer, string attribName, Unit value)
        {
            if (!value.IsEmpty)
                writer.AddAttribute(attribName, UnitToString(value));
        }

        public static string UnitToString(Unit value)
        {
            return value.Type == UnitType.Pixel ? value.Value.ToString() : value.ToString();
        }


        public static bool TryParseUnit(string input, out Unit unit)
        {
            var u = Unit.Empty;
            var result = TryInvoke(() => u = Unit.Parse(input));
            unit = u;
            return result;
        }
        private static bool TryInvoke(Action action)
        {
            try
            {
                action();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
