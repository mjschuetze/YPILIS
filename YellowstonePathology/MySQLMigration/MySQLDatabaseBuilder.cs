﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace YellowstonePathology.MySQLMigration
{
    public class MySQLDatabaseBuilder
    {
        public MySQLDatabaseBuilder()
        {

        }

        public void Build()
        {
            ///this.BuildCreateTableCommand(typeof(YellowstonePathology.Business.Client.Model.Client));
            //this.UpdateTableSchema(typeof(YellowstonePathology.Business.Client.Model.Client));
            this.MoveData(typeof(YellowstonePathology.Business.Client.Model.Client));
        }

        private void UpdateTableSchema(Type type)
        {             
            PropertyInfo[] properties = type.GetProperties().
                Where(prop => Attribute.IsDefined(prop, typeof(Business.Persistence.PersistentProperty)) || Attribute.IsDefined(prop, typeof(Business.Persistence.PersistentPrimaryKeyProperty))).ToArray();

            for (int i = 0; i < properties.Length - 1; i++)
            {
                PropertyInfo property = properties[i];

                string tableName = "tbl" + type.Name;
                string sqlCommand = "ALTER TABLE " + tableName + " ADD column " + property.Name + " " + this.GetMySQLDataType(property.PropertyType) + "; ";                    
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sqlCommand;
                cmd.Connection = new MySqlConnection("Server = 10.1.2.26; Uid = sid; Pwd = ctlnbr4760; Database = lis;");
                cmd.Connection.Open();                
                
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Column Added: " + property.Name);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Column Exists");
                }

            }                       
        }        

        private void BuildCreateTableCommand(Type type)
        {
            string sqlCommand ="Create Table If Not Exists tbl" + type.Name + "(";

            PropertyInfo[] properties = type.GetProperties().
                Where(prop => Attribute.IsDefined(prop, typeof(Business.Persistence.PersistentProperty)) || Attribute.IsDefined(prop, typeof(Business.Persistence.PersistentPrimaryKeyProperty))).ToArray();

            for (int i = 0; i < properties.Length - 1; i++)
            {
                PropertyInfo property = properties[i];
                sqlCommand = sqlCommand + property.Name + " ";
                sqlCommand = sqlCommand + this.GetMySQLDataType(property.PropertyType) + ", ";                
            }

            if (sqlCommand.Length != 0)
            {
                sqlCommand = sqlCommand.Remove(sqlCommand.Length - 2, 2);
            }

            sqlCommand += ");";

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sqlCommand;
            cmd.Connection = new MySqlConnection("Server = 10.1.2.26; Uid = sid; Pwd = ctlnbr4760; Database = lis;");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();            
        }

        private string GetMySQLDataType(Type type)
        {
            string result = null;    
                    
            if (type == typeof(string))
            {
                result = "TEXT";
            }
            else if (type == typeof(int))
            {
                result = "INT";
            }
            else if (type == typeof(double))
            {
                result = "DOUBLE";
            }
            else if (type == typeof(Nullable<int>))
            {
                result = "INT";
            }
            else if (type == typeof(DateTime))
            {
                result = "DATETIME";
            }
            else if (type == typeof(bool))
            {
                result = "BIT";
            }
            else if (type == typeof(Nullable<bool>))
            {
                result =  "BIT";
            }
            else if (type == typeof(Nullable<DateTime>))
            {
                result = "DATETIME";
            }
            else
            {
                throw new Exception("This Data Type is Not Implemented: " + type.Name);
            }

            return result;
        }

        private void MoveData(Type type)
        {            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = this.GetSelectStatement(type);
            cmd.CommandType = CommandType.Text;

            using (SqlConnection cn = new SqlConnection(YellowstonePathology.Properties.Settings.Default.CurrentConnectionString))
            {
                cn.Open();
                cmd.Connection = cn;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    MySqlCommand mysqlCmd = new MySqlCommand();
                    
                    mysqlCmd.Connection = new MySqlConnection("Server = 10.1.2.26; Uid = sid; Pwd = ctlnbr4760; Database = lis;");
                    mysqlCmd.Connection.Open();

                    while (dr.Read())
                    {
                        mysqlCmd.CommandText = this.GetInsertStatement(type, dr);
                        mysqlCmd.ExecuteNonQuery();
                    }
                }
            }            
        }

        private string GetSelectStatement(Type type)
        {
            string result = "Select ";

            PropertyInfo[] properties = type.GetProperties().
               Where(prop => Attribute.IsDefined(prop, typeof(Business.Persistence.PersistentProperty)) || Attribute.IsDefined(prop, typeof(Business.Persistence.PersistentPrimaryKeyProperty))).ToArray();

            for (int i = 0; i < properties.Length - 1; i++)
            {
                PropertyInfo property = properties[i];
                result = result + property.Name + ", ";
            }

            if (result.Length != 0)
            {
                result = result.Remove(result.Length - 2, 2);
            }

            result = result + " from tbl" + type.Name;
            return result;
        }

        private string GetInsertStatement(Type type, SqlDataReader dr)
        {
            string result = "Insert tbl" + type.Name + "(";

            PropertyInfo[] properties = type.GetProperties().
               Where(prop => Attribute.IsDefined(prop, typeof(Business.Persistence.PersistentProperty)) || Attribute.IsDefined(prop, typeof(Business.Persistence.PersistentPrimaryKeyProperty))).ToArray();

            for (int i = 0; i < properties.Length - 1; i++)
            {
                PropertyInfo property = properties[i];
                result = result + property.Name + ", ";
            }

            if (result.Length != 0)
            {
                result = result.Remove(result.Length - 2, 2);
            }

            result = result + ") values (";

            for (int i = 0; i < properties.Length - 1; i++)
            {
                PropertyInfo property = properties[i];
                string dataType = this.GetMySQLDataType(property.PropertyType);
                if(dataType == "TEXT")
                {
                    string text = dr[i].ToString().Replace("'", "''");
                    if(string.IsNullOrEmpty(text))
                    {
                        result = result + "NULL, ";
                    }
                    else
                    {
                        result = result + "'" + text + "', ";
                    }                    
                }
                else
                {
                    result = result + dr[i] + ", ";
                }                
            }

            if (result.Length != 0)
            {
                result = result.Remove(result.Length - 2, 2);
            }

            result = result + ")";
            return result;
        }
    }
}