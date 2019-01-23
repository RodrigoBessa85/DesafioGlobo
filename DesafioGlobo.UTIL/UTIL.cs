using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.UI.WebControls;

namespace DesafioGlobo.UTIL
{
    public static class UTIL
    {
        public static DropDownList PreencheSelect(object objData, DropDownList objSelect, string DataTextField, string DataValueField, string ValorDefault = "", string ValorSelecionado = "")
        {

            objSelect.DataSource = objData;
            objSelect.DataTextField = DataTextField;
            objSelect.DataValueField = DataValueField;
            objSelect.DataBind();

            //INSERE VALORE DEFAULT EM PRIMEIRO LUGAR
            if (ValorDefault.Trim().Length > 0)
            {
                ListItem item = new ListItem();
                item.Text = ValorDefault;
                item.Value = "";
                objSelect.Items.Insert(0, item);
            }

            //PREENCHE UM VALOR JÁ SELECIONADO
            if (ValorSelecionado.Trim().Length > 0)
                objSelect.SelectedValue = ValorSelecionado;

            return objSelect;
        }

        public static ListBox PreencheList(object objData, ListBox objSelect, string DataTextField, string DataValueField)
        {

            objSelect.DataSource = objData;
            objSelect.DataTextField = DataTextField;
            objSelect.DataValueField = DataValueField;
            objSelect.DataBind();

            return objSelect;
        }

        public static DataTable ListToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static T Parse<T>(string value)
        {
            return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(value);
        }
    }
}
