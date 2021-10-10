using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Context
{
    public class PhoneBookADODbContext
    {
        // System.Data.SqlClient;
        /// <summary>
        /// App ile Sql server arasinda elaqenin qurulmasi ucun istifade edilir,
        /// </summary>
        private SqlConnection _connection;

        public SqlConnection Connection
        {
            get => _connection;
            private set => _connection = value;
        }
        
        /// <summary>
        /// _connection vasitesile qurulan elaqe uzerinden TSql query-lerimizi sql servere gondermek ucun istifade edilir.
        /// </summary>
        private SqlCommand _command;
        public SqlCommand Command
        {
            get => _command;
             set => _command = value;
        }

        /// <summary>
        /// Sql serverden gelen data-nin qarsilanmasi ucun oxunmasi ucun istifade edilir.
        /// </summary>
        private SqlDataReader _dataReader;
        public SqlDataReader DataReader
        {
            get => _dataReader;
            set => _dataReader = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public int _returnValues;
        public int ReturnValues
        {
            get => _returnValues;
            set => _returnValues = value;
        }

        public PhoneBookADODbContext()
        {
            // Burada connection string elave edilir ve cari melumatlar uzerinden sql serverdeki db ile elaqe yaradilir.
            _connection = new SqlConnection("DataSource=.;Initial Catalog=PhoneBook;User Id=sa;Password=1");
        }

        /// <summary>
        /// _connection State-ne gore Connection Open ve ya Close edilir.
        /// </summary>
        public void SetConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
            else
            {
                _connection.Close();
            }
        }

        
    }
}
