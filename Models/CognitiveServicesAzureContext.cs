using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CognitiveServicesAzure.Models
{
    public class CognitiveServicesAzureContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CognitiveServicesAzureContext() : base("name=CognitiveServicesAzureContext")
        {
        }

        public System.Data.Entity.DbSet<CognitiveServices.Models.EmoPicture> EmoPictures { get; set; }

        public System.Data.Entity.DbSet<CognitiveServices.Models.EmoEmotion> EmoEmotions { get; set; }

        public System.Data.Entity.DbSet<CognitiveServices.Models.EmoFace> EmoFaces { get; set; }
    }
}
