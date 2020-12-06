using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace GameBase
{
    public static class TextUtil
    {
        /// <summary>
        /// プロパティ属性値のDescriptionを取り出します。
        /// 設定されていない場合はToString()の値を返します。
        /// </summary>
        public static string GetDescriptionAttribute(object value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            string desciptionString = descriptionAttributes.Select(n => n.Description).FirstOrDefault();
            return desciptionString ?? value.ToString();
        }
    }
}
