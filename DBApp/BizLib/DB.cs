using Apprenda.Services.Logging;
using DataObjects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLib
{
    public class DB
    {
        private readonly ILogger log = LogManager.Instance().GetLogger(typeof(DB));
        private static string[] MONTH = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        private string GetConnectionString()
        {
            ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["MySqlServer"];
            if (mySetting == null || string.IsNullOrEmpty(mySetting.ConnectionString))
            {
                throw new Exception("Missing connection info");
            }
            log.Info($"MySQL Connection: {mySetting.ConnectionString}");
            return mySetting.ConnectionString;
        }

        public InterestData LoadInterestData()
        {
            log.Info($"Loading Interest Data");
            string connStr = GetConnectionString();
            MySqlConnection conn = new MySqlConnection(connStr);
            InterestData data = new InterestData();
            data.Months = new List<MonthlyData>();

            try
            {
                log.Info("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT month, interest FROM whatif.monthly";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    MonthlyData m = new MonthlyData();
                    m.MonthName = rdr.GetString(0);
                    m.Interest = rdr.GetDouble(1);
                    data.Months.Add(m);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                log.Error($"Error loading interest data: {ex}");
                throw new Exception("Error loading interest data");
            }
            finally
            {
                conn.Close();
            }

            return data;
        }

        public Results SaveWhatIfModel(AccountData ac)
        {
            log.Info("SaveWhatIfModel");
            string connStr = GetConnectionString();
            Results result = new Results();
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                InterestData list = LoadInterestData();
                List<MonthlyData> id = list.Months;
                StringBuilder vals = new StringBuilder(15);
                int count = 0;
                double newBalance = 0;
                foreach (MonthlyData m in id)
                {
                    if (count > 0)
                    {
                        vals.Append(", ");
                    }
                    vals.AppendFormat("{0}", m.Interest);
                    newBalance += (ac.Balance + ac.Deposit) * m.Interest + ac.Deposit;
                    count++;
                }
                newBalance += ac.Balance;
                vals.AppendFormat(", {0}", ac.Balance);
                vals.AppendFormat(", {0}", newBalance);
                vals.AppendFormat(", {0}", ac.Deposit);
                conn.Open();

                string sql = string.Format("INSERT INTO whatif.models (mon1, mon2, mon3, mon4, mon5, mon6, mon7, mon8, mon9, mon10, mon11, mon12, balance, newbalance, deposit) " +
    "VALUES ({0})", vals.ToString());
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                result.NewBalance = newBalance;
                result.Balance = ac.Balance;
                result.Deposit = ac.Deposit;
            }
            catch (Exception ex)
            {
                log.Error($"Error saving whatif model: {ex}");
                throw new Exception("Error saving whatif model");
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public Results LoadLastResults()
        {
            log.Info("LoadLastResults");
            string connStr = GetConnectionString();
            MySqlConnection conn = new MySqlConnection(connStr);
            Results result = new Results();
            result.Months = new List<MonthlyData>();


            try
            {
                log.Info("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT created, mon1, mon2, mon3, mon4, mon5, mon6, mon7, mon8, mon9, mon10, mon11, mon12, balance, newbalance, deposit FROM whatif.models order by created desc limit 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    result.Created = rdr.GetDateTime(0);
                    int colID = 1;
                    while (colID < 13)
                    {
                        MonthlyData m = new MonthlyData();
                        m.MonthName = MONTH[colID - 1];
                        m.Interest = rdr.GetDouble(colID);
                        result.Months.Add(m);
                        colID++;
                    }
                    result.Balance = rdr.GetDouble(13);
                    result.NewBalance = rdr.GetDouble(14);
                    result.Deposit = rdr.GetDouble(15);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                log.Error($"Error loading last model: {ex}");
                throw new Exception("Error loading last model");
            }
            finally
            {
                conn.Close();
            }
            
            return result;
        }

    }
}
