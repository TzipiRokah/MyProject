using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QueuesDTO
    {

        public int QueueId { get; set; }
        public int AttractionId { get; set; }
        public System.DateTime Hour { get; set; }
        public Nullable<int> MaxPeopleInAttraction { get; set; }
        public Nullable<int> QueueStatus { get; set; }

        public QueuesDTO(QueuesDTO qDTO)
        {
            QueueId = qDTO.QueueId;
            AttractionId = qDTO.AttractionId;
            Hour = qDTO.Hour;
            MaxPeopleInAttraction = qDTO.MaxPeopleInAttraction;
            QueueStatus = qDTO.QueueStatus;
        }

        public QueuesDTO(Queues qDB)
        {
            QueueId = qDB.QueueId;
            AttractionId = qDB.AttractionId;
            Hour = qDB.Hour;
            MaxPeopleInAttraction = qDB.MaxPeopleInAttraction;
            QueueStatus = qDB.QueueStatus;
        }

        public static List<QueuesDTO> ConvertQueuesToDTO(List<Queues> list)
        {
            var x = from qDTO in list
                    select new QueuesDTO(qDTO);
            return x.ToList();
        }

        public QueuesDTO()
        {

        }

        public QueuesDTO(int queueId, int attractionId, DateTime hour, int maxPeopleInAttraction, int queueStatus)
        {
            QueueId = queueId;
            AttractionId = attractionId;
            Hour = hour;
            MaxPeopleInAttraction = maxPeopleInAttraction;
            QueueStatus = queueStatus;
        }

        public static Queues ConvertDTOToQueues(QueuesDTO qDTO)
        {
            Queues qDB = new Queues()
            {
                QueueId = qDTO.QueueId,
                AttractionId = qDTO.AttractionId,
                Hour = qDTO.Hour,
                MaxPeopleInAttraction = qDTO.MaxPeopleInAttraction,
                QueueStatus = qDTO.QueueStatus
            };
            return qDB;
        } 
    }
}
