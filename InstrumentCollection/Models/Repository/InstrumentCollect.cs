using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

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
        }

        public void InsertInstrument(Instrument instrument)
        {
            Collection.InsertOne(instrument);
        }

        //var collection = _database.GetCollection<BsonDocument>("test");

        //var result = await collection.Find(new BsonDocument())
        //     .Project(Builders<BsonDocument>.Projection.Exclude("_id"))
        //     .ToListAsync();
        //var obj = result.ToJson();

    }
}