using MongoDB.Driver;
using SmartPlugAPI.Dto.Request;
using SmartPlugAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPlugAPI.Service
{
    public class FormService
    {
        private readonly IMongoClient _Client;
        public FormService(IMongoClient mongoClient)
        {
            _Client = mongoClient;
        }
        public async Task<Tuple<bool, string>> SendMessage(FormRequestDto model, string website)
        {
            //define the database using the company name as DBName
            var database = _Client.GetDatabase(website);
            //Get the collection 
            var collection = database.GetCollection<Form>("formMessages");
            //If it is null, create new database
            if (collection == null) await database.CreateCollectionAsync("formMessages");

            //map the MessageToSendDto to Message Model
            var form = new Form
            {
                CustomerName = model.CustomerName,
                CustomerEmail = model.CustomerEmail,
                CustomerFeedback = model.CustomerFeedback,
                CollectionName = model.CollectionName,
                DatabaseName = model.DatabaseName
            };
            try
            {
                //Insert the message to collection
                await collection.InsertOneAsync(form);
                return new Tuple<bool, string>(true, "Message Added Successfully");
            }
            catch (NullReferenceException e)
            {
                return new Tuple<bool, string>(false, "Failed to Add Message: " + e.Message.ToString());
            }
        }
    }
}

