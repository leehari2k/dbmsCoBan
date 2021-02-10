using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.Models
{
    public class Database
    {
        private string connectionString;
        private SqlConnection conn;
        private DataTable dt;
        private SqlCommand cmd;
        public Database(string connectionString)
        {
            try
            {
                this.connectionString = connectionString;
                conn = new SqlConnection(connectionString);
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Fail: " + ex.Message);
            }
        }     
        public DataTable Query(string sql)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();

                cmd = new SqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable SelectData(string sql, List<Parameters> lstPara)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var para in lstPara)
                {
                    cmd.Parameters.AddWithValue(para.key, para.value);
                }
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public DataRow Select(string sql)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                cmd = new SqlCommand(sql, conn);

                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt.Rows[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public int ExCute(string sql, List<Parameters> lstPara)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Open();
                cmd = new SqlCommand(sql, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                
                foreach (var p in lstPara)
                { cmd.Parameters.AddWithValue(p.key, p.value); }

                var rs = cmd.ExecuteNonQuery();
                return (int)rs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Commands Error: " + ex.Message);
                return -100;
            }
            finally
            {
                conn.Close();
            }
        }        
        public int ExcuteTran(string sql)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                cmd = new SqlCommand(sql, conn);

                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message);
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }
        public int Function(string sql)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Open();
                cmd = new SqlCommand(sql, conn);
               
                var rs = cmd.ExecuteScalar();
                return (int)rs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Commands Error: " + ex.Message);
                return -100;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
