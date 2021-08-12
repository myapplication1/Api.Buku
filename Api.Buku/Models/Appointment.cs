using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Buku.Models
{
    public class Appointment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ApptID { get; set; }
        public string CusID { get; set; }
        public string BisID { get; set; }
        public string DateOfAppointment { get; set; }
       
    }


}
