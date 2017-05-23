using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebCalc.Helpers;
using DBModel.Managers;

namespace WebCalc.Managers
{
    public class OperationManager : IOperationResultRepository
    {
        public IEnumerable<OperationResult> GetAll()
        {
            //Connect to base
            var items = new List<OperationResult>();

            var records = DBHelper.GetAllFromTable("OperationResult");

            foreach (IDictionary<int, object> record in records)
            {
                items.Add(
                    new OperationResult
                    {
                        Id = (int)record[0],
                        //Почемуто operationname из базы забирает с кучей пробелов в конце
                        OperationName = record[1].ToString().Trim(),
                        Arguments = record[2].ToString(),
                        Result = record[3] as double?,
                        ExecutionTime = (long)record[4],
                        ExecutionDate = (DateTime)record[5]
                    }
                 );

            }

            //Get all records

            //Get OperationResults from records

            return items;
        }

        public IEnumerable<OperationResult> GetAll(bool flag)
        {
            return null;
        }

        public OperationResult Load(long id)
        {
            throw new NotImplementedException();
        }

        public void Save(OperationResult entity)
        {
            var fields = new List<object>()
            {
                entity.OperationName,
                entity.Arguments,
                entity.Result,
                entity.ExecutionTime,
                entity.ExecutionDate.ToString("MM-dd-yyyy HH:mm:ss")
            };

            DBHelper.InsertTable("OperationResult", fields);
        }

        public void Update(OperationResult entity)
        {
            var fields = new Dictionary<string, object>()
            {
                //{ "Id", entity.Id },
                { "OperationName", entity.OperationName},
                { "Arguments", entity.Arguments },
                { "Result", entity.Result },
                { "ExecutionTime",entity.ExecutionTime },
                { "ExecutionDate",entity.ExecutionDate.ToString("MM-dd-yyyy HH:mm:ss") }
            };

            DBHelper.UpdateTable("OperationResult", fields, entity.Id);
        }

        public IEnumerable<OperationResult> GetAll(string filter)
        { return null; }

        public IDictionary<string, int> GetTop(int limit)
        {
            throw new NotImplementedException();
        }

        IEnumerable<EFOperResultRepository.TopOperationsElement> IOperationResultRepository.GetTop(int limit)
        {
            throw new NotImplementedException();
        }

        public void Delete(OperationResult entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}