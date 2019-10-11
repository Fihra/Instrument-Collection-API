using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace InstrumentCollection.Models.Repository
{
    public class InstrumentCollect
    {
        public IMongoCollection<Instrument> Collection;

        public InstrumentCollect()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = client.GetDatabase("InstrumentDB");
            Collection = db.GetCollection<Instrument>("Instruments");
        }

        public List<Instrument> SelectAll()
        {
            var query = Collection.Find(new BsonDocument()).ToList();

            return query;
            //var output = query.ToJson();
            //return output;
        }

        public void InsertInstrument(Instrument instrument)
        {
            Collection.InsertOne(instrument);
        }

        //public Book Get(string id) =>
        //_books.Find<Book>(book => book.Id == id).FirstOrDefault();

        public Instrument Get(string id)
        {
            //var query = Collection.Find<Instrument>(i => i.Id == id);
            //return query;

            //var filter_id = Builders<MODEL_NAME>.Filter.Eq("id", ObjectId.Parse("50ed4e7d5baffd13a44d0153"));
            //var entity = dbCollection.Find(filter).FirstOrDefault();
            //return entity.ToString();
            var filter = Builders<Instrument>.Filter.Eq("Id", id);
            var query = Collection.Find(filter).FirstOrDefault();
            return query;
            

            //return result;
        }

        //var collection = _database.GetCollection<BsonDocument>("test");

        //var result = await collection.Find(new BsonDocument())
        //     .Project(Builders<BsonDocument>.Projection.Exclude("_id"))
        //     .ToListAsync();
        //var obj = result.ToJson();

    }
}