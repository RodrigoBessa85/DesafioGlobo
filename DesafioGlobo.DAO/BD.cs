using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGlobo.DAO
{
    public class DB
    {

        private static string cs = @"Server=RODRIGOBESSA\SQLEXPRESS;Database=EmissoraGLOBO;Trusted_Connection=True;";


        public T ExecQueryReturnOne<T>(SqlParameter[] P, String nomeSP)
        {
            List<T> oT = new List<T>();
            oT = ExecQuery<T>(P, nomeSP);

            if (oT.Count == 0)
                return (T)Activator.CreateInstance(typeof(T));
            else
                return oT[0];
        }

        public List<T> ExecQuery<T>(SqlParameter[] P, String nomeSP)
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(nomeSP))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nomeSP;
                cmd.Parameters.AddRange(P);

                dt = Query(cmd);
            }
            return dt.ToList<T>();
        }

        public DataTable Query(SqlCommand cmd)
        {
            DataTable results = new DataTable();

            SqlConnection conn = new SqlConnection(cs);

            try
            {

                cmd.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                conn.Open();
                da.Fill(results);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return results;
        }
    }

    public static class ExtensionMethods
    {
        public static List<T> ToList<T>(this DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName && dr[column.ColumnName] != DBNull.Value)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
