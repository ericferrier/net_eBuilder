using System;
using EstimateBuilder;
using System.Text;
using System.Data;

namespace EstimateBuilder
{
	/// <summary>
	/// Summary description for ValidationSystemDataProvider.
	/// </summary>
	public class ValidationSystemDataProvider
	{
		public ValidationSystemDataProvider()
		{
		
		}


		public void add(EstimateBuilder.ValidationSystemData  _validationSystem)
		{
			StringBuilder strSQL = new StringBuilder();
			EstimateBuilder.stData  _data = new EstimateBuilder.stData();

			strSQL.Append(" INSERT INTO ValidationSystem ( Description, Type, [Memo] )");
			strSQL.Append(" VALUES ('" + _validationSystem.Description + "','"+_validationSystem.Type +"','");
			strSQL.Append( _validationSystem.Memo +"')");
			try
			{
				_data.ExecuteSQL(strSQL.ToString(),EstimateBuilder.ApplicationBuilder.connection);
			}
			catch{}
		}

        public void Copy(EstimateBuilder.ValidationSystemData _validationSystem)
        {
            StringBuilder strSQL = new StringBuilder();
            EstimateBuilder.stData _data = new EstimateBuilder.stData();

            strSQL.Append(" INSERT INTO ValidationSystem ( Description, Type, [Memo] )");
            strSQL.Append(" VALUES (' Copy " + _validationSystem.Description + "','" + _validationSystem.Type + "','");
            strSQL.Append(_validationSystem.Memo + "')");
            try
            {
                _data.ExecuteSQL(strSQL.ToString(), EstimateBuilder.ApplicationBuilder.connection);
            }
            catch { }
        }


		public void update(EstimateBuilder.ValidationSystemData  _validationSystem)
		{		
			StringBuilder strSQL = new StringBuilder();
			EstimateBuilder.stData  _data = new EstimateBuilder.stData();

			strSQL.Append(" UPDATE [ValidationSystem] SET "); 
			strSQL.Append(" Description = '"+ _validationSystem.Description + "', ");
			strSQL.Append(" Type = '"  + _validationSystem.Type + "', [Memo] = '"  + _validationSystem.Memo + "'");
			strSQL.Append(" WHERE ValidationSystemID = "+ _validationSystem.ValidationSystemID );
			try
			{
				_data.ExecuteSQL(strSQL.ToString(),EstimateBuilder.ApplicationBuilder.connection);
			}
			catch{}
		}


		public void delete(EstimateBuilder.ValidationSystemData  _validationSystem)
		{
			StringBuilder strSQL = new StringBuilder();
			EstimateBuilder.stData  _data = new EstimateBuilder.stData();
			strSQL.Append(" DELETE * FROM [ValidationSystem] WHERE ValidationSystemID="+_validationSystem.ValidationSystemID);

			_data.ExecuteSQL(strSQL.ToString(),EstimateBuilder.ApplicationBuilder.connection);


		}

        public DataSet selectData(string _id)
        {
            StringBuilder strSQL = new StringBuilder();
            EstimateBuilder.stData _data = new EstimateBuilder.stData();

            strSQL.Append(" SELECT ValidationSystemID, Description, Type, Memo");
            strSQL.Append(" FROM [ValidationSystem] WHERE Type ='" + _id + "'");
            strSQL.Append(" AND  Description <>'View'");

            DataSet dsData = _data.getDataSet(strSQL.ToString(), EstimateBuilder.ApplicationBuilder.connection);
            return dsData;

        }

        public  EstimateBuilder.ValidationSystemDatas select(string _id)
		{
            DataSet dsData = this.selectData(_id);

            EstimateBuilder.ValidationSystemDatas _ValidationSystemDatas = new EstimateBuilder.ValidationSystemDatas();
            int i = 0;
            foreach(DataRow row in dsData.Tables[0].Rows)
			{
				EstimateBuilder.ValidationSystemData  _validationSystemData = new EstimateBuilder.ValidationSystemData();
                i += 1;
                _validationSystemData.NumbID = i;
                _validationSystemData.ValidationSystemID = Convert.ToInt32(row["ValidationSystemID"].ToString());
				_validationSystemData.Description = row["Description"].ToString();
				_validationSystemData.Type = row["Type"].ToString();
				_validationSystemData.Memo = row["Memo"].ToString();
				_ValidationSystemDatas.Add(_validationSystemData);
			}
			return _ValidationSystemDatas;
		}

        public DataSet selectData()
        {
            StringBuilder strSQL = new StringBuilder();
            EstimateBuilder.stData _data = new EstimateBuilder.stData();

            strSQL.Append(" SELECT ValidationSystemID, Description, Type, Memo");
            strSQL.Append(" FROM [ValidationSystem]");
            strSQL.Append(" WHERE  Description <>'View'");


            DataSet dsData = _data.getDataSet(strSQL.ToString(), EstimateBuilder.ApplicationBuilder.connection);
            return dsData;
        }

        public EstimateBuilder.ValidationSystemDatas select()
		{
            DataSet dsData = this.selectData();
            EstimateBuilder.ValidationSystemDatas _ValidationSystemDatas = new EstimateBuilder.ValidationSystemDatas();

            int i = 0;
            foreach(DataRow row in dsData.Tables[0].Rows)
			{
				EstimateBuilder.ValidationSystemData _validationSystemData = new EstimateBuilder.ValidationSystemData();
                i += 1;
                _validationSystemData.NumbID = i;
                _validationSystemData.ValidationSystemID = Convert.ToInt32(row["ValidationSystemID"].ToString());
				_validationSystemData.Description = row["Description"].ToString();
				_validationSystemData.Type = row["Type"].ToString();
				_validationSystemData.Memo = row["Memo"].ToString();
				_ValidationSystemDatas.Add(_validationSystemData);
			}
			return _ValidationSystemDatas;
		}


		public void Dispose()
		{
			GC.Collect();
		}

	}
}
