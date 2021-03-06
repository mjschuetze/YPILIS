﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace YellowstonePathology.Business.Persistence
{	
	public class SqlCommandSubmitter
    {
        private Queue<SqlCommand> m_SqlInsertCommands;
        private Queue<SqlCommand> m_SqlInsertLastCommands;
        private Stack<SqlCommand> m_SqlDeleteFirstCommands;
        private Stack<SqlCommand> m_SqlDeleteCommands;
        private Queue<SqlCommand> m_SqlUpdateCommands;
        private string m_ConnectionString;

        public SqlCommandSubmitter(string databaseName)
        {           
            switch (databaseName)
            {
                case "YPIDATA":
                    this.m_ConnectionString = @"Data Source=TestSQL;Initial Catalog=YPIData;Integrated Security=True";
                    break;
                case "YPILocalData":
                    this.m_ConnectionString = @"Data Source=.\LIS;Initial Catalog=YPILocalData;Integrated Security=True";
                    break;
                default:
                    throw new Exception("Database name does not match existing.");
            }

            this.m_SqlInsertCommands = new Queue<SqlCommand>();
            this.m_SqlInsertLastCommands = new Queue<SqlCommand>();
            this.m_SqlDeleteFirstCommands = new Stack<SqlCommand>();
            this.m_SqlDeleteCommands = new Stack<SqlCommand>();
            this.m_SqlUpdateCommands = new Queue<SqlCommand>();
        }
		
        public Queue<SqlCommand> SqlInsertCommands
        {
            get { return this.m_SqlInsertCommands; }
			set { this.m_SqlInsertCommands = value; }
        }

		public Queue<SqlCommand> SqlInsertLastCommands
        {
            get { return this.m_SqlInsertLastCommands; }
			set { this.m_SqlInsertLastCommands = value; }
        }
		
		public Stack<SqlCommand> SqlDeleteFirstCommands
        {
            get { return this.m_SqlDeleteFirstCommands; }
			set { this.m_SqlDeleteFirstCommands = value; }
        }

        public Stack<SqlCommand> SqlDeleteCommands
        {
            get { return this.m_SqlDeleteCommands; }
            set { this.m_SqlDeleteCommands = value; }
        }

		public Queue<SqlCommand> SqlUpdateCommands
        {
            get { return this.m_SqlUpdateCommands; }
			set { this.m_SqlUpdateCommands = value; }
        }

        public SubmissionResult SubmitChanges()
        {                                    
            //Console.WriteLine("BEGIN send sql commands");
            SubmissionResult result = new SubmissionResult();
            result.HasUpdateCommands = this.m_SqlUpdateCommands.Count > 0;
            result.HasDeleteFirstCommands = this.m_SqlDeleteFirstCommands.Count > 0;
            result.HasDeleteCommands = this.m_SqlDeleteCommands.Count > 0;
            result.HasInsertCommands = this.m_SqlInsertCommands.Count > 0;
            result.HasInsertLastCommands = this.m_SqlInsertLastCommands.Count > 0;

            //if (result.HasDeleteCommands || result.HasDeleteFirstCommands) System.Windows.MessageBox.Show("Delete Commands - pause and step");

            this.RunSqlCommands(this.m_SqlUpdateCommands);
            this.RunSqlCommands(this.m_SqlDeleteFirstCommands);
            this.RunSqlCommands(this.m_SqlDeleteCommands);
            this.RunSqlCommands(this.m_SqlInsertCommands);
            this.RunSqlCommands(this.m_SqlInsertLastCommands);
            //Console.WriteLine("END send sql commands");
            return result;
        }

        private void RunSqlCommands(Queue<SqlCommand> sqlCommandQueue)
        {
            while (sqlCommandQueue.Count != 0)
            {
                SqlCommand cmd = sqlCommandQueue.Dequeue();
                using (SqlConnection cn = new SqlConnection(this.m_ConnectionString))
                {                    
                    cn.Open();
                    cmd.Connection = cn;                    
                    cmd.ExecuteNonQuery();
                    //Console.WriteLine(cmd.CommandText);             
                }
            }
        }        

        private void RunSqlCommands(Stack<SqlCommand> sqlCommandStack)
        {
            while (sqlCommandStack.Count != 0)
            {
                SqlCommand cmd = sqlCommandStack.Pop();
                using (SqlConnection cn = new SqlConnection(this.m_ConnectionString))
                {                    
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine(cmd.CommandText);
                }
            }
        }

        public bool HasNonASCIICharacters()
        {
            bool result = false;
            foreach (SqlCommand sqlCommand in this.m_SqlUpdateCommands)
            {
                for (int i = 0; i < sqlCommand.CommandText.Length; ++i)
                {
                    char c = sqlCommand.CommandText[i];
                    if (((int)c) > 127)
                    {
                        result = true;
                        break;
                    }
                }  
            }
            return result;
        }

        public bool HasChanges()
        {
            bool result = false;
            if (this.m_SqlUpdateCommands.Count != 0 || 
                this.m_SqlInsertCommands.Count != 0 || 
                this.m_SqlDeleteCommands.Count != 0 ||
                this.m_SqlDeleteFirstCommands.Count != 0 ||
                this.m_SqlInsertLastCommands.Count != 0)
            {
                result = true;
            }
            return result;
        }
    }
}
